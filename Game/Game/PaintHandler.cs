using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PlayerStuff;
using Environment;
using Menu;

namespace Game
{
    class PaintHandler
    {

        private readonly Point MENU_DRAW_LOCATION = new Point(0, 0);
        private Button currentButton;

        

        public PaintHandler() // need to consolidate all the painting 
        {

        }

        public void drawMenu(Graphics g, MenuFactory menuFactory)
        {
            if (menuFactory.getCurrentMenu().isAnimationFinished())
            {
                g.DrawImage(menuFactory.getCurrentMenu().getMenuImage(), MENU_DRAW_LOCATION);
            }
            else
            {
                g.DrawImage(menuFactory.getCurrentMenu().getAnimationImages()[menuFactory.getCurrentMenu().getAnimationIndex()], MENU_DRAW_LOCATION);
                menuFactory.getCurrentMenu().advanceAnimation();
            }
        }

        public void drawHighlightedMenu(Graphics g, MenuFactory menuFactory)
        {
            currentButton =  menuFactory.getCurrentMenu().getButtons()[menuFactory.getCurrentMenu().getPosition().Y, menuFactory.getCurrentMenu().getPosition().X];
            g.DrawImage(currentButton.getHighlightImage(), currentButton.getLocation());
        }

        public void drawZone(Graphics g, Player player, Zone currentZone)
        {
            int playerDrawLocationX;
            int playerDrawLocationY;
            int zoneDrawLocationX;
            int zoneDrawLocationY;

            if (player.getGlobalLocation().X >= 450 && player.getGlobalLocation().X < currentZone.getWidth() - 450)
            {
                playerDrawLocationX = 450 - player.getXOffset();
                zoneDrawLocationX = -(player.getGlobalLocation().X) + 450;
            }
            else
            {
                if (player.getGlobalLocation().X < 450)
                {
                    playerDrawLocationX = player.getGlobalLocation().X - player.getXOffset();
                    zoneDrawLocationX = 0;
                }
                else
                {
                    playerDrawLocationX = 900 - (currentZone.getWidth() - player.getGlobalLocation().X + player.getXOffset());
                    zoneDrawLocationX = -currentZone.getWidth() + 900;
                }
            }
            if (player.getGlobalLocation().Y >= 300 && player.getGlobalLocation().Y < currentZone.getHeight() - 300)
            {
                playerDrawLocationY = 300 - player.getYOffset();
                zoneDrawLocationY = -(player.getGlobalLocation().Y) + 300;
            }
            else
            {
                if (player.getGlobalLocation().Y < 300)
                {
                    playerDrawLocationY = player.getGlobalLocation().Y - player.getYOffset();
                    zoneDrawLocationY = 0;
                }
                else
                {
                    playerDrawLocationY = 600 - (currentZone.getHeight() - player.getGlobalLocation().Y + player.getYOffset());
                    zoneDrawLocationY = -currentZone.getHeight() + 600;
                }
            }
            for (int i = 0; i < currentZone.getLevels().Count; i++)
            {
                g.DrawImage(currentZone.getLevels()[i], new Point(zoneDrawLocationX, zoneDrawLocationY));
                if (player.getCurrentZoneLevel() == i)
                {
                    drawPlayer(g, player, new Point(playerDrawLocationX, playerDrawLocationY));
                }
            }
        }

        private void drawPlayer(Graphics g, Player player, Point location)
        {
            g.DrawImage(player.getImage(), location);
        }
    }
}

