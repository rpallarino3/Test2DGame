using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PlayerStuff;
using Environment;
using Menu;
using NPCandEnemies;

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

            if (player.getGlobalLocation().X + player.getXOffset() >= 450 && player.getGlobalLocation().X + player.getXOffset() < currentZone.getWidth() - 450)
            {
                playerDrawLocationX = 450 - player.getXOffset();
                zoneDrawLocationX = -(player.getGlobalLocation().X + player.getXOffset()) + 450;
            }
            else
            {
                if (player.getGlobalLocation().X + player.getXOffset() < 450)
                {
                    playerDrawLocationX = player.getGlobalLocation().X;
                    zoneDrawLocationX = 0;
                }
                else
                {
                    playerDrawLocationX = 900 - (currentZone.getWidth() - player.getGlobalLocation().X);
                    zoneDrawLocationX = -currentZone.getWidth() + 900;
                }
            }
            if (player.getGlobalLocation().Y + player.getYOffset() >= 300 && player.getGlobalLocation().Y + player.getYOffset() < currentZone.getHeight() - 300) // add in the image height stuff
            {
                playerDrawLocationY = 300 - player.getYOffset() - player.getDrawOffsetY();
                zoneDrawLocationY = -(player.getGlobalLocation().Y + player.getYOffset()) + 300;
            }
            else
            {
                if (player.getGlobalLocation().Y + player.getYOffset() < 300)
                {
                    playerDrawLocationY = player.getGlobalLocation().Y - player.getDrawOffsetY();
                    zoneDrawLocationY = 0;
                }
                else
                {
                    playerDrawLocationY = 600 - (currentZone.getHeight() - player.getGlobalLocation().Y + player.getDrawOffsetY());
                    zoneDrawLocationY = -currentZone.getHeight() + 600;
                }
            }

            int drawWindowTopX = player.getGlobalLocation().X - playerDrawLocationX;
            int drawWindowTopY = player.getGlobalLocation().Y - playerDrawLocationY - player.getDrawOffsetY();

            for (int i = 0; i < currentZone.getLevels().Count; i++) //drawing of npcs doesn't work properly
            {
                if (player.getCurrentZoneLevel() == i)
                {
                    g.DrawImage(currentZone.getLevels()[i], new Point(zoneDrawLocationX, zoneDrawLocationY));

                    List<NPC> inFrontNPCs = new List<NPC>();
                    List<NPC> behindNPCs = new List<NPC>();

                    for (int j = 0; j < currentZone.getNPCs().Count; j++)
                    {
                        if (currentZone.getNPCs()[j].getCurrentLocation().Y > player.getGlobalLocation().Y)
                        {
                            inFrontNPCs.Add(currentZone.getNPCs()[j]);
                        }
                        else
                        {
                            behindNPCs.Add(currentZone.getNPCs()[j]);
                        }
                    }
                    drawNPCs(g, behindNPCs, drawWindowTopX, drawWindowTopY, i);
                    drawPlayer(g, player, new Point(playerDrawLocationX, playerDrawLocationY));
                    drawNPCs(g, inFrontNPCs, drawWindowTopX, drawWindowTopY, i);
                    
                }
                else
                {
                    g.DrawImage(currentZone.getLevels()[i], new Point(zoneDrawLocationX, zoneDrawLocationY));
                    drawNPCs(g, currentZone.getNPCs(), drawWindowTopX, drawWindowTopY, i);
                }
            }

            //g.DrawLine(new Pen(Color.Black), new Point(0, 300), new Point(900, 300));
            //g.DrawLine(new Pen(Color.Black), new Point(450, 0), new Point(450, 600));
            //g.DrawLine(new Pen(Color.Blue), new Point(0, playerDrawLocationY + player.getDrawOffsetY()), new Point(900, playerDrawLocationY + player.getDrawOffsetY()));
        }

        private void drawNPCs(Graphics g, List<NPC> npcs, int windowX, int windowY, int currentLevel)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                NPC currentNPC = npcs[i];
                if (currentNPC.getCurrentLevel() == currentLevel)
                {
                    int NPCX = currentNPC.getCurrentLocation().X;
                    int NPCY = currentNPC.getCurrentLocation().Y;
                    int xLeft = NPCX + currentNPC.getWidth();
                    int xRight = NPCX;
                    int yTop = NPCY + currentNPC.getHeight();
                    int yBot = NPCY - currentNPC.getYOffset();

                    if (xLeft > windowX && xRight < windowX + 900 && yTop > windowY && yBot < windowY + 600)
                    {
                        g.DrawImage(npcs[i].getStationaryImage(), new Point(NPCX - windowX, NPCY - windowY - currentNPC.getYOffset()));
                    }
                }
            }
        }

        private void drawPlayer(Graphics g, Player player, Point location)
        {
            g.DrawImage(player.getImage(), location);
        }

        
    }
}

