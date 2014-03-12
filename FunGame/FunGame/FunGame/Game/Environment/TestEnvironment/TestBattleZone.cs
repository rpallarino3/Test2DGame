using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.NPCStuff;
using FunGame.Game.EnemyStuff;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.Environment.TestEnvironment
{
    class TestBattleZone : Zone
    {

        private CollisionMap level1;
        private TransitionMap level1Trans;
        private TrafficMap level1TrafficMap;
        private EnemyMap level1EnemyMap;

        public TestBattleZone(int width, int height)
        {
            zoneNumber = -3;
            this.width = width;
            this.height = height;
            setDrawLocation(new Vector2(0, 0));
            createLists();

            level1 = new CollisionMap(height, width);
            collisionMap.Add(level1);

            level1Trans = new TransitionMap(height, width);
            transitionMap.Add(level1Trans);

            level1TrafficMap = new TrafficMap(height, width);
            trafficMap.Add(level1TrafficMap);

            level1EnemyMap = new EnemyMap(height, width);
            enemyMap.Add(level1EnemyMap);

            fillLevel1();
            fillLevel1Trans();

            createSpawners();
        }

        private void createLists()
        {
            levels = new List<Texture2D>();
            collisionMap = new List<CollisionMap>();
            transitionMap = new List<TransitionMap>();
            transitionZones = new List<Zone>();
            transitionPoints = new List<Vector2>();
            trafficMap = new List<TrafficMap>();
            npcList = new List<NPC>();
            enemyList = new List<Enemy>();
            spawnerList = new List<EnemySpawner>();
            enemyMap = new List<EnemyMap>();
        }

        private void fillLevel1()
        {
            level1.fillFalseRectangle(0, 0, 1000, 30);
            level1.fillFalseRectangle(970, 30, 30, 940);
            level1.fillFalseRectangle(0, 970, 1000, 30);
            level1.fillFalseRectangle(0, 30, 30, 940);
            level1.fillTrueRectangle(0, 450, 30, 100);
        }

        private void fillLevel1Trans()
        {
            level1Trans.fillRectangle(1, 0, 450, 30, 100);
        }

        private void createSpawners()
        {
            EnemySpawner newSpawn = new EnemySpawner("Test", new Vector2(50, 50), 50, 100, false);
            newSpawn.setZoneLevel(0);
            newSpawn.falseSpawn(newSpawn.TOP_LEFT);
            newSpawn.falseSpawn(newSpawn.TOP);
            newSpawn.falseSpawn(newSpawn.TOP_RIGHT);
            newSpawn.falseSpawn(newSpawn.LEFT);
            newSpawn.falseSpawn(newSpawn.BOTTOM_LEFT);
            spawnerList.Add(newSpawn);

            level1.fillFalseRectangle(50, 50, 100, 50);
        }
    }
}
