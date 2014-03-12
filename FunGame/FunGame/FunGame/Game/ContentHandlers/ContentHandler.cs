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

        private ContentManager content;

        private PlayerContentHandler playerContentHandler;

        private List<Texture2D> swordImages;
        private List<Texture2D> testZoneImages; // make a zone content handler
        private List<Texture2D> testCaveImages;
        private List<Texture2D> testBattleZoneImages;
        private List<Texture2D> testNPCImagesA;
        private List<Texture2D> testNPCImagesB;
        private List<Texture2D> testNPCImagesC;
        private List<Texture2D> testSpawnerImages;
        private List<Texture2D> testGoblinImages;

        private Dictionary<int, List<Texture2D>> zoneImages;
        private Dictionary<string, List<Texture2D>> npcImages;
        private Dictionary<string, List<Texture2D>> spawnerImages;

        public ContentHandler(ContentManager content)
        {
            this.content = content;
            playerContentHandler = new PlayerContentHandler(content);
            swordImages = new List<Texture2D>();
            testZoneImages = new List<Texture2D>();
            testCaveImages = new List<Texture2D>();
            testBattleZoneImages = new List<Texture2D>();
            testNPCImagesA = new List<Texture2D>();
            testNPCImagesB = new List<Texture2D>();
            testNPCImagesC = new List<Texture2D>();
            testSpawnerImages = new List<Texture2D>();
            testGoblinImages = new List<Texture2D>();

            zoneImages = new Dictionary<int, List<Texture2D>>();
            npcImages = new Dictionary<string, List<Texture2D>>();
            spawnerImages = new Dictionary<string, List<Texture2D>>();
        }

        public void loadContent()
        {
            loadPlayerContent();
            loadZoneContent();
            loadNPCContent();
            loadEnemyContent();
        }

        private void loadPlayerContent()
        {
            playerContentHandler.loadContent();

            swordImages.Add(content.Load<Texture2D>("Images/Player/swordup"));
            swordImages.Add(content.Load<Texture2D>("Images/Player/sworddown"));
            swordImages.Add(content.Load<Texture2D>("Images/Player/swordright"));
            swordImages.Add(content.Load<Texture2D>("Images/Player/swordleft"));
        }

        private void loadZoneContent()
        {
            testZoneImages.Add(content.Load<Texture2D>("Images/Zones/TestGrassZoneFloor1"));
            testZoneImages.Add(content.Load<Texture2D>("Images/Zones/TestGrassZoneFloor2"));
            testCaveImages.Add(content.Load<Texture2D>("Images/Zones/TestCave"));
            testBattleZoneImages.Add(content.Load<Texture2D>("Images/Zones/TestBattleZone"));

            zoneImages.Add(-1, testZoneImages);
            zoneImages.Add(-2, testCaveImages);
            zoneImages.Add(-3, testBattleZoneImages);

            testSpawnerImages.Add(content.Load<Texture2D>("Images/Enemies/Spawners/TestSpawners/testspawner"));

            spawnerImages.Add("Test", testSpawnerImages);
        }

        private void loadNPCContent()
        {
            testNPCImagesA.Add(content.Load<Texture2D>("Images/NPCs/TestZones/TestZone/TestNPC/StationaryImage"));
            npcImages.Add("A", testNPCImagesA);

            testNPCImagesB.Add(content.Load<Texture2D>("Images/NPCs/TestZones/TestZone/TestNPC/LargeStationaryImage"));
            npcImages.Add("B", testNPCImagesB);

            testNPCImagesC.Add(content.Load<Texture2D>("Images/NPCs/TestZones/TestZone/TestNPC/LargeTallStationaryImage"));
            npcImages.Add("C", testNPCImagesC);

        }

        private void loadEnemyContent()
        {
            testGoblinImages.Add(content.Load<Texture2D>("Images/Enemies/Enemies/TestGoblin/goblintest"));
        }

        public List<Texture2D> getPlayerImages()
        {
            return playerContentHandler.getStationaryImages();
        }

        public List<Texture2D> getSwordImages()
        {
            return swordImages;
        }

        public List<Texture2D> getGoblinImages()
        {
            return testGoblinImages;
        }

        public PlayerContentHandler getPlayerContentHandler()
        {
            return playerContentHandler;
        }

        public Dictionary<int, List<Texture2D>> getZoneImages()
        {
            return zoneImages;
        }

        public Dictionary<string, List<Texture2D>> getNPCImages()
        {
            return npcImages;
        }

        public Dictionary<string, List<Texture2D>> getSpawnerImages()
        {
            return spawnerImages;
        }

    }
}
