using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

using FunGame.Game;
using FunGame.Game.Environment;

namespace FunGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private bool saveRequested;
        private bool loadRequested;
        private GameInit game;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 900;
            graphics.ApplyChanges();

            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 30.0f);

            Content.RootDirectory = "Content";
            saveRequested = false;
            loadRequested = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            game = new GameInit(Content);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            game.getContentHandler().loadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        IAsyncResult result;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Console.WriteLine(game.getPlayer().getGlobalLocation());
            if (Keyboard.GetState().IsKeyDown(Keys.Delete))
            {
                //result = requestSave();
            }
            if (saveRequested && result.IsCompleted)
            {
                beginSave(result);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Home))
            {
                result = requestLoad();
            }
            if (loadRequested && result.IsCompleted)
            {
                beginLoad(result);
            }
            game.getKeyHandler().updateKeys(Keyboard.GetState()); // add some form of previous state
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (game.getGameState().getState() == 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            else
            {
                game.getPaintHandler().draw(spriteBatch);
            }
            



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        // might want to move all of this to a separate class

        public IAsyncResult requestSave()
        {
            Console.WriteLine("Save requested");
            saveRequested = true;
            return StorageDevice.BeginShowSelector(PlayerIndex.One, null, null);
        }

        public IAsyncResult requestLoad()
        {
            Console.WriteLine("Load requested");
            loadRequested = true;
            return StorageDevice.BeginShowSelector(PlayerIndex.One, null, null);
        }

        public void beginSave(IAsyncResult result)
        {
            Console.WriteLine("Beginning save");
            StorageDevice device = StorageDevice.EndShowSelector(result);
            if (device != null && device.IsConnected)
            {
                saveGame(device);
            }
        }

        public void beginLoad(IAsyncResult load)
        {
            Console.WriteLine("Beginning load");
            StorageDevice device = StorageDevice.EndShowSelector(result);
            if (device != null && device.IsConnected)
            {
                loadGame(device);
            }
        }

        public void saveGame(StorageDevice device)
        {
            Console.WriteLine("Saving");
            SaveGameData data = new SaveGameData();
            data.currentPlayerZone = game.getZoneFactory().getCurrentZone().getZoneNumber();
            data.currentPlayerLevel = 0;
            data.playerPosition = new Vector2(100, 1000);

            IAsyncResult result = device.BeginOpenContainer("Container", null, null);
            result.AsyncWaitHandle.WaitOne();
            StorageContainer container = device.EndOpenContainer(result);
            result.AsyncWaitHandle.Close();

            string filename = "savegame.sav";

            if (container.FileExists(filename))
            {
                container.DeleteFile(filename);
            }

            Stream stream = container.CreateFile(filename);

            XmlSerializer serializer = new XmlSerializer(typeof(SaveGameData));
            serializer.Serialize(stream, data);

            stream.Close();

            container.Dispose();

            saveRequested = false;
            Console.WriteLine("save complete");
        }

        public void loadGame(StorageDevice device)
        {
            Console.WriteLine("loading");
            IAsyncResult result = device.BeginOpenContainer("Container", null, null);
            result.AsyncWaitHandle.WaitOne();
            StorageContainer container = device.EndOpenContainer(result);
            result.AsyncWaitHandle.Close();

            string filename = "savegame.sav";

            if (!container.FileExists(filename))
            {
                container.Dispose();
                return;
            }

            Stream stream = container.OpenFile(filename, FileMode.Open);

            XmlSerializer serializer = new XmlSerializer(typeof(SaveGameData));
            SaveGameData data = (SaveGameData)serializer.Deserialize(stream);

            stream.Close();

            container.Dispose();


            game.getZoneFactory().loadZones(data.currentPlayerZone);
            game.getZoneFactory().setCurrentZoneFromNumber(data.currentPlayerZone);
            game.getPlayer().setZoneLevel(data.currentPlayerLevel);
            game.getPlayer().setGlobalLocation(data.playerPosition);
            game.getKeyHandler().getMovementHandler().updateDrawLocations(game.getPlayer(), game.getZoneFactory().getCurrentZone());

            Console.WriteLine("Zone number: " + data.currentPlayerZone);
            Console.WriteLine("Player level: " + data.currentPlayerLevel);
            Console.WriteLine("Position: " + data.playerPosition);

            loadRequested = false;
            Console.WriteLine("load completed");

            game.getGameState().setGameState();
        }

        [Serializable]
        public struct SaveGameData
        {
            public int currentPlayerZone;
            public int currentPlayerLevel;
            public Vector2 playerPosition;
        }

        
    }
}
