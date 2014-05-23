using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FunGame.Game.ContentHandlers
{
    class NPCContentHandler
    {
        private Dictionary<string, Dictionary<string, List<Texture2D>>> npcImages;

        private ContentManager content;

        public NPCContentHandler(ContentManager content)
        {
            this.content = content;

            npcImages = new Dictionary<string, Dictionary<string, List<Texture2D>>>();
        }

        public void loadContent()
        {
            loadTestNPC();
        }

        private void loadTestNPC()
        {
            Dictionary<string, List<Texture2D>> testNPC = new Dictionary<string, List<Texture2D>>();

            List<Texture2D> stationaryUp = new List<Texture2D>();

            stationaryUp.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryUp/StationaryUp"));
            stationaryUp.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryUp/StationaryUp"));

            testNPC.Add("STATIONARY_UP", stationaryUp);

            List<Texture2D> stationaryDown = new List<Texture2D>();

            stationaryDown.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryDown/StationaryDown"));
            stationaryDown.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryDown/StationaryDown"));

            testNPC.Add("STATIONARY_DOWN", stationaryDown);

            List<Texture2D> stationaryRight = new List<Texture2D>();

            stationaryRight.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryRight/StationaryRight"));
            stationaryRight.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryRight/StationaryRight"));

            testNPC.Add("STATIONARY_RIGHT", stationaryRight);

            List<Texture2D> stationaryLeft = new List<Texture2D>();

            stationaryLeft.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryLeft/StationaryLeft"));
            stationaryLeft.Add(content.Load<Texture2D>("Images/NPCs/TestNPCs/Test/StationaryLeft/StationaryLeft"));

            testNPC.Add("STATIONARY_LEFT", stationaryLeft);

            npcImages.Add("TEST", testNPC);
        }

        public Dictionary<string, Dictionary<string, List<Texture2D>>> getNPCImages()
        {
            return npcImages;
        }
    }
}
