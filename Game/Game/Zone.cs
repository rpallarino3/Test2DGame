using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Environment
{
    abstract class Zone
    {
        
        protected int tileHeight;
        protected int tileWidth;
        protected int zoneNumber;
        protected List<Image> levels;
        protected List<CollisionMap> collisionMap;
        protected List<TransitionMap> transitionMap;

        public List<Image> getLevels()
        {
            return levels;
        }

        public int getWidth()
        {
            return tileWidth * 30;
        }

        public int getHeight()
        {
            return tileHeight * 30;
        }

        public List<CollisionMap> getCollisionMap()
        {
            return collisionMap;
        }

        public List<TransitionMap> getTransitionMap()
        {
            return transitionMap;
        }

        public int getZoneNumber()
        {
            return zoneNumber;
        }

    }
}
