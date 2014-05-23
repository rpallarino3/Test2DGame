using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FunGame.Game.ContentHandlers
{
    class MenuAndUIContentHandler
    {

        private ContentManager content;

        private Dictionary<string, Texture2D> UIImages;
        private Dictionary<string, Texture2D> inventoryImages;

        public MenuAndUIContentHandler(ContentManager content)
        {
            this.content = content;

            UIImages = new Dictionary<string, Texture2D>();
            inventoryImages = new Dictionary<string, Texture2D>();
        }

        public void loadContent()
        {
            loadUIContent();
            loadInventoryContent();
        }

        private void loadUIContent()
        {
            UIImages.Add("ENERGYCOUNTER", content.Load<Texture2D>("Images/UI/UIBoxes"));
            UIImages.Add("ENTER", content.Load<Texture2D>("Images/UI/Enter"));
            UIImages.Add("ACTIVATE", content.Load<Texture2D>("Images/UI/Activate"));
            UIImages.Add("INPSECT", content.Load<Texture2D>("Images/UI/Inspect"));
            UIImages.Add("OPEN", content.Load<Texture2D>("Images/UI/Open"));
            UIImages.Add("TALK", content.Load<Texture2D>("Images/UI/Talk"));
            UIImages.Add("NONE", content.Load<Texture2D>("Images/UI/None"));
        }

        private void loadInventoryContent()
        {
            inventoryImages.Add("PAGE1HIGHLIGHT", content.Load<Texture2D>("Images/Inventory/InventoryPages/Page1Highlight"));
            inventoryImages.Add("PAGE2HIGHLIGHT", content.Load<Texture2D>("Images/Inventory/InventoryPages/Page2Highlight"));
            inventoryImages.Add("PAGE3HIGHLIGHT", content.Load<Texture2D>("Images/Inventory/InventoryPages/Page3Highlight"));
            inventoryImages.Add("PAGE4HIGHLIGHT", content.Load<Texture2D>("Images/Inventory/InventoryPages/Page4Highlight"));
        }

        public Dictionary<string, Texture2D> getUIImages()
        {
            return UIImages;
        }

        public Dictionary<string, Texture2D> getInventoryImages()
        {
            return inventoryImages;
        }
    }
}
