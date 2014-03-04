using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment.TestEnvironment
{
    class TestZoneFactory
    {

        private Zone testZone;
        private Zone testCave;
        private Zone testBattleZone;

        public TestZoneFactory()
        {
            createZones();
        }

        private void createZones()
        {

            testZone = new TestZone(1500, 1500);
            testCave = new TestCave(900, 600);
            testBattleZone = new TestBattleZone(1000, 1000);
            testZone.getTransitionZones().Add(testCave);
            testZone.getTransitionPoints().Add(new Vector2(450, 350));
            testZone.getTransitionZones().Add(testBattleZone);
            testZone.getTransitionPoints().Add(new Vector2(500, 60));
            testCave.getTransitionZones().Add(testZone);
            testCave.getTransitionPoints().Add(new Vector2(1300, 50));
            testBattleZone.getTransitionZones().Add(testZone);
            testBattleZone.getTransitionPoints().Add(new Vector2(925, 1400));
        }

        public Zone getTestZone()
        {
            return testZone;
        }

        public Zone getTestCave()
        {
            return testCave;
        }

        public Zone getTestBattleZone()
        {
            return testBattleZone;
        }
    }
}
