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

        public void checkTransitions(Player player, ZoneFactory zoneFactory)
        {
            Point startingPoint = new Point(player.getGlobalLocation().X, player.getGlobalLocation().Y);
            int transNum = isTransition(startingPoint, player, zoneFactory.getCurrentZone());
            if (transNum != 0)
            {
                transitionZones(player, zoneFactory, zoneFactory.getCurrentZone().getZoneNumber(), transNum);
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

        private void transitionZones(Player player, ZoneFactory zoneFactory, int zoneNumber, int transitionNumber)
        {
            switch (zoneNumber)
            {
                case -1:
                    testZoneTransition(player, zoneFactory, transitionNumber);
                    break;
                case -2:
                    testCaveTransition(player, zoneFactory, transitionNumber);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }

        private void testZoneTransition(Player player, ZoneFactory zoneFactory, int transitionNumber)
        {
            Console.WriteLine(transitionNumber);
            switch (transitionNumber)
            {
                case 1:
                    player.upOneLevel();
                    break;
                case 2:
                    player.downOneLevel();
                    break;
                case 3:
                    Zone currentZone = zoneFactory.getCurrentZone();
                    zoneFactory.setCurrentZone(currentZone.getTransitionZones()[0]);
                    player.setGlobalLocation(currentZone.getTransitionPoints()[0].X, currentZone.getTransitionPoints()[0].Y);
                    break;
                default:
                    break;
            }
        }

        private void testCaveTransition(Player player, ZoneFactory zoneFactory, int transitionNumber)
        {
            Console.WriteLine(transitionNumber);
            switch (transitionNumber)
            {
                case 1:
                    Zone currentZone = zoneFactory.getCurrentZone();
                    zoneFactory.setCurrentZone(currentZone.getTransitionZones()[0]);
                    player.setGlobalLocation(currentZone.getTransitionPoints()[0].X, currentZone.getTransitionPoints()[0].Y);
                    break;
                default:
                    break;
            }
        }
    }
}
