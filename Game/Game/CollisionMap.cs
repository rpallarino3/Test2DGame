using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment
{
    class CollisionMap
    {

        private bool[,] collisionMap;
        private int mapHeight;
        private int mapWidth;

        public CollisionMap(int height, int width)
        {
            mapHeight = height;
            mapWidth = width;
            collisionMap = new bool[mapHeight, mapWidth];
            fillMapWithTrue();
        }

        private void fillMapWithTrue()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    collisionMap[i, j] = true;
                }
            }
        }

        public void fillLocation(bool walkable, int y, int x)
        {
            collisionMap[y, x] = walkable;
        }

        public void flipLocation(int y, int x)
        {
            collisionMap[y, x] = !collisionMap[y, x];
        }

        public void fillTrueRectangle(int y, int x, int height, int width)
        {
            for (int i = y; i < height + y; i++)
            {
                for (int j = x; j < width + x; j++)
                {
                    fillLocation(true, i, j);
                }
            }
        }

        public void fillFalseRectangle(int y, int x, int height, int width)
        {
            for (int i = y; i < height + y; i++)
            {
                for (int j = x; j < width + x; j++)
                {
                    fillLocation(false, i, j);
                }
            }
        }

        public bool[,] getCollisionMap()
        {
            return collisionMap;
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
