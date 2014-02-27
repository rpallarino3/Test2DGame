using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NPCandEnemies;

namespace Environment
{
    abstract class Zone
    {
        
        protected int tileHeight;
        protected int tileWidth;
        protected int zoneNumber;
        protected List<Image> levels;
        protected List<CollisionMap> collisionMap;
        protected List<TransitionMap> transitionMap;
        protected List<Zone> transitionZones; // maybe combine these 2
        protected List<Point> transitionPoints;
        protected List<TrafficMap> trafficMap;
        protected List<NPC> npcList;

        public List<Image> getLevels()
        {
            return levels;
        }

        public int getWidth()
        {
            return tileWidth * 30;
        }

        public int getHeight()
        {
            return tileHeight * 30;
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

        public List<Point> getTransitionPoints()
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

    }
}
