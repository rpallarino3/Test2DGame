using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunGame.Game.Environment.TestEnvironment;


namespace FunGame.Game.Environment
{
    class ZoneFactory
    {

        private TestZoneFactory testZoneFactory;

        private Zone currentZone;
        private int currentZoneNumber;

        public ZoneFactory()
        {

            testZoneFactory = new TestZoneFactory();
        }

        public Zone getCurrentZone()
        {
            return currentZone;
        }

        public void loadZones(int zoneNumber)
        {
            if (zoneNumber < 0)
            {
                testZoneFactory.loadZones();
            }
        }

        public void setCurrentZone(Zone newCurrentZone)
        {
            currentZone = newCurrentZone;
        }

        public int getCurrentZoneNumber()
        {
            return currentZoneNumber;
        }

        public void setCurrentZoneFromNumber(int zoneNumber)
        {
            currentZoneNumber = zoneNumber;
            switch (zoneNumber)
            {
                case -1:
                    currentZone = testZoneFactory.getTestZone();
                    break;
                case -2:
                    currentZone = testZoneFactory.getTestCave();
                    break;
                case -3:
                    currentZone = testZoneFactory.getTestBattleZone();
                    break;
                default:
                    break;
            }
        }
    }
}
