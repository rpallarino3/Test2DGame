using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Environment
{
    class TestZoneFactory
    {

        private Zone testZone;
        private Zone testCave;

        public TestZoneFactory()
        {
            createZones();
        }

        private void createZones()
        {

            testZone = new TestZone(50, 50);
            testCave = new TestCave(30, 20);
            testZone.getTransitionZones().Add(testCave);
            testZone.getTransitionPoints().Add(new Point(450, 350));
            testCave.getTransitionZones().Add(testZone);
            testCave.getTransitionPoints().Add(new Point(1300, 50));
        }

        public Zone getTestZone()
        {
            return testZone;
        }

        public Zone getTestCave()
        {
            return testCave;
        }
    }
}
