using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.ZoneTiles
{
    class HalfCorner : ZoneTile
    {
        public readonly int UPPER_LEFT = 0;
        public readonly int UPPER_RIGHT = 1;
        public readonly int LOWER_RIGHT = 2;
        public readonly int LOWER_LEFT = 3;

        private int orientation;

        public HalfCorner(int orientation)
        {
            pixels = new int[30, 30];
            this.orientation = orientation;

            free = false;
            full = false;
            pushable = false;
            jumpable = false;
            type = 7;
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
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 30 - i; j++)
                    {
                        pixels[i, j] = 1;
                    }
                }
            }
            else if (orientation == UPPER_RIGHT)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
            else if (orientation == LOWER_RIGHT)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 29; j >= 29 - i; j--)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
            else if (orientation == LOWER_LEFT)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 29; j >= i; j--)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
        }

        public override bool checkTile(Vector2 location, int direction)
        {
            int xPos = (int)location.X % 30;
            int yPos = (int)location.Y % 30;

            if (direction == UP)
            {
                if (orientation == UPPER_LEFT)
                {
                }
                else if (orientation == UPPER_RIGHT)
                {
                }
                else if (orientation == LOWER_RIGHT)
                {
                }
                else if (orientation == LOWER_LEFT)
                {
                }
            }
            else if (direction == DOWN)
            {
                if (orientation == UPPER_LEFT)
                {
                }
                else if (orientation == UPPER_RIGHT)
                {
                }
                else if (orientation == LOWER_RIGHT)
                {
                }
                else if (orientation == LOWER_LEFT)
                {
                }
            }
            else if (direction == RIGHT)
            {
                if (orientation == UPPER_LEFT)
                {
                }
                else if (orientation == UPPER_RIGHT)
                {
                }
                else if (orientation == LOWER_RIGHT)
                {
                }
                else if (orientation == LOWER_LEFT)
                {
                }
            }
            else if (direction == LEFT)
            {
                if (orientation == UPPER_LEFT)
                {
                }
                else if (orientation == UPPER_RIGHT)
                {
                }
                else if (orientation == LOWER_RIGHT)
                {
                }
                else if (orientation == LOWER_LEFT)
                {
                }
            }
            return false;
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
