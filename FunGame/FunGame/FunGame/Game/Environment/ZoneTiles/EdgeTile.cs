using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.ZoneTiles
{
    class EdgeTile : ZoneTile
    {
        public readonly int VERTICAL = 0;
        public readonly int HORIZONTAL = 1;

        private int orientation;
        private int distance;
        private int thickness;

        public EdgeTile(int orientation, int distance, int thickness)
        {
            pixels = new int[30, 30];

            this.orientation = orientation;
            this.distance = distance;
            this.thickness = thickness;

            type = 3;
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

            if (orientation == VERTICAL)
            {
                for (int i = distance; i < distance + thickness; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        pixels[j, i] = 1;
                    }
                }
            }
            else if (orientation == HORIZONTAL)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = distance; j < distance + thickness; j++)
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

            if (direction == UP)
            {
                if (orientation == VERTICAL)
                {
                    int i = 0;
                    while (i < 30)
                    {
                        if (xLoc + i >= distance && xLoc + i <= distance + thickness)
                        {
                            return false;
                        }
                        else
                        {
                            i += thickness;
                        }
                    }
                    return true;
                }
                else if (orientation == HORIZONTAL)
                {
                    if (yLoc >= distance && yLoc <= distance + thickness)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (direction == DOWN)
            {
                if (orientation == VERTICAL)
                {
                    int i = 0;
                    while (i < 30)
                    {
                        if (xLoc + i >= distance && xLoc + i <= distance + thickness)
                        {
                            return false;
                        }
                        else
                        {
                            i += thickness;
                        }
                    }
                    return true;
                }
                else if (orientation == HORIZONTAL)
                {
                    if (yLoc >= distance && yLoc <= distance + thickness)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (direction == RIGHT)
            {
                if (orientation == VERTICAL)
                {
                    if (xLoc >= distance && xLoc <= distance + thickness)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (orientation == HORIZONTAL)
                {
                    int i = 0;
                    while (i < 30)
                    {
                        if (yLoc + i >= distance && yLoc + i <= distance + thickness)
                        {
                            return false;
                        }
                        else
                        {
                            i += thickness;
                        }
                    }
                    return true;
                }
            }
            else if (direction == LEFT)
            {
                if (orientation == VERTICAL)
                {
                    if (xLoc >= distance && xLoc <= distance + thickness)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (orientation == HORIZONTAL)
                {
                    int i = 0;
                    while (i < 30)
                    {
                        if (yLoc + i >= distance && yLoc + i <= distance + thickness)
                        {
                            return false;
                        }
                        else
                        {
                            i += thickness;
                        }
                    }
                    return true;
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
