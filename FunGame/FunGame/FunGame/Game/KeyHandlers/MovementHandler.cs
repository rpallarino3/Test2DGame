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

        private int upDistance;
        private int downDistance;
        private int rightDistance;
        private int leftDistance;

        private bool leftFlag;
        private bool rightFlag;
        private bool upFlag;
        private bool downFlag;

        private bool bump;

        public MovementHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            transitionHandler = new TransitionHandler(gameInit);
            bump = false;

            upDistance = 0;
            downDistance = 0;
            rightDistance = 0;
            leftDistance = 0;

            leftFlag = false;
            rightFlag = false;
            upFlag = false;
            downFlag = false;
        }

        public void resetDistances()
        {
            upDistance = 0;
            downDistance = 0;
            rightDistance = 0;
            leftDistance = 0;
        }

        public void resetFlags()
        {
            upFlag = false;
            downFlag = false;
            rightFlag = false;
            leftFlag = false;
        }

        public bool pushTest() // an issue with this that may or may not need fixing, you can push while sliding by removing embedded ifs
        {
            if (upDistance == 0 && gameInit.getPlayer().getFacingDirection() == 0 && upFlag)
            {
                if (!leftFlag && !rightFlag)
                {
                    return true;
                }
            }
            if (downDistance == 0 && gameInit.getPlayer().getFacingDirection() == 1 && downFlag)
            {
                if (!leftFlag && !rightFlag)
                {
                    return true;
                }
            }
            if (rightDistance == 0 && gameInit.getPlayer().getFacingDirection() == 2 && rightFlag)
            {
                if (!upFlag && !downFlag)
                {
                    return true;
                }
            }
            if (leftDistance == 0 && gameInit.getPlayer().getFacingDirection() == 3 && leftFlag)
            {
                if (!upFlag && !downFlag)
                {
                    return true;
                }
            }
            return false;
        }

        public void movePlayer(int direction, Player player, ZoneFactory zoneFactory)
        {
            if (direction == 0)
            {
                upFlag = true;
                player.moveUp(checkCollision(player.getMoveSpeed(), direction, player, zoneFactory.getCurrentZone()));
            }
            else if (direction == 1)
            {
                downFlag = true;
                player.moveDown(checkCollision(player.getMoveSpeed(), direction, player, zoneFactory.getCurrentZone()));
            }
            else if (direction == 2)
            {
                rightFlag = true;
                player.moveRight(checkCollision(player.getMoveSpeed(), direction, player, zoneFactory.getCurrentZone()));
            }
            else if (direction == 3)
            {
                leftFlag = true;
                player.moveLeft(checkCollision(player.getMoveSpeed(), direction, player, zoneFactory.getCurrentZone()));
            }
            updateDrawLocations(player, zoneFactory.getCurrentZone());
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkCollision(int distance, int direction, Player player, Zone currentZone)
        {
            Vector2 startingPoint;

            if (direction == 0)
            {
                startingPoint = player.getGlobalLocation();

                int i = 0;
                
                while (i <= distance)
                {
                    i += 2;

                    if (!bump)
                    {
                        int leftCol = 0;
                        int centerCol = 0;
                        int rightCol = 0;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X + j) / 30;
                            int yTile = ((int)startingPoint.Y - i) / 30;

                            if ((int)startingPoint.Y - i < 0)
                            {
                                upDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X + j) % 30;
                            int yOffset = ((int)startingPoint.Y - i) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                if (j < 14)
                                {
                                    leftCol++;
                                }
                                else if (j >= 16)
                                {
                                    rightCol++;
                                }
                                else
                                {
                                    centerCol++;
                                }
                            }
                        }

                        if (leftCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveRight(checkCollision(2, 2, player, currentZone));
                            upDistance += (i - 2);
                            return i - 2;
                        }
                        else if (rightCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveLeft(checkCollision(2, 3, player, currentZone));
                            upDistance += (i - 2);
                            return i - 2;
                        }
                        else if (centerCol > 0)
                        {
                            upDistance += (i - 2);
                            return i - 2;
                        }
                    }
                    else
                    {
                        bump = false;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X + j) / 30;
                            int yTile = ((int)startingPoint.Y - i) / 30;

                            if ((int)startingPoint.Y - i < 0)
                            {
                                upDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X + j) % 30;
                            int yOffset = ((int)startingPoint.Y - i) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                upDistance += (i - 2);
                                return i - 2;
                            }
                        }
                    }

                }
                upDistance += (i - 2);
                return i - 2;
            }
            else if (direction == 1)
            {
                startingPoint = player.getGlobalLocation() + new Vector2(0, 29);

                int i = 0;

                while (i <= distance)
                {
                    i += 2;

                    if (!bump)
                    {
                        int leftCol = 0;
                        int centerCol = 0;
                        int rightCol = 0;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X + j) / 30;
                            int yTile = ((int)startingPoint.Y + i) / 30;

                            if ((int)startingPoint.Y + i >= currentZone.getHeight())
                            {
                                downDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X + j) % 30;
                            int yOffset = ((int)startingPoint.Y + i) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                if (j < 14)
                                {
                                    leftCol++;
                                }
                                else if (j >= 16)
                                {
                                    rightCol++;
                                }
                                else
                                {
                                    centerCol++;
                                }
                            }
                        }

                        if (leftCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveRight(checkCollision(2, 2, player, currentZone));
                            downDistance += (i - 2);
                            return i - 2;
                        }
                        else if (rightCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveLeft(checkCollision(2, 3, player, currentZone));
                            downDistance += (i - 2);
                            return i - 2;
                        }
                        else if (centerCol > 0)
                        {
                            downDistance += (i - 2);
                            return i - 2;
                        }
                    }
                    else
                    {
                        bump = false;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X + j) / 30;
                            int yTile = ((int)startingPoint.Y + i) / 30;

                            if ((int)startingPoint.Y + i >= currentZone.getHeight())
                            {
                                downDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X + j) % 30;
                            int yOffset = ((int)startingPoint.Y + i) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                downDistance += (i - 2);
                                return i - 2;
                            }
                        }
                    }

                }
                downDistance += (i - 2);
                return i - 2;
            }
            else if (direction == 2)
            {
                startingPoint = player.getGlobalLocation() + new Vector2(29, 0);

                int i = 0;

                while (i <= distance)
                {
                    i += 2;

                    if (!bump)
                    {
                        int upCol = 0;
                        int centerCol = 0;
                        int downCol = 0;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X + i) / 30;
                            int yTile = ((int)startingPoint.Y + j) / 30;

                            if ((int)startingPoint.X + i >= currentZone.getWidth())
                            {
                                rightDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X + i) % 30;
                            int yOffset = ((int)startingPoint.Y + j) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                if (j < 14)
                                {
                                    upCol++;
                                }
                                else if (j >= 16)
                                {
                                    downCol++;
                                }
                                else
                                {
                                    centerCol++;
                                }
                            }
                        }

                        if (upCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveDown(checkCollision(2, 1, player, currentZone));
                            rightDistance += (i - 2);
                            return i - 2;
                        }
                        else if (downCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveUp(checkCollision(2, 0, player, currentZone));
                            rightDistance += (i - 2);
                            return i - 2;
                        }
                        else if (centerCol > 0)
                        {
                            rightDistance += (i - 2);
                            return i - 2;
                        }
                    }
                    else
                    {
                        bump = false;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X + i) / 30;
                            int yTile = ((int)startingPoint.Y + j) / 30;

                            if ((int)startingPoint.X + i >= currentZone.getWidth())
                            {
                                rightDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X + i) % 30;
                            int yOffset = ((int)startingPoint.Y + j) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                rightDistance += (i - 2);
                                return i - 2;
                            }
                        }
                    }

                }
                rightDistance += (i - 2);
                return i - 2;
            }
            else if (direction == 3)
            {
                startingPoint = player.getGlobalLocation();

                int i = 0;

                while (i <= distance)
                {
                    i += 2;

                    if (!bump)
                    {
                        int upCol = 0;
                        int centerCol = 0;
                        int downCol = 0;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X - i) / 30;
                            int yTile = ((int)startingPoint.Y + j) / 30;

                            if ((int)startingPoint.X - i < 0)
                            {
                                leftDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X - i) % 30;
                            int yOffset = ((int)startingPoint.Y + j) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                if (j < 14)
                                {
                                    upCol++;
                                }
                                else if (j >= 16)
                                {
                                    downCol++;
                                }
                                else
                                {
                                    centerCol++;
                                }
                            }
                        }

                        if (upCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveDown(checkCollision(2, 1, player, currentZone));
                            leftDistance += (i - 2);
                            return i - 2;
                        }
                        else if (downCol > 0 && centerCol == 0)
                        {
                            bump = true;
                            player.moveUp(checkCollision(2, 0, player, currentZone));
                            leftDistance += (i - 2);
                            return i - 2;
                        }
                        else if (centerCol > 0)
                        {
                            leftDistance += (i - 2);
                            return i - 2;
                        }
                    }
                    else
                    {
                        bump = false;

                        for (int j = 0; j < (int)player.getSize().Y; j += 2)
                        {
                            int xTile = ((int)startingPoint.X - i) / 30;
                            int yTile = ((int)startingPoint.Y + j) / 30;

                            if ((int)startingPoint.X - i < 0)
                            {
                                leftDistance += (i - 2);
                                return i - 2;
                            }

                            int xOffset = ((int)startingPoint.X - i) % 30;
                            int yOffset = ((int)startingPoint.Y + j) % 30;

                            if (currentZone.getZoneTileMap().getTile(yTile, xTile, player.getCurrentZoneLevel()).checkPixel(yOffset, xOffset) == 1)
                            {
                                leftDistance += (i - 2);
                                return i - 2;
                            }
                        }
                    }

                }
                leftDistance += (i - 2);
                return i - 2;
            }

            return 0;
        }

        public void updateDrawLocations(Player player, Zone currentZone)
        {
            float playerDrawLocationX;
            float playerDrawLocationY;
            float zoneDrawLocationX;
            float zoneDrawLocationY;

            if (player.getGlobalLocation().X + player.getCenterFromGlobal().X >= 450 && player.getGlobalLocation().X + player.getCenterFromGlobal().X < currentZone.getWidth() - 450)
            {
                playerDrawLocationX = 450 - (int) player.getCenterFromGlobal().X;
                zoneDrawLocationX = -(player.getGlobalLocation().X + player.getCenterFromGlobal().X) + 450;
            }
            else
            {
                if (player.getGlobalLocation().X + player.getCenterFromGlobal().X < 450)
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

            if (player.getGlobalLocation().Y + player.getCenterFromGlobal().Y >= 300 && player.getGlobalLocation().Y + player.getCenterFromGlobal().Y < currentZone.getHeight() - 300)
            {
                playerDrawLocationY = 300 - (player.getDrawingSize().Y - player.getSize().Y + player.getCenterFromGlobal().Y);
                zoneDrawLocationY = -(player.getGlobalLocation().Y + player.getCenterFromGlobal().Y - 300);
            }
            else
            {
                if (player.getGlobalLocation().Y + player.getCenterFromGlobal().Y < 300)
                {
                    playerDrawLocationY = player.getGlobalLocation().Y - (player.getDrawingSize().Y - player.getSize().Y);
                    zoneDrawLocationY = 0;
                }
                else
                {
                    playerDrawLocationY = 600 - (currentZone.getHeight() - player.getGlobalLocation().Y - player.getSize().Y + player.getDrawingSize().Y);
                    zoneDrawLocationY = -currentZone.getHeight() + 600;
                }
            }

            player.setDrawLocation(new Vector2(playerDrawLocationX, playerDrawLocationY));
            currentZone.setDrawLocation(new Vector2(zoneDrawLocationX, zoneDrawLocationY));
        }

        public TransitionHandler getTransitionHandler()
        {
            return transitionHandler;
        }

    }
}
