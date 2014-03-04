using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunGame.Game.NPCandEnemies;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.TestEnvironment
{
    class TestZone : Zone
    {

        private CollisionMap level1;
        private CollisionMap level2;

        private TransitionMap level1Trans;
        private TransitionMap level2Trans;

        private TrafficMap level1TrafficMap;
        private TrafficMap level2TrafficMap;

        public TestZone(int width, int height)
        {
            zoneNumber = -1;
            this.width = width;
            this.height = height;
            setDrawLocation(new Vector2(0, 0));
            createLists();
            //levels.Add(Image.FromFile("../../../Images/Zones/TestGrassZoneFloor1.png"));
            //levels.Add(Image.FromFile("../../../Images/Zones/TestGrassZoneFloor2.png"));
            
            level1 = new CollisionMap(height, width);
            level2 = new CollisionMap(height, width);
            collisionMap.Add(level1);
            collisionMap.Add(level2);
            
            level1Trans = new TransitionMap(height, width);
            level2Trans = new TransitionMap(height, width);
            transitionMap.Add(level1Trans);
            transitionMap.Add(level2Trans);
            fillLevel1();
            fillLevel2();
            fillLevel1Trans();
            fillLevel2Trans();

            level1TrafficMap = new TrafficMap(height, width);
            level2TrafficMap = new TrafficMap(height, width);
            trafficMap.Add(level1TrafficMap);
            trafficMap.Add(level2TrafficMap);
            fillLevel1TrafficMap();
            
        }

        private void createLists()
        {
            //levels = new List<Image>();
            collisionMap = new List<CollisionMap>();
            transitionMap = new List<TransitionMap>();
            transitionZones = new List<Zone>();
            transitionPoints = new List<Vector2>();
            trafficMap = new List<TrafficMap>();
            npcList = new List<NPC>();
        }

        private void fillLevel1()
        {
            level1.fillFalseRectangle(0, 0, 1500, 1500);
            level1.fillTrueRectangle(30, 30, 1440, 1440);
            level1.fillFalseRectangle(960, 30, 10, 520);
            level1.fillFalseRectangle(420, 540, 540, 10);
            level1.fillFalseRectangle(430, 950, 710, 10);
            level1.fillFalseRectangle(30, 530, 400, 10);
            level1.fillFalseRectangle(420, 950, 10, 550);
            level1.fillTrueRectangle(1470, 900, 30, 50);
        }

        private void fillLevel2()
        {
            level2.fillFalseRectangle(0, 0, 1500, 1500);
            level2.fillTrueRectangle(30, 30, 1440, 1440);
            level2.fillFalseRectangle(960, 30, 10, 520);
            level2.fillFalseRectangle(650, 540, 310, 10);
            level2.fillFalseRectangle(650, 550, 10, 410);
            level2.fillFalseRectangle(660, 950, 490, 10);
            level2.fillFalseRectangle(30, 530, 400, 10);
            level2.fillFalseRectangle(420, 540, 10, 960);
        }

        private void fillLevel1Trans()
        {
            level1Trans.fillRectangle(3, 30, 1440, 30, 30);
            level1Trans.fillRectangle(1, 1069, 959, 1, 330);
            level1Trans.fillRectangle(4, 1470, 900, 30, 50);
        }

        private void fillLevel2Trans()
        {
            level2Trans.fillRectangle(2, 1139, 959, 1, 330);
        }

        private void fillLevel1TrafficMap()
        {
            NPC testNPC = new NPC("A", this, new Vector2(300, 1200), 0, new Vector2(30, 30)); // need to move creation of NPCS somewhere else
            NPC testNPC2 = new NPC("B", this, new Vector2(350, 1200), 0, new Vector2(30, 60));
            NPC testNPC3 = new NPC("C", this, new Vector2(750, 750), 0, new Vector2(60, 60));
            //testNPC.setStationaryImage(Image.FromFile("../../../Images/NPCs/TestZones/TestZone/TestNPC/StationaryImage.png"));
            //testNPC2.setStationaryImage(Image.FromFile("../../../Images/NPCs/TestZones/TestZone/TestNPC/LargeStationaryImage.png"));
            //testNPC3.setStationaryImage(Image.FromFile("../../../Images/NPCs/TestZones/TestZone/TestNPC/LargeTallStationaryImage.png"));
            level1TrafficMap.insertNPC(testNPC, 1200, 300, 30, 30); //use npc height and width etc.
            level1TrafficMap.insertNPC(testNPC2, 1200, 350, 30, 30);
            level1TrafficMap.insertNPC(testNPC3, 750, 750, 30, 60);
            npcList.Add(testNPC);
            npcList.Add(testNPC2);
            npcList.Add(testNPC3);
        }
    }
}
