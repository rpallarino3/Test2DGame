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
        private Image bigPlayerUp = Image.FromFile("../../../Images/Player/bigplayerup.png");
        private Image bigPlayerRight = Image.FromFile("../../../Images/Player/bigplayerright.png");
        private Image bigPlayerDown = Image.FromFile("../../../Images/Player/bigplayerdown.png");
        private Image bigPlayerLeft = Image.FromFile("../../../Images/Player/bigplayerleft.png");
        private Image currentImage;
        private int currentZoneLevel;
        private int xOffset;
        private int yOffset;
        private int moveSpeed;

        private int drawOffsetY;

        private readonly int walkingOffset = 30;

        public Player()
        {
            globalLocation = new Point(0, 0);
            currentImage = bigPlayerUp;
            xOffset = currentImage.Width / 2;
            yOffset = walkingOffset - currentImage.Height / 2;
            drawOffsetY = currentImage.Height - walkingOffset;
            moveSpeed = 4;
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

        public int getWalkingOffset()
        {
            return walkingOffset;
        }

        public int getDrawOffsetY()
        {
            return drawOffsetY;
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
            return bigPlayerUp;
        }

        public Image getDownImage()
        {
            return bigPlayerDown;
        }

        public Image getRightImage()
        {
            return bigPlayerRight;
        }

        public Image getLeftImage()
        {
            return bigPlayerLeft;
        }

        public void moveGlobalUp(int distance)
        {
            moveGlobalLocation(0, -distance);
        }

        public void moveGlobalDown(int distance)
        {
            moveGlobalLocation(0, distance);
        }

        public void moveGlobalLeft(int distance)
        {
            moveGlobalLocation(-distance, 0);
        }

        public void moveGlobalRight(int distance)
        {
            moveGlobalLocation(distance, 0);
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
