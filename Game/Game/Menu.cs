using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Animation;


namespace Menu
{
    abstract class Menu : MenuAnimationInterface
    {

        protected Button[,] menuDestinations;
        protected int rows;
        protected int columns;
        protected Point position;
        protected Image menuImage;
        protected int animationDelay;
        protected int animationIndex;
        protected List<Image> animationImages;
        protected bool animationFinished;

        public void fillDestination(int row, int column, Button button)
        {
            menuDestinations[row, column] = button;
        }

        public void moveUp()
        {
            if (rows != 1)
            {
                if (position.Y == 0)
                {
                    position.Y = rows - 1;
                }
                else
                {
                    position.Y--;
                }
            }
            
        }

        public void moveDown()
        {
            if (rows != 1)
            {
                if (position.Y == rows - 1)
                {
                    position.Y = 0;
                }
                else
                {
                    position.Y++;
                }
            }
            
        }

        public void moveLeft()
        {
            if (columns != 1)
            {
                if (position.X == 0)
                {
                    position.X = columns - 1;
                }
                else
                {
                    position.X--;
                }
            }
        }

        public void moveRight()
        {
            if (columns != 1)
            {
                if (position.X == columns - 1)
                {
                    position.X = 0;
                }
                else
                {
                    position.X++;
                }
            }
        }

        public Image getMenuImage()
        {
            return menuImage;
        }

        public int getRows()
        {
            return rows;
        }

        public Point getPosition()
        {
            return position;
        }

        public Button[,] getButtons()
        {
            return menuDestinations;
        }

        public Button getCurrentButton()
        {
            return menuDestinations[position.Y, position.X];
        }

        public int getAnimationDelay()
        {
            return animationDelay;
        }

        public List<Image> getAnimationImages()
        {
            return animationImages;
        }

        public int getAnimationIndex()
        {
            return animationIndex;
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
                animationFinished = true;
            }
        }

        public bool isAnimationFinished()
        {
            return animationFinished;
        }

        public void startAnimation()
        {
            Console.WriteLine("animation starting");
            animationFinished = false;
            advanceAnimation();
        }

    }
}
