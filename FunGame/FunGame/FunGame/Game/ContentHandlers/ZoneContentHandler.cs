using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FunGame.Game.ContentHandlers
{
    class ZoneContentHandler
    {
        private ContentManager content;

        private Dictionary<int, List<Texture2D>> zoneImages;

        public ZoneContentHandler(ContentManager content)
        {
            this.content = content;

            zoneImages = new Dictionary<int, List<Texture2D>>();
        }

        public void loadContent()
        {
            loadTestTileZoneContent();
        }

        private void loadTestTileZoneContent()
        {
            List<Texture2D> testTileZoneImages = new List<Texture2D>();

            testTileZoneImages.Add(content.Load<Texture2D>("images/Zones/TestTileZone/TestTileZoneLevel1"));
            testTileZoneImages.Add(content.Load<Texture2D>("images/Zones/TestTileZone/TestTileZoneLevel2"));

            zoneImages.Add(-4, testTileZoneImages);
        }

        public Dictionary<int, List<Texture2D>> getZoneImages()
        {
            return zoneImages;
        }
    }
}
