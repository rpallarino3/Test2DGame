using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PlayerStuff
{

    class Player
    {
        private Point globalLocation;
        private Image playerUp = Image.FromFile("../../../Images/Player/playerup.png");
        private Image playerRight = Image.FromFile("../../../Images/Player/playerright.png");
        private Image playerDown = Image.FromFile("../../../Images/Player/playerdown.png");
        private Image playerLeft = Image.FromFile("../../../Images/Player/playerleft.png");
        private Image currentImage;
        private int currentZoneLevel;
        private int xOffset;
        private int yOffset;
        private int moveSpeed;

        public Player()
        {
            globalLocation = new Point(0, 0);
            currentImage = playerUp;
            xOffset = currentImage.Width / 2;
            yOffset = currentImage.Height / 2;
            moveSpeed = 1;
            currentZoneLevel = 0;
        }

        public int getXOffset()
        {
            return xOffset;
        }

        public int getYOffset()
        {
            return yOffset;
        }

        public Image getImage()
        {
            return currentImage;
        }

        public void setImage(Image image)
        {
            currentImage = image;
        }

        public Image getUpImage()
        {
            return playerUp;
        }

        public Image getDownImage()
        {
            return playerDown;
        }

        public Image getRightImage()
        {
            return playerRight;
        }

        public Image getLeftImage()
        {
            return playerLeft;
        }

        public void moveGlobalUp()
        {
            moveGlobalLocation(0, -moveSpeed);
        }

        public void moveGlobalDown()
        {
            moveGlobalLocation(0, moveSpeed);
        }

        public void moveGlobalLeft()
        {
            moveGlobalLocation(-moveSpeed, 0);
        }

        public void moveGlobalRight()
        {
            moveGlobalLocation(moveSpeed, 0);
        }

        public Point getGlobalLocation()
        {
            return globalLocation;
        }

        public void setGlobalLocation(int x, int y)
        {
            globalLocation.X = x;
            globalLocation.Y = y;
        }

        public void moveGlobalLocation(int x, int y)
        {
            globalLocation.X += x;
            globalLocation.Y += y;
        }

        public int getCurrentZoneLevel()
        {
            return currentZoneLevel;
        }

        public void upOneLevel()
        {
            currentZoneLevel++;
        }

        public void downOneLevel()
        {
            currentZoneLevel--;
        }

        public void setCurrentZoneLevel(int newLevel)
        {
            currentZoneLevel = newLevel;
        }

        public void setMoveSpeed(int newMoveSpeed)
        {
            moveSpeed = newMoveSpeed;
        }

        public int getMoveSpeed()
        {
            return moveSpeed;
        }
    }

}
