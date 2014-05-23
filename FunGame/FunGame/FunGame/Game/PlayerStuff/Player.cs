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

        private readonly int FIRE = 0;
        private readonly int WATER = 1;
        private readonly int NATURE = 2;

        private int waterEnergy;
        private int fireEnergy;
        private int natureEnergy;

        private int currentElement;

        private Vector2 globalLocation;
        private Vector2 drawLocation;

        private Vector2 size;
        private Vector2 drawingSize;
        private Vector2 centerFromGlobal;

        private int currentZoneLevel;
        private int moveSpeed;
        private int facingDirection;

        private int health;

        private List<Texture2D> activeAnimation;
        private List<Texture2D> abilityAnimation;
        private List<Vector2> abilityAnimationOffset;
        private int currentAnimationIndex;
        private int abilityAnimationIndex;
        private bool animationFinished;

        private bool abilityAnimationFinished;
        private bool abilityAnimationPlaying;

        private List<Vector2> jumpOffset;
        private List<Vector2> jumpUpOffset;
        private List<Vector2> jumpDownOffset;
        private List<Vector2> jumpRightOffset;
        private List<Vector2> jumpLeftOffset;

        private CharacterStats stats;

        public Player()
        {
            stats = new CharacterStats();
            globalLocation = new Vector2(0, 0);
            drawLocation = new Vector2(0, 0);

            size = new Vector2(30, 30);
            drawingSize = new Vector2(30, 45);
            centerFromGlobal = new Vector2(15, 8);

            currentZoneLevel = 0;
            facingDirection = 0;
            moveSpeed = 4;
            health = 100;
            fireEnergy = 100;
            waterEnergy = 100;
            natureEnergy = 100;
            currentElement = 0; // might want to set these from save file

            activeAnimation = new List<Texture2D>();
            abilityAnimation = new List<Texture2D>();
            currentAnimationIndex = 0;
            abilityAnimationIndex = 0;
            animationFinished = true;
            abilityAnimationFinished = false;
            abilityAnimationPlaying = false;

            jumpOffset = new List<Vector2>();
            jumpUpOffset = new List<Vector2>();
            jumpDownOffset = new List<Vector2>();
            jumpRightOffset = new List<Vector2>();
            jumpLeftOffset = new List<Vector2>();

            fillJumpOffsets();
        }

        private void fillJumpOffsets()
        {
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));
            jumpUpOffset.Add(new Vector2(0, -6));

            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));
            jumpDownOffset.Add(new Vector2(0, 6));

            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));
            jumpRightOffset.Add(new Vector2(6, 0));

            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
            jumpLeftOffset.Add(new Vector2(-6, 0));
        }

        public List<Vector2> getJumpOffset()
        {
            return jumpOffset;
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
        
        public void setNewAnimation(List<Texture2D> animation)
        {
            animationFinished = false;
            activeAnimation = animation;
            currentAnimationIndex = 0;
        }

        public void advanceCurrentAnimation()
        {
            currentAnimationIndex++;
            if (currentAnimationIndex == activeAnimation.Count - 1)
            {
                animationFinished = true;
            }
        }

        public int getAnimationIndex()
        {
            return currentAnimationIndex;
        }

        public bool isAnimationFinished()
        {
            return animationFinished;
        }

        public List<Texture2D> getAbilityAnimation()
        {
            return abilityAnimation;
        }

        public List<Vector2> getAbilityAnimationOffset()
        {
            return abilityAnimationOffset;
        }

        public void setNewAbilityAnimation(List<Texture2D> animation, List<Vector2> offsets)
        {
            abilityAnimationFinished = false;
            abilityAnimationPlaying = true;
            abilityAnimation = animation;
            abilityAnimationOffset = offsets;
            abilityAnimationIndex = 0;
        }

        public void advanceAbilityAnimation()
        {
            abilityAnimationIndex++;
            if (abilityAnimationIndex == abilityAnimation.Count - 1)
            {
                abilityAnimationFinished = true;
            }
        }

        public int getAbilityAnimationIndex()
        {
            return abilityAnimationIndex;
        }

        public bool isAbilityAnimationFinished()
        {
            return abilityAnimationFinished;
        }

        public bool isAbilityAnimationPlaying()
        {
            return abilityAnimationPlaying;
        }

        public void finishAbilityAnimation()
        {
            abilityAnimationPlaying = false;
        }

        public void jump(int direction)
        {
            if (direction == 0)
            {
                jumpOffset = jumpUpOffset;
            }
            else if (direction == 1)
            {
                jumpOffset = jumpDownOffset;
            }
            else if (direction == 2)
            {
                jumpOffset = jumpRightOffset;
            }
            else if (direction == 3)
            {
                jumpOffset = jumpLeftOffset;
            }
        }

        public void drainEnergy(int type, int amount)
        {
            stats.restoreEnergy(type, amount);
        }

        public void feedEnergy(int type, int amount)
        {
            if (type == FIRE)
            {
                fireEnergy -= amount;
                if (fireEnergy < 0)
                {
                    fireEnergy = 0;
                }
            }
            else if (type == WATER)
            {
                waterEnergy -= amount;
                if (waterEnergy < 0)
                {
                    waterEnergy = 0;
                }
            }
            else if (type == NATURE)
            {
                natureEnergy -= amount;
                if (natureEnergy < 0)
                {
                    natureEnergy = 0;
                }
            }
        }

        public void releaseEnergy()
        {
        }

        public void cycleLeft()
        {
            if (currentElement == 0)
            {
                currentElement = 2;
            }
            else
            {
                currentElement--;
            }
        }

        public void cycleRight()
        {
            if (currentElement == 2)
            {
                currentElement = 0;
            }
            else
            {
                currentElement++;
            }
        }

        public int getCurrentElement()
        {
            return currentElement;
        }

        public void setCurrentElement(int element)
        {
            currentElement = element;
        }

        public CharacterStats getStats()
        {
            return stats;
        }

    }
}
