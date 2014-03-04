using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace FunGame.Game.PlayerStuff
{
    class Player
    {

        public readonly int UP = 0;
        public readonly int DOWN = 1;
        public readonly int RIGHT = 2;
        public readonly int LEFT = 3;

        private Vector2 globalLocation;
        private Vector2 drawLocation;

        private int currentZoneLevel;
        private int moveSpeed;
        private int facingDirection;

        private readonly int walkingOffset = 30;

        private bool isSwordOut;
        private int health;

        public Player()
        {

            globalLocation = new Vector2(0, 0);
            drawLocation = new Vector2(0, 0);

            currentZoneLevel = 0;
            facingDirection = 0;
            moveSpeed = 4;
            isSwordOut = false;
            health = 100;
        }

        public Vector2 getGlobalLocation()
        {
            return globalLocation;
        }

        public void setGlobalLocation(Vector2 location)
        {
            globalLocation = location;
        }

        public void moveUp(int distance)
        {
            globalLocation.Y -= distance;
        }

        public void moveDown(int distance)
        {
            globalLocation.Y += distance;
        }

        public void moveRight(int distance)
        {
            globalLocation.X += distance;
        }

        public void moveLeft(int distance)
        {
            globalLocation.X -= distance;
        }

        public Vector2 getDrawLocation()
        {
            return drawLocation;
        }

        public void setDrawLocation(Vector2 location)
        {
            drawLocation = location;
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

        public int getMoveSpeed()
        {
            return moveSpeed;
        }

        public void setMoveSpeed(int speed)
        {
            moveSpeed = speed;
        }

        public int getFacingDirection()
        {
            return facingDirection;
        }

        public void setFacingDirection(int direction)
        {
            facingDirection = direction;
        }

        public int getWalkingOffset()
        {
            return walkingOffset;
        }

        public int getYOffset()
        {
            return walkingOffset - 25;
        }

        public int getDrawOffsetY()
        {
            return 20;
        }

        public int getXOffset()
        {
            return 15;
        }

        public void swordOut()
        {
            isSwordOut = true;
        }

        public void swordIn()
        {
            isSwordOut = false;
        }

        public bool getSwordOut()
        {
            return isSwordOut;
        }

        public int getHealth()
        {
            return health;
        }

        public void changeHealth(int change)
        {
            if (health + change > 100)
            {
                health = 100;
            }
            else if (health + change < 0)
            {
                health = 0;
            }
            else
            {
                health += change;
            }
        }
    }
}
