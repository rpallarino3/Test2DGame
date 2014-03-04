using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunGame.Game.PlayerStuff;
using FunGame.Game.Environment;

using Microsoft.Xna.Framework;

namespace FunGame.Game.KeyHandlers
{
    class MovementHandler
    {

        private GameInit gameInit;
        private TransitionHandler transitionHandler;

        public MovementHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            transitionHandler = new TransitionHandler(gameInit);
        }

        public void movePlayerUp(Player player, ZoneFactory zoneFactory)
        {
            player.moveUp(checkUpCollision(player, zoneFactory.getCurrentZone()));
            updateDrawLocations(player, zoneFactory.getCurrentZone());
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkUpCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X, player.getGlobalLocation().Y - player.getMoveSpeed());
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y, (int)startingCollision.X + j] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y, (int)startingCollision.X + j] == true)
                {
                    if (i < player.getMoveSpeed())
                    {
                        startingCollision.Y++;
                        i++;
                        j = 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return player.getMoveSpeed() - i;
        }

        public void movePlayerLeft(Player player, ZoneFactory zoneFactory)
        {
            player.moveLeft(checkLeftCollision(player, zoneFactory.getCurrentZone()));
            updateDrawLocations(player, zoneFactory.getCurrentZone());
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkLeftCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X - player.getMoveSpeed(), player.getGlobalLocation().Y);
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y + j, (int)startingCollision.X] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y + j, (int)startingCollision.X] == true)
                {
                    if (i < player.getMoveSpeed())
                    {
                        startingCollision.X++;
                        i++;
                        j = 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return player.getMoveSpeed() - i;
        }

        public void movePlayerDown(Player player, ZoneFactory zoneFactory)
        {
            player.moveDown(checkDownCollision(player, zoneFactory.getCurrentZone()));
            updateDrawLocations(player, zoneFactory.getCurrentZone());
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkDownCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X, player.getGlobalLocation().Y + 29 + player.getMoveSpeed());
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y, (int)startingCollision.X + j] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y, (int)startingCollision.X + j] == true)
                {
                    if (i < player.getMoveSpeed())
                    {
                        startingCollision.Y--;
                        i++;
                        j = 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return player.getMoveSpeed() - i;
        }

        public void movePlayerRight(Player player, ZoneFactory zoneFactory)
        {
            player.moveRight(checkRightCollision(player, zoneFactory.getCurrentZone()));
            updateDrawLocations(player, zoneFactory.getCurrentZone());
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkRightCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X + 29 + player.getMoveSpeed(), player.getGlobalLocation().Y);
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y + j, (int)startingCollision.X] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y + j, (int)startingCollision.X] == true)
                {
                    if (i < player.getMoveSpeed())
                    {
                        startingCollision.X--;
                        i++;
                        j = 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return player.getMoveSpeed() - i;
        }


        public void updateDrawLocations(Player player, Zone currentZone)
        {
            float playerDrawLocationX;
            float playerDrawLocationY;
            float zoneDrawLocationX;
            float zoneDrawLocationY;

            if (player.getGlobalLocation().X + player.getXOffset() >= 450 && player.getGlobalLocation().X + player.getXOffset() < currentZone.getWidth() - 450)
            {
                playerDrawLocationX = 450 - player.getXOffset();
                zoneDrawLocationX = -(player.getGlobalLocation().X + player.getXOffset()) + 450;
            }
            else
            {
                if (player.getGlobalLocation().X + player.getXOffset() < 450)
                {
                    playerDrawLocationX = player.getGlobalLocation().X;
                    zoneDrawLocationX = 0;
                }
                else
                {
                    playerDrawLocationX = 900 - (currentZone.getWidth() - player.getGlobalLocation().X);
                    zoneDrawLocationX = -currentZone.getWidth() + 900;
                }
            }

            if (player.getGlobalLocation().Y + player.getYOffset() >= 300 && player.getGlobalLocation().Y + player.getYOffset() < currentZone.getHeight() - 300) // add in the image height stuff
            {
                playerDrawLocationY = 300 - player.getYOffset() - player.getDrawOffsetY();
                zoneDrawLocationY = -(player.getGlobalLocation().Y + player.getYOffset()) + 300;
            }
            else
            {
                if (player.getGlobalLocation().Y + player.getYOffset() < 300)
                {
                    playerDrawLocationY = player.getGlobalLocation().Y - player.getDrawOffsetY();
                    zoneDrawLocationY = 0;
                }
                else
                {
                    playerDrawLocationY = 600 - (currentZone.getHeight() - player.getGlobalLocation().Y + player.getDrawOffsetY());
                    zoneDrawLocationY = -currentZone.getHeight() + 600;
                }
            }

            player.setDrawLocation(new Vector2(playerDrawLocationX, playerDrawLocationY));
            currentZone.setDrawLocation(new Vector2(zoneDrawLocationX, zoneDrawLocationY));
        }

    }
}
