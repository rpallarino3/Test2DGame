using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Environment
{
    class TestCave : Zone
    {

        private CollisionMap level1;

        private TransitionMap level1Trans;

        public TestCave(int tileWidth, int tileHeight)
        {
            zoneNumber = -2;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            levels = new List<Image>();
            levels.Add(Image.FromFile("../../../Images/Zones/TestCave.png"));
            collisionMap = new List<CollisionMap>();
            level1 = new CollisionMap(tileHeight * 30, tileWidth * 30);
            collisionMap.Add(level1);

            transitionMap = new List<TransitionMap>();
            level1Trans = new TransitionMap(tileHeight * 30, tileWidth * 30);
            transitionMap.Add(level1Trans);

            fillLevel1();
            fillLevel1Trans();
        }

        private void fillLevel1()
        {
            level1.fillFalseRectangle(150, 200, 300, 30);
            level1.fillFalseRectangle(150, 230, 30, 440);
            level1.fillFalseRectangle(150, 670, 300, 30);
            level1.fillFalseRectangle(420, 230, 30, 440);
        }

        private void fillLevel1Trans()
        {
        }

    }
}
