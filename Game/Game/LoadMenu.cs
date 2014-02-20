using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Menu
{
    class LoadMenu : Menu
    {

        public LoadMenu(int rows, int columns, Image image)
        {
            this.rows = rows;
            this.columns = columns;
            menuDestinations = new Button[rows, columns];
            menuImage = image;
            animationDelay = 2;
            animationFinished = false;
            animationIndex = 0;
            animationImages = new List<Image>();
            animationImages.Add(Image.FromFile("../../../Images/Menus/LoadMenu/Animation/LoadMenuAnimation1.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/LoadMenu/Animation/LoadMenuAnimation2.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/LoadMenu/Animation/LoadMenuAnimation3.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/LoadMenu/Animation/LoadMenuAnimation4.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/LoadMenu/Animation/LoadMenuAnimation5.png"));
            position = new Point(0, 0);
        }
    }
}
