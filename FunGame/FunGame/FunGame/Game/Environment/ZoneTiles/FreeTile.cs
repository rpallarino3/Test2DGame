using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.ZoneTiles
{
    class FreeTile : ZoneTile
    {
        private readonly int VERTICAL = 0;
        private readonly int HORIZONTAL = 1;

        private int[,] fullPixels;
        private int[,] freePixels;
        private int[,] npcPixels;

        private int npcDistance;

        public FreeTile()
        {

            pixels = new int[30, 30];
            npcPixels = new int[30, 30];
            fullPixels = new int[30, 30];
            freePixels = new int[30, 30];
            type = 0;
            full = false;
            free = true;
            pushable = true;
            jumpable = false;
            fillPixels();
        }

        private void fillPixels()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    npcPixels[i, j] = 0;
                    fullPixels[i, j] = 1;
                    freePixels[i, j] = 0;
                }
            }
            pixels = freePixels;
        }

        public void fillFreeTile()
        {
            full = true;
            pixels = fullPixels;
        }

        public void freeFreeTile()
        {
            full = false;
            pixels = freePixels;
        }

        public override bool checkTile(Vector2 location, int direction)
        {
            return !full;
        }

        public override void fillTile(ManipulatableObject enteringObject)
        {
            tileObject = enteringObject;
            full = true;
            free = false;
            pixels = fullPixels;
            jumpable = false;
        }

        public override void insertObject(ManipulatableObject enteringObject)
        {
            tileObject = enteringObject;
            if (tileObject.isJumpable())
            {
                jumpable = true;
            }
            else
            {
                jumpable = false;
            }
        }

        public override void freeTile()
        {
            tileObject = null;
            full = false;
            free = true;
            pixels = freePixels;
            jumpable = false;
        }

        public void moveNPCIn(int distance, int direction)
        {
            free = false;
            npcDistance += distance;
            if (direction == 0)
            {
                for (int i = 0; i < distance; i++)
                {
                    flagRow(1, npcDistance - i - 1);
                }
            }
            else if (direction == 1)
            {
                for (int i = 0; i < distance; i++)
                {
                    flagRow(1, 30 - npcDistance + i);
                };
            }
            else if (direction == 2)
            {
                for (int i = 0; i < distance; i++)
                {
                    flagRow(0, 30 - npcDistance + i);
                }
            }
            else if (direction == 3)
            {
                for (int i = 0; i < distance; i++)
                {
                    flagRow(0, npcDistance - i - 1);
                }
            }

        }

        public void moveNPCOut(int distance, int direction)
        {
            npcDistance -= distance;

            if (direction == 0)
            {
                for (int i = 0; i < distance; i++)
                {
                    nullRow(1, npcDistance + i);
                }
            }
            else if (direction == 1)
            {
                for (int i = 0; i < distance; i++)
                {
                    nullRow(1, 30 - distance + i);
                }
            }
            else if (direction == 2)
            {
                for (int i = 0; i < distance; i++)
                {
                    nullRow(0, 30 - distance + i);
                }
            }
            else if (direction == 3)
            {
                for (int i = 0; i < distance; i++)
                {
                    nullRow(0, npcDistance + i);
                }
            }

            if (npcDistance == 0)
            {
                removeNPC();
            }
        }

        private void nullRow(int orientation, int distance)
        {
            if (orientation == VERTICAL)
            {
                for (int i = 0; i < 30; i++)
                {
                    npcPixels[distance, i] = 0;
                }
            }
            else if (orientation == HORIZONTAL)
            {
                for (int i = 0; i < 30; i++)
                {
                    npcPixels[i, distance] = 0;
                }
            }
        }

        private void flagRow(int orientation, int distance)
        {
            if (orientation == VERTICAL)
            {
                for (int i = 0; i < 30; i++)
                {
                    npcPixels[distance, i] = 1;
                }
            }
            else if (orientation == HORIZONTAL)
            {
                for (int i = 0; i < 30; i++)
                {
                    npcPixels[i, distance] = 1;
                }
            }
        }

        private void fillNPC()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    npcPixels[i, j] = 1;
                }
            }
        }

        public void insertNPC()
        {
            free = false;
            fillNPC();
            pixels = npcPixels;
            npcDistance = 30;
        }

        public void removeNPC()
        {
            free = true;
            pixels = freePixels;
        }
    }
}
