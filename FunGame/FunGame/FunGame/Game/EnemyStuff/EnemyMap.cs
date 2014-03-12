using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.EnemyStuff
{
    class EnemyMap
    {

        private bool[,] trafficMap;
        private Enemy[,] enemyMap;
        private int mapHeight;
        private int mapWidth;

        public EnemyMap(int height, int width)
        {
            mapHeight = height;
            mapWidth = width;

            trafficMap = new bool[mapHeight, mapWidth];
            enemyMap = new Enemy[mapHeight, mapWidth];

            fillMapWithFalse();
        }

        private void fillMapWithFalse()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    trafficMap[i, j] = false;
                }
            }
        }

        public void fillRectangle(bool isEnemy, int y, int x, int height, int width)
        {
            for (int i = y; i < height + y; i++)
            {
                for (int j = x; j < width + x; j++)
                {
                    fillLocation(isEnemy, i, j);
                }
            }
        }

        public void fillLocation(bool isEnemy, int y, int x)
        {
            trafficMap[y, x] = isEnemy;
        }

        public void insertEnemy(Enemy enemy)
        {
            Vector2 walkSize = enemy.getWalkingSize();
            Vector2 size = enemy.getSize();
            Vector2 location = enemy.getLocation();

            fillRectangle(true, (int) location.Y, (int) location.X, (int) walkSize.Y, (int) walkSize.X);
            for (int i = (int) location.Y - ((int) size.Y - (int) walkSize.Y); i < (int) location.Y + (int) size.Y; i++)
            {
                for (int j = (int) location.X; j < (int) location.X + (int) size.X; j++)
                {
                    insertEnemyAtLocation(enemy, i, j);
                }
            }
        }

        public void removeEnemy(Enemy enemy)
        {
            Vector2 walkSize = enemy.getWalkingSize();
            Vector2 size = enemy.getSize();
            Vector2 location = enemy.getLocation();

            fillRectangle(false, (int)location.Y, (int)location.X, (int)walkSize.Y, (int)walkSize.X);
            for (int i = (int)location.Y - ((int)size.Y - (int)walkSize.Y); i < (int)location.Y + (int)size.Y; i++)
            {
                for (int j = (int)location.X; j < (int)location.X + (int)size.X; j++)
                {
                    removeEnemyAtLocation(i, j);
                }
            }
        }

        public void insertEnemyAtLocation(Enemy enemy, int y, int x)
        {
            enemyMap[y, x] = enemy;
        }

        public void removeEnemyAtLocation(int y, int x)
        {
            enemyMap[y, x] = null;
        }

        public int getMapHeight()
        {
            return mapHeight;
        }

        public int getMapWidth()
        {
            return mapWidth;
        }

        public bool[,] getTrafficMap()
        {
            return trafficMap;
        }

        public Enemy[,] getEnemyMap()
        {
            return enemyMap;
        }
    }
}
