using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NPCandEnemies;

namespace Environment
{
    class TestCave : Zone
    {

        private CollisionMap level1;

        private TransitionMap level1Trans;

        private TrafficMap level1TrafficMap;

        public TestCave(int tileWidth, int tileHeight)
        {
            zoneNumber = -2;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            createLists();
            levels.Add(Image.FromFile("../../../Images/Zones/TestCave.png"));
            level1 = new CollisionMap(tileHeight * 30, tileWidth * 30);
            collisionMap.Add(level1);

            level1Trans = new TransitionMap(tileHeight * 30, tileWidth * 30);
            transitionMap.Add(level1Trans);

            level1TrafficMap = new TrafficMap(tileHeight * 30, tileWidth * 30);
            trafficMap.Add(level1TrafficMap);

            fillLevel1();
            fillLevel1Trans();
        }

        private void createLists()
        {
            levels = new List<Image>();
            collisionMap = new List<CollisionMap>();
            transitionMap = new List<TransitionMap>();
            transitionZones = new List<Zone>();
            transitionPoints = new List<Point>();
            trafficMap = new List<TrafficMap>();
            npcList = new List<NPC>();
        }

        private void fillLevel1()
        {
            level1.fillFalseRectangle(150, 200, 300, 30);
            level1.fillFalseRectangle(150, 230, 30, 440);
            level1.fillFalseRectangle(150, 670, 300, 30);
            level1.fillFalseRectangle(420, 230, 30, 440);
            level1.fillTrueRectangle(420, 425, 1, 50);
        }

        private void fillLevel1Trans()
        {
            level1Trans.fillRectangle(1, 420, 435, 1, 30);
        }

    }
}
