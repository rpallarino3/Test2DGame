using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.ZoneTiles
{
    class AngularCornerTile : ZoneTile
    {
        public readonly int UPPER_LEFT = 0;
        public readonly int UPPER_RIGHT = 1;
        public readonly int LOWER_RIGHT = 2;
        public readonly int LOWER_LEFT = 3;

        private int orientation;
        private int b;
        private int h;

        public AngularCornerTile(int orientation, int b, int h)
        {
            pixels = new int[30, 30];

            this.orientation = orientation;
            this.b = b;
            this.h = h;

            free = false;
            full = false;
            pushable = false;
            jumpable = false;
            type = 4;
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

        public override bool checkTile(Vector2 location, int direction)
        {
            int xLoc = (int)location.X % 30;
            int yLoc = (int)location.Y % 30;

            if (orientation == UPPER_LEFT)
            {
                if (yLoc <= -(h / b) * xLoc + h)
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
                int c = (h / (-30 + b));

                if (yLoc >= (-c / b) * xLoc + b * c)
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

                int c = (b * h - 900) / (-30 + b);

                if (yLoc >= (30 - c) / b * xLoc + c)
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
                if (yLoc <= ((30 - h) / b) * xLoc + h)
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
