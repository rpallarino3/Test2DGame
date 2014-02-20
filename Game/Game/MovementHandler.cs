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

        public MovementHandler()
        {
        }


        public void movePlayer(Player player, Zone currentZone, List<Keys> keysDown)
        {
            if (keysDown.Contains(Keys.W))
            {
                movePlayerUp(player, currentZone);
            }
            if (keysDown.Contains(Keys.A))
            {
                movePlayerLeft(player, currentZone);
            }
            if (keysDown.Contains(Keys.S))
            {
                movePlayerDown(player, currentZone);
            }
            if (keysDown.Contains(Keys.D))
            {
                movePlayerRight(player, currentZone);
            }
            setCorrectPlayerImage(player, keysDown);
        }

        private void movePlayerUp(Player player, Zone currentZone)
        {
            if (checkUpCollision(player, currentZone))
            {
                player.moveGlobalUp();
            }
        }

        private bool checkUpCollision(Player player, Zone currentZone)
        {
            Point startingCollision = new Point(player.getGlobalLocation().X - 15, player.getGlobalLocation().Y - 16);
            Console.WriteLine("Starting collision: " + startingCollision);
            for (int i = 0; i < 30; i++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y, startingCollision.X + i] == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void movePlayerLeft(Player player, Zone currentZone)
        {
            if (checkLeftCollision(player, currentZone))
            {
                player.moveGlobalLeft();
            }
        }

        private bool checkLeftCollision(Player player, Zone currentZone)
        {
            Point startingCollision = new Point(player.getGlobalLocation().X - 16, player.getGlobalLocation().Y - 15);
            Console.WriteLine("Starting collision: " + startingCollision);
            for (int i = 0; i < 30; i++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y + i, startingCollision.X] == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void movePlayerDown(Player player, Zone currentZone)
        {
            if (checkDownCollision(player, currentZone))
            {
                player.moveGlobalDown();
            }
        }

        private bool checkDownCollision(Player player, Zone currentZone)
        {
            Point startingCollision = new Point(player.getGlobalLocation().X - 15, player.getGlobalLocation().Y + 15);
            Console.WriteLine("Starting collision: " + startingCollision);
            for (int i = 0; i < 30; i++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y, startingCollision.X + i] == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void movePlayerRight(Player player, Zone currentZone)
        {
            if (checkRightCollision(player, currentZone))
            {
                player.moveGlobalRight();
            }
        }

        private bool checkRightCollision(Player player, Zone currentZone)
        {
            Point startingCollision = new Point(player.getGlobalLocation().X + 15, player.getGlobalLocation().Y - 15);
            Console.WriteLine("Starting collision: " + startingCollision);
            for (int i = 0; i < 30; i++)
            {
                if (currentZone.getCollisionMap()[player.getCurrentZoneLevel()].getCollisionMap()[startingCollision.Y + i, startingCollision.X] == false)
                {
                    return false;
                }
            }
            return true;
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
