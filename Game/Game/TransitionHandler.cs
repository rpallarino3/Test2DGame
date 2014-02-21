using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PlayerStuff;


namespace Environment
{
    class TransitionHandler
    {

        public TransitionHandler()
        {
        }

        public void checkTransitions(Player player, Zone currentZone)
        {
            Point startingPoint = new Point(player.getGlobalLocation().X - 15, player.getGlobalLocation().Y - 15);
            int transNum = isTransition(startingPoint, player, currentZone);
            if (transNum != 0)
            {
                transitionZones(player, currentZone, currentZone.getZoneNumber(), transNum);
            }
        }

        private int isTransition(Point start, Player player, Zone currentZone)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    int transNum = currentZone.getTransitionMap()[player.getCurrentZoneLevel()].getTransitionMap()[start.Y + i, start.X + j];
                    if (transNum != 0)
                    {
                        return transNum;
                    }
                }
            }
            return 0;
        }

        private void transitionZones(Player player, Zone currentZone, int zoneNumber, int transitionNumber)
        {
            switch (zoneNumber)
            {
                case -1:
                    testZoneTransition(player, currentZone, transitionNumber);
                    break;
                case -2:
                    testCaveTransition(player, currentZone, transitionNumber);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }

        private void testZoneTransition(Player player, Zone currentZone, int transitionNumber)
        {
            Console.WriteLine(transitionNumber);
            switch (transitionNumber)
            {
                case 1:
                    player.upOneLevel();
                    break;
                case 3:
                    // need to put all zones into some data structure that is indexed by zone number
                    break;
                default:
                    break;
            }
        }

        private void testCaveTransition(Player player, Zone currentZone, int transitionNumber)
        {
            Console.WriteLine(transitionNumber);
        }
    }
}
