using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunGame.Game.NPCStuff;
using FunGame.Game.EnemyStuff;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.Environment
{
    abstract class Zone
    {

        protected int width;
        protected int height;
        protected int zoneNumber;
        protected List<Texture2D> levels;
        protected List<CollisionMap> collisionMap;
        protected List<TransitionMap> transitionMap;
        protected List<Zone> transitionZones; // maybe combine these 2
        protected List<Vector2> transitionPoints;
        protected List<TrafficMap> trafficMap;
        protected List<NPC> npcList;
        protected List<Enemy> enemyList;
        protected List<EnemySpawner> spawnerList;
        protected List<EnemyMap> enemyMap;
        protected Vector2 drawLocation;

        public List<Texture2D> getLevels()
        {
            return levels;
        }

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

        public List<EnemySpawner> getEnemySpawners()
        {
            return spawnerList;
        }

        public List<EnemyMap> getEnemyMap()
        {
            return enemyMap;
        }

        public List<NPC> getNPCs()
        {
            return npcList;
        }

        public List<Enemy> getEnemies()
        {
            return enemyList;
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

        public void clearEnemies()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                Enemy currentEnemy = enemyList[i];
                int level = currentEnemy.getCurrentZoneLevel();

                enemyMap[level].removeEnemy(currentEnemy);
            }
            enemyList.Clear();

            for (int i = 0; i < spawnerList.Count; i++)
            {
                spawnerList[i].resetSpawnNumber();
            }
        }
    }
}
