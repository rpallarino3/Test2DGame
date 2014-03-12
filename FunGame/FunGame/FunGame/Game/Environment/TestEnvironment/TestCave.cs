using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunGame.Game.NPCStuff;
using FunGame.Game.EnemyStuff;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.Environment.TestEnvironment
{
    class TestCave : Zone
    {

        private CollisionMap level1;

        private TransitionMap level1Trans;

        private TrafficMap level1TrafficMap;
        private EnemyMap level1EnemyMap;

        public TestCave(int width, int height)
        {
            zoneNumber = -2;
            this.width = width;
            this.height = height;
            setDrawLocation(new Vector2(0, 0));
            createLists();
            //levels.Add(Image.FromFile("../../../Images/Zones/TestCave.png"));
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
            level1.fillFalseRectangle(150, 200, 300, 30);
            level1.fillFalseRectangle(150, 230, 30, 440);
            level1.fillFalseRectangle(150, 670, 300, 30);
            level1.fillFalseRectangle(420, 230, 30, 440);
            level1.fillTrueRectangle(420, 425, 1, 50);
        }

        private void fillLevel1Trans()
        {
            level1Trans.fillRectangle(1, 420, 435, 1, 30);
        }

    }
}
