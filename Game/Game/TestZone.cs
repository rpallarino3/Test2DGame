using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Environment
{
    class TestZone : Zone
    {

        public CollisionMap level1;
        public CollisionMap level2;

        public TestZone(int tileWidth, int tileHeight)
        {
            zoneNumber = -1;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            levels = new List<Image>();
            levels.Add(Image.FromFile("../../../Images/Zones/TestGrassZoneFloor1.png"));
            levels.Add(Image.FromFile("../../../Images/Zones/TestGrassZoneFloor2.png"));
            collisionMap = new List<CollisionMap>();
            level1 = new CollisionMap(tileHeight * 30, tileWidth * 30);
            level2 = new CollisionMap(tileHeight * 30, tileWidth * 30);
            collisionMap.Add(level1);
            collisionMap.Add(level2);
            fillLevel1();
            fillLevel2();
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
    }
}
