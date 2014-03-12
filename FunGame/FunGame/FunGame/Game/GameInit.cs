﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

using FunGame.Game.ContentHandlers;
using FunGame.Game.PlayerStuff;
using FunGame.Game.Environment;
using FunGame.Game.PaintHandlers;
using FunGame.Game.KeyHandlers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

namespace FunGame.Game
{
    class GameInit
    {

        private GameState gameState;
        private PaintHandler paintHandler;
        private ContentHandler contentHandler;
        private KeyHandler keyHandler;

        private Player player;
        private ZoneFactory zoneFactory;


        public GameInit(ContentManager content)
        {

            player = new Player();
            contentHandler = new ContentHandler(content);
            paintHandler = new PaintHandler(this);
            keyHandler = new KeyHandler(this);
            gameState = new GameState();
            zoneFactory = new ZoneFactory();
        }

        public PaintHandler getPaintHandler()
        {
            return paintHandler;
        }

        public GameState getGameState()
        {
            return gameState;
        }

        public ContentHandler getContentHandler()
        {
            return contentHandler;
        }

        public KeyHandler getKeyHandler()
        {
            return keyHandler;
        }

        public ZoneFactory getZoneFactory()
        {
            return zoneFactory;
        }

        public Player getPlayer()
        {
            return player;
        }

        


    }
}
