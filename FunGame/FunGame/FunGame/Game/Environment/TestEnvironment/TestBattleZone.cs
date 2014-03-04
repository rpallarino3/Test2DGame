using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.NPCandEnemies;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.TestEnvironment
{
    class TestBattleZone : Zone
    {

        private CollisionMap level1;
        private TransitionMap level1Trans;
        private TrafficMap level1TrafficMap;

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

            fillLevel1();
            fillLevel1Trans();
        }

        private void createLists()
        {
            collisionMap = new List<CollisionMap>();
            transitionMap = new List<TransitionMap>();
            transitionZones = new List<Zone>();
            transitionPoints = new List<Vector2>();
            trafficMap = new List<TrafficMap>();
            npcList = new List<NPC>();
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
    }
}
