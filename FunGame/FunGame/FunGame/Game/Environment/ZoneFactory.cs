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

        public ZoneFactory()
        {

            testZoneFactory = new TestZoneFactory();
            currentZone = testZoneFactory.getTestZone();
        }

        public Zone getCurrentZone()
        {
            return currentZone;
        }

        public void setCurrentZone(Zone newCurrentZone)
        {
            currentZone = newCurrentZone;
        }
    }
}
