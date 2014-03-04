using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGame.Game.Environment
{
    class TransitionMap
    {

        private int[,] transitionMap;
        private int mapHeight;
        private int mapWidth;

        public TransitionMap(int height, int width)
        {
            mapHeight = height;
            mapWidth = width;
            transitionMap = new int[mapHeight, mapWidth];
            fillMapWithZero();
        }

        private void fillMapWithZero()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    transitionMap[i, j] = 0;
                }
            }
        }

        public void fillLocation(int num, int y, int x)
        {
            transitionMap[y, x] = num;
        }

        public void fillRectangle(int num, int y, int x, int height, int width)
        {
            for (int i = y; i < height + y; i++)
            {
                for (int j = x; j < width + x; j++)
                {
                    fillLocation(num, i, j);
                }
            }
        }

        public int[,] getTransitionMap()
        {
            return transitionMap;
        }

        public int getMapHeight()
        {
            return mapHeight;
        }

        public int getMapWidth()
        {
            return mapWidth;
        }
    }
}
