using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.Environment.ZoneTiles;

namespace FunGame.Game.Environment
{
    class ZoneTileMap
    {

        public readonly int FREE = 0;
        public readonly int GAP = 1;
        public readonly int IMPASSABLE = 2;
        public readonly int EGDE = 3;
        public readonly int ANGULAR_CORNER = 4;
        public readonly int RECTANGULAR_CORNER = 5;
        public readonly int CORNER = 6;
        public readonly int HALF_CORNER = 7;

        private int height;
        private int width;
        private int levels;

        private List<ZoneTile[,]> zoneMap;

        public ZoneTileMap(int width, int height, int levels)
        {
            zoneMap = new List<ZoneTile[,]>();

            this.width = width;
            this.height = height;
            this.levels = levels;

            createMap();
            fillWithFree();
        }

        private void createMap()
        {
            for (int i = 0; i < levels; i++)
            {
                zoneMap.Add(new ZoneTile[height, width]);
            }
        }

        private void fillWithFree()
        {
            for (int i = 0; i < zoneMap.Count; i++)
            {
                fillFreeRectangle(0, 0, height, width, i);
            }
        }

        public void fillFreeRectangle(int y, int x, int height, int width, int level)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new FreeTile();
                }
            }
        }

        public void fillGapRectangle(int y, int x, int height, int width, int level)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new GapTile();
                }
            }
        }

        public void fillImpassableRectangle(int y, int x, int height, int width, int level)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new ImpassableTile();
                }
            }
        }

        public void fillEdgeRectangle(int y, int x, int height, int width, int level, int orientation, int distance, int thickness)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new EdgeTile(orientation, distance, thickness);
                }
            }
        }

        public void fillAngularCornerRectangle(int y, int x, int height, int width, int level, int orientation, int b, int h)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new AngularCornerTile(orientation, b, h);
                }
            }
        }

        public void fillRectangularCornerRectangle(int y, int x, int height, int width, int level, int orientation, int xSize, int ySize)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new RectangularCornerTile(orientation, xSize, ySize);
                }
            }
        }

        public void fillCornerRectangle(int y, int x, int height, int width, int level, int orientation, int xSize, int ySize)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new CornerTile(orientation, xSize, ySize);
                }
            }
        }

        public void fillHalfCornerRectangle(int y, int x, int height, int width, int level, int orientation)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    zoneMap[level][i, j] = new HalfCorner(orientation);
                }
            }
        }

        public ZoneTile getTile(int y, int x, int level)
        {
            return zoneMap[level][y, x];
        }

        public List<ZoneTile[,]> getZoneMap()
        {
            return zoneMap;
        }

        public void insertObject(int y, int x, int level, ManipulatableObject tileObject)
        {
            zoneMap[level][y, x].insertObject(tileObject);
        }

        public void fillTileWithObject(int y, int x, int level, ManipulatableObject tileObject)
        {
            zoneMap[level][y, x].fillTile(tileObject);
        }
    }
}
