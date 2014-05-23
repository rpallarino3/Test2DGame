using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.ZoneTiles
{
    class RectangularCornerTile : ZoneTile
    {
        public readonly int UPPER_LEFT = 0;
        public readonly int UPPER_RIGHT = 1;
        public readonly int LOWER_RIGHT = 2;
        public readonly int LOWER_LEFT = 3;

        private int orientation;
        private int x;
        private int y;

        public RectangularCornerTile(int orientation, int x, int y)
        {
            pixels = new int[30, 30];

            this.orientation = orientation;
            this.x = x;
            this.y = y;

            free = false;
            full = false;
            pushable = false;
            jumpable = false;
            type = 5;
            fillPixels();
        }

        private void fillPixels()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    pixels[i, j] = 0;
                }
            }
            if (orientation == UPPER_LEFT)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
            else if (orientation == UPPER_RIGHT)
            {
                for (int i = x; i < 30; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
            else if (orientation == LOWER_RIGHT)
            {
                for (int i = x; i < 30; i++)
                {
                    for (int j = y; j < 30; j++)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
            else if (orientation == LOWER_LEFT)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = y; j < 30; j++)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
        }

        public override bool checkTile(Vector2 location, int direction)
        {
            int xLoc = (int)location.X % 30;
            int yLoc = (int)location.Y % 30;

            if (orientation == UPPER_LEFT)
            {
                if (xLoc <= x && yLoc <= y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (orientation == UPPER_RIGHT)
            {
                if (xLoc >= x && yLoc <= y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (orientation == LOWER_RIGHT)
            {
                if (xLoc >= x && yLoc >= y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (xLoc <= x && yLoc >= y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public override void fillTile(ManipulatableObject enteringObject)
        {
        }

        public override void freeTile()
        {
        }

        public override void insertObject(ManipulatableObject enteringObject)
        {
        }
    }
}
