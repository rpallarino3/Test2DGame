using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunGame.Game.NPCStuff;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FunGame.Game.ContentHandlers;

namespace FunGame.Game.Environment
{
    abstract class Zone
    {

        protected readonly int TILE_SIZE = 30;

        protected int tileHeight;
        protected int tileWidth;
        protected int width;
        protected int height;
        protected int zoneNumber;
        protected List<Zone> transitionZones; // maybe combine these 2
        protected List<Vector2> transitionPoints;
        protected List<NPC> npcList;
        protected Vector2 drawLocation;
        protected ZoneTileMap zoneTileMap;
        protected List<ManipulatableObject> objectList;


        public int getTileWidth()
        {
            return tileWidth;
        }

        public int getTileHeight()
        {
            return tileHeight;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public int getZoneNumber()
        {
            return zoneNumber;
        }

        public List<Zone> getTransitionZones()
        {
            return transitionZones;
        }

        public List<Vector2> getTransitionPoints()
        {
            return transitionPoints;
        }

        public List<NPC> getNPCs()
        {
            return npcList;
        }

        public void addNPCtoList(NPC npc)
        {
            npcList.Add(npc);
        }

        public void removeNPCfromList(NPC npc)
        {
            npcList.Remove(npc);
        }

        public ZoneTileMap getZoneTileMap()
        {
            return zoneTileMap;
        }

        public List<ManipulatableObject> getObjectList()
        {
            return objectList;
        }

        public Vector2 getDrawLocation()
        {
            return drawLocation;
        }

        public void setDrawLocation(Vector2 location)
        {
            drawLocation = location;
        }

        public void setStationaryImages(ContentHandler content)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                objectList[i].activate(content, this, "STATIONARY");
            }
        }

        public void setStationaryNPCImages(ContentHandler content)
        {
            for (int i = 0; i < npcList.Count; i++)
            {
                int direction = npcList[i].getFacingDirection();

                if (direction == 0)
                {
                    npcList[i].setNewAnimation(content.getNPCContentHandler().getNPCImages()[npcList[i].getName()]["STATIONARY_UP"]);
                }
                else if (direction == 1)
                {
                    npcList[i].setNewAnimation(content.getNPCContentHandler().getNPCImages()[npcList[i].getName()]["STATIONARY_DOWN"]);
                }
                else if (direction == 2)
                {
                    npcList[i].setNewAnimation(content.getNPCContentHandler().getNPCImages()[npcList[i].getName()]["STATIONARY_RIGHT"]);
                }
                else if (direction == 3)
                {
                    npcList[i].setNewAnimation(content.getNPCContentHandler().getNPCImages()[npcList[i].getName()]["STATIONARY_LEFT"]);
                }
            }
        }
    }
}
