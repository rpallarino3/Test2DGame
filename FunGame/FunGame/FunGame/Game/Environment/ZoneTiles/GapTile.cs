using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.ZoneTiles
{
    class GapTile : ZoneTile
    {

        private int[,] fullPixels;
        private int[,] freePixels;

        public GapTile() {
            pixels = new int[30, 30];
            fullPixels = new int[30, 30];
            freePixels = new int[30, 30];

            free = false;
            full = false;
            pushable = false; // maybe can push and object falls down
            jumpable = true;
            type = 1;
            fillPixels();
        }

        private void fillPixels()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    fullPixels[i, j] = 1;
                    freePixels[i, j] = 0;
                }
            }
            pixels = fullPixels;
        }

        public override bool checkTile(Vector2 location, int direction)
        {
            return false;
        }
        public override void fillTile(ManipulatableObject enteringObject)
        {
            tileObject = enteringObject;
            full = true;
            free = false;
            pixels = fullPixels;
        }

        public override void freeTile()
        {
            tileObject = null;
            full = false;
            free = true;
            pixels = fullPixels;
        }

        public override void insertObject(ManipulatableObject enteringObject)
        {
            tileObject = enteringObject;
            pixels = freePixels;
            full = true;
        }
    }
}
