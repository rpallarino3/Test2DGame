using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunGame.Game.NPCandEnemies;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment
{
    abstract class Zone
    {

        protected int width;
        protected int height;
        protected int zoneNumber;
        //protected List<Image> levels;
        protected List<CollisionMap> collisionMap;
        protected List<TransitionMap> transitionMap;
        protected List<Zone> transitionZones; // maybe combine these 2
        protected List<Vector2> transitionPoints;
        protected List<TrafficMap> trafficMap;
        protected List<NPC> npcList;
        protected Vector2 drawLocation;

        //public List<Image> getLevels()
        //{
        //    return levels;
        //}

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public List<CollisionMap> getCollisionMap()
        {
            return collisionMap;
        }

        public List<TransitionMap> getTransitionMap()
        {
            return transitionMap;
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

        public List<TrafficMap> getTrafficMap()
        {
            return trafficMap;
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

        public Vector2 getDrawLocation()
        {
            return drawLocation;
        }

        public void setDrawLocation(Vector2 location)
        {
            drawLocation = location;
        }

    }
}
