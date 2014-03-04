using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.NPCandEnemies
{
    class EnemySpawner
    {

        public readonly int TOP_LEFT = 0;
        public readonly int TOP = 1;
        public readonly int TOP_RIGHT = 2;
        public readonly int RIGHT = 3;
        public readonly int BOTTOM_RIGHT = 4;
        public readonly int BOTTOM = 5;
        public readonly int BOTTOM_LEFT = 6;
        public readonly int LEFT = 7;

        private Vector2 location;

        private int width;
        private int height;

        private List<bool> possibleSpawns;

        public EnemySpawner(Vector2 location, int width, int height)
        {
            this.location = location;
            this.width = width;
            this.height = height;

            possibleSpawns = new List<bool>();
            fillTrueSpawns();
        }

        private void fillTrueSpawns()
        {
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
        }

        public bool canSpawn(int index)
        {
            return possibleSpawns[index];
        }

        public void falseSpawn(int index)
        {
            possibleSpawns[index] = false;
        }

        public void trueSpawn(int index)
        {
            possibleSpawns[index] = true;
        }
    }
}
