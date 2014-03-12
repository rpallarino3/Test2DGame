using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.Animation
{
    class Animation
    {

        private List<Texture2D> animationImages;

        private int priority;
        private int animationIndex;

        private bool isPlaying;

        public Animation(int priority)
        {

            animationImages = new List<Texture2D>();

            this.priority = priority;
            animationIndex = 0;
            isPlaying = false; // might not even need this
        }

        public int getPriority()
        {
            return priority;
        }

        public List<Texture2D> getAnimationImages()
        {
            return animationImages;
        }

        public void advanceAnimation()
        {
            if (animationIndex < animationImages.Count - 1)
            {
                animationIndex++;
            }
            else
            {
                animationIndex = 0;
            }
        }

        public bool getIsPlaying()
        {
            return isPlaying;
        }

        public void startAnimation()
        {
            isPlaying = true;
        }

        public void stopAnimation()
        {
            isPlaying = false;
            animationIndex = 0;
        }
    }
}
