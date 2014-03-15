using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.PlayerStuff
{
    class AttackRegions
    {

        private List<Rectangle> swordRegions;
        private List<Rectangle> upSwordRegions;
        private List<Rectangle> downSwordRegions;
        private List<Rectangle> rightSwordRegions;
        private List<Rectangle> leftSwordRegions;

        public AttackRegions()
        {

            swordRegions = new List<Rectangle>();
            upSwordRegions = new List<Rectangle>();
            downSwordRegions = new List<Rectangle>();
            rightSwordRegions = new List<Rectangle>();
            leftSwordRegions = new List<Rectangle>();
            fillSwordRegions();
        }

        private void fillSwordRegions()
        {
            swordRegions.Add(new Rectangle(5, -20, 10, 10));
            swordRegions.Add(new Rectangle(15, -20, 15, 20));
            swordRegions.Add(new Rectangle(20, 0, 10, 10));
            swordRegions.Add(new Rectangle(15, 10, 15, 20));
            swordRegions.Add(new Rectangle(5, 20, 10, 10));
            swordRegions.Add(new Rectangle(-10, 10, 15, 20));
            swordRegions.Add(new Rectangle(-10, 0, 10, 10));
            swordRegions.Add(new Rectangle(-10, -20, 15, 20));

            upSwordRegions.Add(new Rectangle(-10, 0, 10, 10));
            upSwordRegions.Add(new Rectangle(-10, 0, 10, 10));
            upSwordRegions.Add(new Rectangle(-10, -20, 15, 20));
            upSwordRegions.Add(new Rectangle(-10, -20, 15, 20));
            upSwordRegions.Add(new Rectangle(5, -20, 10, 10));
            upSwordRegions.Add(new Rectangle(5, -20, 10, 10));
            upSwordRegions.Add(new Rectangle(15, -20, 15, 20));
            upSwordRegions.Add(new Rectangle(15, -20, 15, 20));

            downSwordRegions.Add(new Rectangle(20, 0, 10, 10));
            downSwordRegions.Add(new Rectangle(20, 0, 10, 10));
            downSwordRegions.Add(new Rectangle(15, 10, 15, 20));
            downSwordRegions.Add(new Rectangle(15, 10, 15, 20));
            downSwordRegions.Add(new Rectangle(5, 20, 10, 10));
            downSwordRegions.Add(new Rectangle(5, 20, 10, 10));
            downSwordRegions.Add(new Rectangle(-10, 10, 15, 20));
            downSwordRegions.Add(new Rectangle(-10, 10, 15, 20));

            rightSwordRegions.Add(new Rectangle(5, -20, 10, 10));
            rightSwordRegions.Add(new Rectangle(5, -20, 10, 10));
            rightSwordRegions.Add(new Rectangle(15, -20, 15, 20));
            rightSwordRegions.Add(new Rectangle(15, -20, 15, 20));
            rightSwordRegions.Add(new Rectangle(20, 0, 10, 10));
            rightSwordRegions.Add(new Rectangle(20, 0, 10, 10));
            rightSwordRegions.Add(new Rectangle(15, 10, 15, 20));
            rightSwordRegions.Add(new Rectangle(15, 10, 15, 20));

            leftSwordRegions.Add(new Rectangle(5, 20, 10, 10));
            leftSwordRegions.Add(new Rectangle(5, 20, 10, 10));
            leftSwordRegions.Add(new Rectangle(-10, 10, 15, 20));
            leftSwordRegions.Add(new Rectangle(-10, 10, 15, 20));
            leftSwordRegions.Add(new Rectangle(-10, 0, 10, 10));
            leftSwordRegions.Add(new Rectangle(-10, 0, 10, 10));
            leftSwordRegions.Add(new Rectangle(-10, -20, 15, 20));
            leftSwordRegions.Add(new Rectangle(-10, -20, 15, 20));
        }

        public Rectangle getSwordRegion(int facingDirection, int swordCounter)
        {
            if (facingDirection == 0)
            {
                if (swordCounter < 8)
                {
                    return upSwordRegions[swordCounter];
                }
                else
                {
                    return upSwordRegions[5];
                }
            }
            if (facingDirection == 1)
            {
                if (swordCounter < 8)
                {
                    return downSwordRegions[swordCounter];
                }
                else
                {
                    return downSwordRegions[5];
                }
            }
            if (facingDirection == 2)
            {
                if (swordCounter < 8)
                {
                    return rightSwordRegions[swordCounter];
                }
                else
                {
                    return rightSwordRegions[5];
                }
            }
            if (facingDirection == 3)
            {
                if (swordCounter < 8)
                {
                    return leftSwordRegions[swordCounter];
                }
                else
                {
                    return leftSwordRegions[5];
                }
            }
            return swordRegions[0];
        }
    }
}
