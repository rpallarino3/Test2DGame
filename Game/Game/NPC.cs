using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Environment;

namespace NPCandEnemies
{
    class NPC
    {

        private Zone startingZone;
        private Zone currentZone;
        private int startingLevel;

        private Point startingLocation;
        private Point currentLocation;
        private int currentLevel;

        private bool isStationary;
        private Image stationaryImage;

        private int yOffset;
        private int width;
        private int height;

        public NPC(Zone startingZone, Point startingLocation, int startingLevel)
        {

            this.startingZone = startingZone;
            this.startingLocation = startingLocation;
            this.startingLevel = startingLevel;
            currentLocation = startingLocation;
            currentZone = startingZone;
            currentLevel = startingLevel;

            yOffset = 0;
            width = 30;
            height = 30;
        }

        public Zone getStartingZone()
        {
            return startingZone;
        }

        public Zone getCurrentZone()
        {
            return currentZone;
        }

        public void setCurrentZone(Zone zone)
        {
            currentZone = zone;
        }

        public Point getStartingLocation()
        {
            return startingLocation;
        }

        public Point getCurrentLocation()
        {
            return currentLocation;
        }

        public void setStationaryImage(Image image)
        {
            yOffset = image.Height - height;
            width = image.Width;
            stationaryImage = image;
        }

        public Image getStationaryImage()
        {
            return stationaryImage;
        }

        public int getStartingLevel()
        {
            return startingLevel;
        }

        public int getCurrentLevel()
        {
            return currentLevel;
        }

        public int getYOffset()
        {
            return yOffset;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }
    }
}
