using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.Animation
{
    class AnimationHandler
    {

        List<Animation> activeAnimations;

        public AnimationHandler()
        {

            activeAnimations = new List<Animation>();
        }

        public void advanceAnimations()
        {
            for (int i = 0; i < activeAnimations.Count; i++)
            {
                activeAnimations[i].advanceAnimation();
            }
        }
    }
}
