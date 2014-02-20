using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Menu
{
    class OptionsMenu : Menu
    {

        public OptionsMenu(int rows, int columns, Image image)
        {
            this.rows = rows;
            this.columns = columns;
            menuDestinations = new Button[rows, columns];
            menuImage = image;
            animationDelay = 2;
            animationFinished = false;
            animationIndex = 0;
            animationImages = new List<Image>();
            animationImages.Add(Image.FromFile("../../../Images/Menus/OptionsMenu/Animation/OptionsAnimation1.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/OptionsMenu/Animation/OptionsAnimation2.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/OptionsMenu/Animation/OptionsAnimation3.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/OptionsMenu/Animation/OptionsAnimation4.png"));
            animationImages.Add(Image.FromFile("../../../Images/Menus/OptionsMenu/Animation/OptionsAnimation5.png"));
            position = new Point(0, 0);
        }
    }
}
