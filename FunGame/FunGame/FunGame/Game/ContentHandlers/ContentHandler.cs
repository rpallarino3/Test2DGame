using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.ContentHandlers
{
    class ContentHandler
    {

        ContentManager content;

        private List<Texture2D> playerImages;
        private List<Texture2D> swordImages;
        private List<Texture2D> testZoneImages; // make a zone content handler
        private List<Texture2D> testCaveImages;
        private List<Texture2D> testBattleZoneImages;
        private List<Texture2D> testNPCImagesA;
        private List<Texture2D> testNPCImagesB;
        private List<Texture2D> testNPCImagesC;

        private Dictionary<int, List<Texture2D>> zoneImages;
        private Dictionary<String, List<Texture2D>> npcImages;

        public ContentHandler(ContentManager content)
        {
            this.content = content;
            playerImages = new List<Texture2D>();
            swordImages = new List<Texture2D>();
            testZoneImages = new List<Texture2D>();
            testCaveImages = new List<Texture2D>();
            testBattleZoneImages = new List<Texture2D>();
            testNPCImagesA = new List<Texture2D>();
            testNPCImagesB = new List<Texture2D>();
            testNPCImagesC = new List<Texture2D>();

            zoneImages = new Dictionary<int, List<Texture2D>>();
            npcImages = new Dictionary<String, List<Texture2D>>();
        }

        public void loadContent()
        {
            loadPlayerContent();
            loadZoneContent();
            loadNPCContent();
        }

        public void loadPlayerContent()
        {
            playerImages.Add(content.Load<Texture2D>("Images/Player/bigplayerup"));
            playerImages.Add(content.Load<Texture2D>("Images/Player/bigplayerdown"));
            playerImages.Add(content.Load<Texture2D>("Images/Player/bigplayerright"));
            playerImages.Add(content.Load<Texture2D>("Images/Player/bigplayerleft"));
            swordImages.Add(content.Load<Texture2D>("Images/Player/swordup"));
            swordImages.Add(content.Load<Texture2D>("Images/Player/sworddown"));
            swordImages.Add(content.Load<Texture2D>("Images/Player/swordright"));
            swordImages.Add(content.Load<Texture2D>("Images/Player/swordleft"));
        }

        public void loadZoneContent()
        {
            testZoneImages.Add(content.Load<Texture2D>("Images/Zones/TestGrassZoneFloor1"));
            testZoneImages.Add(content.Load<Texture2D>("Images/Zones/TestGrassZoneFloor2"));
            testCaveImages.Add(content.Load<Texture2D>("Images/Zones/TestCave"));
            testBattleZoneImages.Add(content.Load<Texture2D>("Images/Zones/TestBattleZone"));

            zoneImages.Add(-1, testZoneImages);
            zoneImages.Add(-2, testCaveImages);
            zoneImages.Add(-3, testBattleZoneImages);
        }

        public void loadNPCContent()
        {
            testNPCImagesA.Add(content.Load<Texture2D>("Images/NPCs/TestZones/TestZone/TestNPC/StationaryImage"));
            npcImages.Add("A", testNPCImagesA);

            testNPCImagesB.Add(content.Load<Texture2D>("Images/NPCs/TestZones/TestZone/TestNPC/LargeStationaryImage"));
            npcImages.Add("B", testNPCImagesB);

            testNPCImagesC.Add(content.Load<Texture2D>("Images/NPCs/TestZones/TestZone/TestNPC/LargeTallStationaryImage"));
            npcImages.Add("C", testNPCImagesC);

        }

        public List<Texture2D> getPlayerImages()
        {
            return playerImages;
        }

        public List<Texture2D> getSwordImages()
        {
            return swordImages;
        }

        public Dictionary<int, List<Texture2D>> getZoneImages()
        {
            return zoneImages;
        }

        public Dictionary<String, List<Texture2D>> getNPCImages()
        {
            return npcImages;
        }

    }
}
