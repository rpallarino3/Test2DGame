using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using FunGame.Game.ContentHandlers;

namespace FunGame.Game.Environment.TestEnvironment
{
    class TestZoneFactory
    {
        private Zone testTileZone;

        public TestZoneFactory()
        {
        }

        public void loadZones(ContentHandler content)
        {
            testTileZone = new TestTileZone(30, 30);
            testTileZone.setStationaryImages(content);
            testTileZone.setStationaryNPCImages(content);
        }

        public Zone getTestTileZone()
        {
            return testTileZone;
        }
    }
}
