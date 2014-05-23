using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using FunGame.Game.ContentHandlers;

namespace FunGame.Game.Environment
{
    abstract class ManipulatableObject
    {
        protected int height;
        protected int width;
        protected int length;
        protected int x;
        protected int y;
        protected int bottomLevel;
        protected string type;
        protected bool pushable;
        protected bool jumpable;
        protected bool stationary;

        protected List<Texture2D> activeAnimation;
        protected List<Vector2> animationDrawOffset;
        protected int animationIndex;
        protected bool animationFinished;

        protected readonly int FIRE = 0;
        protected readonly int WATER = 1;
        protected readonly int NATURE = 2;

        protected int energyType;
        protected int energy;
        protected int drainAmount;

        public abstract void activate(ContentHandler content, Zone currentZone, string activationCode);

        public int getDrainAmount()
        {
            return drainAmount;
        }

        public int getEnergyType()
        {
            return energyType;
        }

        public int getEnergy()
        {
            return energy;
        }

        public void advanceAnimation()
        {
            if (animationIndex < activeAnimation.Count - 1)
            {
                animationIndex++;
            }
            else
            {
                animationFinished = true;
            }
        }

        public List<Texture2D> getActiveAnimation()
        {
            return activeAnimation;
        }

        public Texture2D getCurrentImage()
        {
            return activeAnimation[animationIndex];
        }

        public List<Vector2> getActiveAnimationOffset()
        {
            return animationDrawOffset;
        }

        public Vector2 getCurrentOffset()
        {
            return animationDrawOffset[animationIndex];
        }

        public int getAnimationIndex()
        {
            return animationIndex;
        }

        public void setNewAnimation(List<Texture2D> animation, List<Vector2> drawOffset)
        {
            animationFinished = false;
            activeAnimation = animation;
            animationIndex = 0;
            animationDrawOffset = drawOffset;
            // set the draw offset from some dictionary
        }

        public bool isAnimationFinished()
        {
            return animationFinished;
        }

        public int getHeight()
        {
            return height;
        }

        public int getWidth()
        {
            return width;
        }

        public int getLength()
        {
            return length;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getBottomLevel()
        {
            return bottomLevel;
        }

        public string getType()
        {
            return type;
        }

        public bool isPushable()
        {
            return pushable;
        }

        public bool isJumpable()
        {
            return jumpable;
        }

        public bool isStationary()
        {
            return stationary;
        }
    }
}
