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
            int transNum = isTransition(player, zoneFactory.getCurrentZone());
            if (transNum != 0 && transNum != 1)
            {
                transitionZones(player, zoneFactory, zoneFactory.getCurrentZone().getZoneNumber(), transNum);
            }
        }

        private int isTransition(Player player, Zone currentZone)
        {
            Vector2 location = player.getGlobalLocation();

            for (int i = 0; i < player.getSize().X; i++)
            {
                for (int j = 0; j < player.getMoveSpeed(); j++)
                {
                    int xPos = ((int)location.X + i) / 30;
                    int yPos = ((int)location.Y + j) / 30;
                    int xOff = ((int)location.X + i) % 30;
                    int yOff = ((int)location.Y + j) % 30;

                    int transNum = currentZone.getZoneTileMap().getTile(yPos, xPos, player.getCurrentZoneLevel()).checkPixel(yOff, xOff);

                    if (transNum > 1)
                    {
                        //Console.WriteLine("xPos: " + xPos + " yPos: " + yPos);
                        return transNum;
                    }

                }
            }

            for (int i = 0; i < (player.getSize().Y - player.getMoveSpeed()); i++)
            {
                for (int j = 0; j < player.getMoveSpeed(); j++)
                {
                    int xPos = ((int)location.X + j) / 30;
                    int yPos = ((int)location.Y + i + player.getMoveSpeed()) / 30;
                    int xOff = ((int)location.X + j) % 30;
                    int yOff = ((int)location.Y + i + player.getMoveSpeed()) % 30;

                    int transNum = currentZone.getZoneTileMap().getTile(yPos, xPos, player.getCurrentZoneLevel()).checkPixel(yOff, xOff);

                    if (transNum > 1)
                    {
                        Console.WriteLine(player.getGlobalLocation());
                        Console.WriteLine("xPos: " + xPos + " yPos: " + yPos);
                        Console.WriteLine("xOff: " + xOff + " yOff: " + yOff);
                        Console.WriteLine(i);
                        return transNum;
                    }
                }
            }

            for (int i = 0; i < player.getSize().Y - player.getMoveSpeed(); i++)
            {
                for (int j = 0; j < player.getMoveSpeed(); j++)
                {
                    int xPos = ((int)location.X + (int)player.getSize().X - player.getMoveSpeed() + j) / 30;
                    int yPos = ((int)location.Y + i + player.getMoveSpeed()) / 30;
                    int xOff = ((int)location.X + (int)player.getSize().X - player.getMoveSpeed() + j) % 30;
                    int yOff = ((int)location.Y + i + player.getMoveSpeed()) % 30;

                    int transNum = currentZone.getZoneTileMap().getTile(yPos, xPos, player.getCurrentZoneLevel()).checkPixel(yOff, xOff);

                    if (transNum > 1)
                    {
                        //Console.WriteLine("xPos: " + xPos + " yPos: " + yPos);
                        return transNum;
                    }
                }
            }

            for (int i = 0; i < player.getSize().X - player.getMoveSpeed() - player.getMoveSpeed(); i++)
            {
                for (int j = 0; j < player.getMoveSpeed(); j++)
                {
                    int xPos = ((int)location.X + player.getMoveSpeed() + i) / 30;
                    int yPos = ((int)location.Y + (int)player.getSize().Y - player.getMoveSpeed() + j) / 30;
                    int xOff = ((int)location.X + player.getMoveSpeed() + i) % 30;
                    int yOff = ((int)location.Y + (int)player.getSize().Y - player.getMoveSpeed() + j) % 30;

                    int transNum = currentZone.getZoneTileMap().getTile(yPos, xPos, player.getCurrentZoneLevel()).checkPixel(yOff, xOff);

                    if (transNum > 1)
                    {
                        //Console.WriteLine("xPos: " + xPos + " yPos: " + yPos);
                        return transNum;
                    }
                }
            }

            return 0;
        }

        private void transitionZones(Player player, ZoneFactory zoneFactory, int zoneNumber, int transitionNumber) // need to work on this stuff
        {
            Console.WriteLine("transitioning");
            Console.WriteLine(transitionNumber);
            switch (zoneNumber)
            {
                case -1:
                    break;
                case -2:
                    break;
                case -3:
                    break;
                case -4:
                    testTileZoneTransition(player, zoneFactory, transitionNumber);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
            gameInit.getPaintHandler().updateZoneImages(gameInit.getContentHandler().getZoneContentHandler().getZoneImages()[zoneFactory.getCurrentZone().getZoneNumber()]);
            gameInit.getKeyHandler().getMovementHandler().updateDrawLocations(player, zoneFactory.getCurrentZone());
        }

        private void testTileZoneTransition(Player player, ZoneFactory zoneFactory, int transitionNumber)
        {
            Zone currentZone;
            switch (transitionNumber)
            {
                case 2:
                    player.upOneLevel();
                    break;
                case 3:
                    player.downOneLevel();
                    break;
                default:
                    break;
            }
        }
    }
}
