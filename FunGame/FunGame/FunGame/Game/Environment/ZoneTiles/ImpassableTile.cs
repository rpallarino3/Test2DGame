using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.ZoneTiles
{
    class ImpassableTile : ZoneTile
    {

        public ImpassableTile()
        {
            pixels = new int[30, 30];
            type = 2;

            free = false;
            full = false;
            pushable = false;
            jumpable = false;
            fillPixels();
        }

        private void fillPixels()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    pixels[i, j] = 1;
                }
            }
        }

        public override bool checkTile(Vector2 location, int direction)
        {
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
