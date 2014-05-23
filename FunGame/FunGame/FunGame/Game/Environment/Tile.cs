using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGame.Game.Environment
{
    class Tile
    {

        private Pixel[,] pixelMap;

        private int height;
        private bool free;
        private bool full;
        private bool push;

        public Tile(int height)
        {

            this.height = height;
            pixelMap = new Pixel[height, height];
            free = true;
            full = false;
            push = true;
            fillMap();
        }

        private void fillMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pixelMap[i, j] = new Pixel();
                }
            }
        }

        public Pixel getPixel(int y, int x)
        {
            return pixelMap[y, x];
        }

        public void notFree()
        {
            free = false;
        }

        public void tileFree()
        {
            free = true;
        }

        public void fillTile()
        {
            Console.WriteLine("Filling tile");
            free = false;
            full = true;
        }

        public void freeTile()
        {
            Console.WriteLine("Freeing tile");
            free = true;
            full = false;
        }

        public bool isFree()
        {
            return free;
        }

        public bool isFull()
        {
            return full;
        }

        public bool canPush()
        {
            return push;
        }
        
    }
}
