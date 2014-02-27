using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PlayerStuff;
using Environment;

namespace Game
{
    class MovementHandler
    {

        private TransitionHandler transitionHandler;

        public MovementHandler()
        {
            transitionHandler = new TransitionHandler();
        }


        public void movePlayer(Player player, ZoneFactory zoneFactory, List<Keys> keysDown)
        {
            if (keysDown.Contains(Keys.W))
            {
                movePlayerUp(player, zoneFactory);
            }
            if (keysDown.Contains(Keys.A))
            {
                movePlayerLeft(player, zoneFactory);
            }
            if (keysDown.Contains(Keys.S))
            {
                movePlayerDown(player, zoneFactory);
            }
            if (keysDown.Contains(Keys.D))
            {
                movePlayerRight(player, zoneFactory);
            }
            setCorrectPlayerImage(player, keysDown);
        }

        private void movePlayerUp(Player player, ZoneFactory zoneFactory)
        {
            player.moveGlobalUp(checkUpCollision(player, zoneFactory.getCurrentZone()));
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkUpCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Point startingCollision = new Point(player.getGlobalLocation().X, player.getGlobalLocation().Y - player.getMoveSpeed());
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y, startingCollision.X + j] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[startingCollision.Y, startingCollision.X + j] == true)
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

        private void movePlayerLeft(Player player, ZoneFactory zoneFactory)
        {
            player.moveGlobalLeft(checkLeftCollision(player, zoneFactory.getCurrentZone()));
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkLeftCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Point startingCollision = new Point(player.getGlobalLocation().X - player.getMoveSpeed(), player.getGlobalLocation().Y);
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y + j, startingCollision.X] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[startingCollision.Y + j, startingCollision.X] == true)
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

        private void movePlayerDown(Player player, ZoneFactory zoneFactory)
        {
            player.moveGlobalDown(checkDownCollision(player, zoneFactory.getCurrentZone()));
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkDownCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Point startingCollision = new Point(player.getGlobalLocation().X, player.getGlobalLocation().Y + 29 + player.getMoveSpeed());
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y, startingCollision.X + j] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[startingCollision.Y, startingCollision.X + j] == true)
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

        private void movePlayerRight(Player player, ZoneFactory zoneFactory)
        {
            player.moveGlobalRight(checkRightCollision(player, zoneFactory.getCurrentZone()));
            transitionHandler.checkTransitions(player, zoneFactory);
        }

        private int checkRightCollision(Player player, Zone currentZone)
        {
            int i = 0;
            Point startingCollision = new Point(player.getGlobalLocation().X + 29 + player.getMoveSpeed(), player.getGlobalLocation().Y);
            for (int j = 0; j < player.getWalkingOffset(); j++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y + j, startingCollision.X] == false || currentZone.getTrafficMap()[player.getCurrentZoneLevel()].getTrafficMap()[startingCollision.Y + j, startingCollision.X] == true)
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

        private void setCorrectPlayerImage(Player player, List<Keys> keysDown)
        {
            int index = -1;
            for (int i = 0; i < keysDown.Count; i++)
            {
                Keys currentKey = keysDown[i];
                if (currentKey == Keys.W || currentKey == Keys.A || currentKey == Keys.D || currentKey == Keys.S)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                Keys key = keysDown[index];
                if (key == Keys.W)
                {
                    player.setImage(player.getUpImage());
                }
                else if (key == Keys.A)
                {
                    player.setImage(player.getLeftImage());
                }
                else if (key == Keys.D)
                {
                    player.setImage(player.getRightImage());
                }
                else
                {
                    player.setImage(player.getDownImage());
                }
            }
        }

    }
}
