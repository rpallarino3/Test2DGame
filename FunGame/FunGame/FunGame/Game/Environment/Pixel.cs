using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGame.Game.Environment
{
    class Pixel
    {
        private bool collision;
        private bool jumpable;
        private int transition;

        public Pixel()
        {

            collision = false;
            jumpable = false;
            transition = 0;
        }

        public bool isJumpable()
        {
            return jumpable;
        }

        public void setJumpable(bool jump)
        {
            jumpable = jump;
        }

        public bool isCollision()
        {
            return collision;
        }

        public void setCollision(bool coll)
        {
            collision = coll;
        }

        public int transitionNumber()
        {
            return transition;
        }

        public void setTransitionNumber(int num)
        {
            transition = num;
        }
    }
}
