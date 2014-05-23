using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunGame.Game.Environment.TestEnvironment;
using FunGame.Game.ContentHandlers;


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

        public void loadZones(ContentHandler content, int zoneNumber)
        {
            if (zoneNumber < 0)
            {
                testZoneFactory.loadZones(content);
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
                case -4:
                    currentZone = testZoneFactory.getTestTileZone();
                    break;
                default:
                    break;
            }
        }
    }
}
