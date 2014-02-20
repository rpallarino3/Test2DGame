using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Menu
{
    class Button
    {

        private Point location;
        private int destination;
        private Image image;

        public Button(Point location, int destination, Image highlightImage)
        {
            this.location = location;
            this.destination = destination;
            image = highlightImage;
        }

        public Image getHighlightImage()
        {
            return image;
        }

        public Point getLocation()
        {
            return location;
        }

        public int getDestination()
        {
            return destination;
        }

    }
}
