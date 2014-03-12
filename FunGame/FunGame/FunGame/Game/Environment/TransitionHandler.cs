using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunGame.Game.PlayerStuff;


using Microsoft.Xna.Framework;

namespace FunGame.Game.Environment
{
    class TransitionHandler
    {

        private GameInit gameInit;

        public TransitionHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
        }

        public void checkTransitions(Player player, ZoneFactory zoneFactory)
        {
            Vector2 startingPoint = new Vector2(player.getGlobalLocation().X, player.getGlobalLocation().Y);
            int transNum = isTransition(startingPoint, player, zoneFactory.getCurrentZone());
            if (transNum != 0)
            {
                transitionZones(player, zoneFactory, zoneFactory.getCurrentZone().getZoneNumber(), transNum);
            }
        }

        private int isTransition(Vector2 start, Player player, Zone currentZone)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    int transNum = currentZone.getTransitionMap()[player.getCurrentZoneLevel()].getTransitionMap()[(int)start.Y + i, (int)start.X + j];
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
            Console.WriteLine("transitioning");
            zoneFactory.getCurrentZone().clearEnemies();
            switch (zoneNumber)
            {
                case -1:
                    testZoneTransition(player, zoneFactory, transitionNumber);
                    break;
                case -2:
                    testCaveTransition(player, zoneFactory, transitionNumber);
                    break;
                case -3:
                    testBattleZoneTransition(player, zoneFactory, transitionNumber);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
            gameInit.getPaintHandler().updateZoneImages(gameInit.getContentHandler().getZoneImages()[zoneFactory.getCurrentZone().getZoneNumber()]);
            gameInit.getKeyHandler().getMovementHandler().updateDrawLocations(player, zoneFactory.getCurrentZone());
        }

        private void testZoneTransition(Player player, ZoneFactory zoneFactory, int transitionNumber)
        {
            Zone currentZone;
            switch (transitionNumber)
            {
                case 1:
                    player.upOneLevel();
                    break;
                case 2:
                    player.downOneLevel();
                    break;
                case 3:
                    currentZone = zoneFactory.getCurrentZone();
                    zoneFactory.setCurrentZone(currentZone.getTransitionZones()[0]);
                    player.setGlobalLocation(new Vector2(currentZone.getTransitionPoints()[0].X, currentZone.getTransitionPoints()[0].Y));
                    break;
                case 4:
                    currentZone = zoneFactory.getCurrentZone();
                    zoneFactory.setCurrentZone(currentZone.getTransitionZones()[1]);
                    player.setGlobalLocation(new Vector2(currentZone.getTransitionPoints()[1].X, currentZone.getTransitionPoints()[1].Y));
                    break;
                default:
                    break;
            }
        }

        private void testCaveTransition(Player player, ZoneFactory zoneFactory, int transitionNumber)
        {
            Zone currentZone;
            switch (transitionNumber)
            {
                case 1:
                    currentZone = zoneFactory.getCurrentZone();
                    zoneFactory.setCurrentZone(currentZone.getTransitionZones()[0]);
                    player.setGlobalLocation(new Vector2(currentZone.getTransitionPoints()[0].X, currentZone.getTransitionPoints()[0].Y));
                    break;
                default:
                    break;
            }
        }

        private void testBattleZoneTransition(Player player, ZoneFactory zoneFactory, int transitionNumber)
        {
            Zone currentZone;
            switch (transitionNumber)
            {
                case 1:
                    currentZone = zoneFactory.getCurrentZone();
                    zoneFactory.setCurrentZone(currentZone.getTransitionZones()[0]);
                    player.setGlobalLocation(new Vector2(currentZone.getTransitionPoints()[0].X, currentZone.getTransitionPoints()[0].Y));
                    break;
                default:
                    break;
            }
        }
    }
}
