using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


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

        private Vector2 size;
        private Vector2 drawingSize;
        private Vector2 centerFromGlobal;

        private int currentZoneLevel;
        private int moveSpeed;
        private int facingDirection;

        private bool isSwordOut;
        private int health;
        private AttackRegions attackRegions;

        private List<Texture2D> activeAnimation;
        private List<Texture2D> activeBorderAnimation;
        private AnimationPriorities animationPriorities;
        private int currentAnimationPriority;
        private int currentAnimationIndex;
        private bool animationFinished;

        public Player()
        {
            globalLocation = new Vector2(0, 0);
            drawLocation = new Vector2(0, 0);

            size = new Vector2(20, 20);
            drawingSize = new Vector2(20, 30);
            centerFromGlobal = new Vector2(10, 5);

            currentZoneLevel = 0;
            facingDirection = 0;
            moveSpeed = 4;
            isSwordOut = false;
            health = 100;
            attackRegions = new AttackRegions();

            activeAnimation = new List<Texture2D>();
            activeBorderAnimation = new List<Texture2D>();
            animationPriorities = new AnimationPriorities();
            currentAnimationPriority = -1;
            currentAnimationIndex = 0;
            animationFinished = true;
        }

        public Vector2 getGlobalLocation()
        {
            return globalLocation;
        }

        public void setGlobalLocation(Vector2 location)
        {
            globalLocation = location;
        }

        public Vector2 getSize()
        {
            return size;
        }

        public Vector2 getDrawingSize()
        {
            return drawingSize;
        }

        public Vector2 getCenterFromGlobal()
        {
            return centerFromGlobal;
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

        public void setZoneLevel(int level)
        {
            currentZoneLevel = level;
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

        public AttackRegions getAttackRegions()
        {
            return attackRegions;
        }

        public void swordOut()
        {
            isSwordOut = true;
            moveSpeed = 2;
        }

        public void swordIn()
        {
            isSwordOut = false;
            moveSpeed = 4;
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

        public List<Texture2D> getActiveAnimation()
        {
            return activeAnimation;
        }

        public List<Texture2D> getActiveBorderAnimation()
        {
            return activeBorderAnimation;
        }

        public int getCurrentAnimationPriority()
        {
            return currentAnimationPriority;
        }

        public void setNewBorderAnimation(List<Texture2D> animation, string name)
        {
            activeBorderAnimation = animation;
        }

        public void setNewAnimation(List<Texture2D> animation, string name)
        {
            //Console.WriteLine("new animation");
            animationFinished = false;
            activeAnimation = animation;
            currentAnimationIndex = 0;
            currentAnimationPriority = animationPriorities.getPriority(name);
        }

        public void advanceCurrentAnimation()
        {
            if (currentAnimationIndex < activeAnimation.Count - 1)
            {
                currentAnimationIndex++;
            }
            else
            {
                currentAnimationIndex = 0;
                animationFinished = true;
            }
        }

        public void finishAnimation()
        {
            currentAnimationPriority = -1;
        }

        public int getAnimationIndex()
        {
            return currentAnimationIndex;
        }

        public bool isAnimationFinished()
        {
            return animationFinished;
        }

    }
}
