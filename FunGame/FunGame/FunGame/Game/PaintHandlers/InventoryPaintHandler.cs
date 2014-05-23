using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.PaintHandlers
{
    class InventoryPaintHandler
    {
        private readonly Color FADECOLOR = Color.Gray;
        private readonly Color WHITECOLOR = Color.White;
        
        private readonly string PAGE1 = "PAGE1HIGHLIGHT";
        private readonly string PAGE2 = "PAGE2HIGHLIGHT";
        private readonly string PAGE3 = "PAGE3HIGHLIGHT";
        private readonly string PAGE4 = "PAGE4HIGHLIGHT";

        private readonly Vector2 DRAWLOCATION = new Vector2(0, 0);

        private string currentPage;

        private GameInit gameInit;

        public InventoryPaintHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;

            currentPage = PAGE1;
        }

        public void draw(SpriteBatch sb)
        {
            sb.Begin();
            drawInventory(sb);
            sb.End();
        }

        private void drawInventory(SpriteBatch sb)
        {
            if (gameInit.getInventoryKeyHandler().isFadingIn() || gameInit.getInventoryKeyHandler().isFadingOut())
            {
                gameInit.getPaintHandler().drawZone(sb, FADECOLOR);
            }
            sb.Draw(gameInit.getContentHandler().getMenuUIContentHandler().getInventoryImages()[gameInit.getInventoryKeyHandler().getCurrentPage()], DRAWLOCATION + gameInit.getInventoryKeyHandler().getDrawOffset(), WHITECOLOR);
        }

        
    }
}
