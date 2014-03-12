using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using FunGame.Game.Environment;

namespace FunGame.Game.NPCStuff
{
    class NPC
    {

        private Zone startingZone;
        private Zone currentZone;
        private int startingLevel;

        private Vector2 startingLocation;
        private Vector2 currentLocation;
        private int currentLevel;

        private bool isStationary;
        //private Image stationaryImage;

        private int yOffset;
        private int width;
        private int height;
        private String name;

        public NPC(String name, Zone startingZone, Vector2 startingLocation, int startingLevel, Vector2 drawDimensions)
        {
            this.name = name;
            this.startingZone = startingZone;
            this.startingLocation = startingLocation;
            this.startingLevel = startingLevel;
            currentLocation = startingLocation;
            currentZone = startingZone;
            currentLevel = startingLevel;

            yOffset = (int)drawDimensions.Y - 30;
            width = (int)drawDimensions.X;
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

        public Vector2 getStartingLocation()
        {
            return startingLocation;
        }

        public Vector2 getCurrentLocation()
        {
            return currentLocation;
        }

        //public void setStationaryImage(Image image)
        //{
        //    yOffset = image.Height - height;
        //    width = image.Width;
        //    stationaryImage = image;
        //}

        //public Image getStationaryImage()
        //{
        //    return stationaryImage;
        //}

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

        public String getName()
        {
            return name;
        }
    }
}
