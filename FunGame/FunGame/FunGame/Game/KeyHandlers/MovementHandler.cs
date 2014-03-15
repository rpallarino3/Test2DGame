using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunGame.Game.PlayerStuff;
using FunGame.Game.Environment;
using FunGame.Game.EnemyStuff;

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
            checkEnemySpawns(player, zoneFactory);
            transitionHandler.checkTransitions(player, zoneFactory); //transitions need to be fixed
        }

        private void checkEnemySpawns(Player player, ZoneFactory zoneFactory)
        {
            float playerCenterX = player.getGlobalLocation().X + player.getCenterFromGlobal().X;
            float playerCenterY = player.getGlobalLocation().Y + player.getCenterFromGlobal().Y;

            for (int i = 0; i < zoneFactory.getCurrentZone().getEnemySpawners().Count; i++)
            {
                EnemySpawner currentSpawner = zoneFactory.getCurrentZone().getEnemySpawners()[i];
                double xDist = Math.Pow(playerCenterX - (currentSpawner.getLocation().X + currentSpawner.getWidth() / 2), 2);
                double yDist = Math.Pow(playerCenterY - (currentSpawner.getLocation().Y + currentSpawner.getHeight() / 2), 2);

                if (Math.Sqrt(xDist + yDist) <= currentSpawner.getSpawnThreshold())
                {
                    currentSpawner.spawnEnemy("Goblin", zoneFactory.getCurrentZone(), player.getCurrentZoneLevel());
                }
            }
        }

        private int checkUpCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X, player.getGlobalLocation().Y - player.getMoveSpeed());
            for (int j = 0; j < player.getSize().X; j++)
            {
                bool collision = currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y, (int)startingCollision.X + j];
                bool npc = currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y, (int)startingCollision.X + j];
                bool enemy = currentZone.getEnemyMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y, (int)startingCollision.X + j]; // you should be able to move onto enemies but just immediately take damage when you do
                if (collision == false || npc == true || enemy == true)
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
            checkEnemySpawns(player, zoneFactory);
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkLeftCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X - player.getMoveSpeed(), player.getGlobalLocation().Y);
            for (int j = 0; j < player.getSize().Y; j++)
            {
                bool collision = currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y + j, (int)startingCollision.X];
                bool npc = currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y + j, (int)startingCollision.X];
                bool enemy = currentZone.getEnemyMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y + j, (int)startingCollision.X];
                if (collision == false || npc == true || enemy == true)
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
            checkEnemySpawns(player, zoneFactory);
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkDownCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X, player.getGlobalLocation().Y + 19 + player.getMoveSpeed());
            for (int j = 0; j < player.getSize().X; j++)
            {
                bool collision = currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y, (int)startingCollision.X + j];
                bool npc = currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y, (int)startingCollision.X + j];
                bool enemy = currentZone.getEnemyMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y, (int)startingCollision.X + j];
                if (collision == false || npc == true || enemy == true)
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
            checkEnemySpawns(player, zoneFactory);
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkRightCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Vector2 startingCollision = new Vector2(player.getGlobalLocation().X + 19 + player.getMoveSpeed(), player.getGlobalLocation().Y);
            for (int j = 0; j < player.getSize().Y; j++)
            {
                bool collision = currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[(int)startingCollision.Y + j, (int)startingCollision.X];
                bool npc = currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y + j, (int)startingCollision.X];
                bool enemy = currentZone.getEnemyMap()[player.getCurrentZoneLevel()].getTrafficMap()[(int)startingCollision.Y + j, (int)startingCollision.X];
                if (collision == false || npc == true || enemy == true)
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


        public void updateDrawLocations(Player player, Zone currentZone) // down too far by 5 pixels
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

        public void checkDamage(Player player, Zone currentZone)
        {
            Vector2 playerTopLeft = player.getGlobalLocation() - new Vector2(0, 10);

            for (int i = 0; i < currentZone.getEnemies().Count; i++)
            {
                Enemy currentEnemy = currentZone.getEnemies()[i];
                int width, height;

                //Console.WriteLine("Player: " + player.getGlobalLocation());
                Console.WriteLine("Enemy" + i + ": " + currentEnemy.getLocation());

                if (playerTopLeft.X > currentEnemy.getLocation().X)
                {
                    width = (int) currentEnemy.getSize().X;
                }
                else
                {
                    width = 20;
                }

                if (playerTopLeft.Y > currentEnemy.getLocation().Y)
                {
                    height = (int)currentEnemy.getSize().Y;
                }
                else
                {
                    height = 30;
                }

                // needs to be tweaked a bit
                if (Math.Abs(playerTopLeft.X - currentEnemy.getLocation().X) < width && Math.Abs(playerTopLeft.Y - (currentEnemy.getLocation().Y + currentEnemy.getWalkingSize().Y - currentEnemy.getSize().Y)) < height)
                {
                    Console.WriteLine("Damage");
                }
            }
        }

    }
}
