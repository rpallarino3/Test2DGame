using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment
{
    abstract class ZoneTile
    {
        public readonly int UP = 0;
        public readonly int DOWN = 1;
        public readonly int RIGHT = 2;
        public readonly int LEFT = 3;

        public readonly int FREE = 0;
        public readonly int GAP = 1;
        public readonly int IMPASSABLE = 2;
        public readonly int EGDE = 3;
        public readonly int ANGULAR_CORNER = 4;
        public readonly int RECTANGULAR_CORNER = 5;
        public readonly int CORNER = 6;
        public readonly int HALF_CORNER = 7;

        protected int type;

        protected int[,] pixels;

        protected bool free;
        protected bool full;
        protected bool pushable;
        protected bool jumpable;
        protected ManipulatableObject tileObject;

        public abstract bool checkTile(Vector2 location, int direction);

        public int checkPixel(int y, int x)
        {
            return pixels[y, x];
        }

        public void setPixel(int y, int x, int value)
        {
            pixels[y, x] = value;
        }

        public void setPixelRectangle(int y, int x, int height, int width, int value)
        {
            for (int i = y; i < y + height; i++)
            {
                for (int j = x; j < x + width; j++)
                {
                    pixels[i, j] = value;
                }
            }
        }

        public int getType()
        {
            return type;
        }

        public int[,] getPixels()
        {
            return pixels;
        }

        public bool isFree()
        {
            return free;
        }

        public bool isFull()
        {
            return full;
        }

        public bool isPushable()
        {
            return pushable;
        }

        public bool isJumpable()
        {
            return jumpable;
        }

        public ManipulatableObject getTileObject()
        {
            return tileObject;
        }

        public bool isObject()
        {
            if (tileObject != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract void fillTile(ManipulatableObject enteringObject);
        public abstract void insertObject(ManipulatableObject enteringObject);
        public abstract void freeTile();
    }
}
