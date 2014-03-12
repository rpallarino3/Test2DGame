using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace FunGame.Game.NPCStuff
{
    class TrafficMap
    {

        private bool[,] trafficMap;
        private NPC[,] npcMap;
        private int mapHeight;
        private int mapWidth;

        public TrafficMap(int height, int width)
        {
            mapHeight = height;
            mapWidth = width;

            trafficMap = new bool[mapHeight, mapWidth];
            npcMap = new NPC[mapHeight, mapWidth];

            fillMapWithFalse();
        }

        private void fillMapWithFalse()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    trafficMap[i, j] = false;
                }
            }
        }

        public void fillRectangle(bool isNPC, int y, int x, int height, int width)
        {
            for (int i = y; i < height + y; i++)
            {
                for (int j = x; j < width + x; j++)
                {
                    fillLocation(isNPC, i, j);
                }
            }
        }

        public void fillLocation(bool isNPC, int y, int x)
        {
            trafficMap[y, x] = isNPC;
        }

        public void insertNPC(NPC npc)
        {
            Vector2 global = npc.getCurrentLocation();
            fillRectangle(true, (int)global.Y, (int)global.X, npc.getHeight(), npc.getWidth());
            for (int i = (int) global.Y - npc.getYOffset(); i < npc.getHeight(); i++)
            {
                for (int j = (int)global.X; j < npc.getWidth(); j++)
                {
                    insertNPCAtLocation(npc, i, j);
                }
            }
        }

        public void insertNPCAtLocation(NPC npc, int y, int x)
        {
            npcMap[y, x] = npc;
        }

        public int getMapHeight()
        {
            return mapHeight;
        }

        public int getMapWidth()
        {
            return mapWidth;
        }

        public bool[,] getTrafficMap()
        {
            return trafficMap;
        }

        public NPC[,] getNPCMap()
        {
            return npcMap;
        }
    }
}
