using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.NPCandEnemies;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.PaintHandlers
{
    class PaintHandler
    {

        private GameInit gameInit;

        private List<Texture2D> currentZoneImages;

        //private readonly Point MENU_DRAW_LOCATION = new Point(0, 0);
        //private Button currentButton;

        public PaintHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            currentZoneImages = new List<Texture2D>();

        }

        public void draw(SpriteBatch sb)
        {
            sb.Begin();
            updateZoneImages(gameInit.getContentHandler().getZoneImages()[gameInit.getZoneFactory().getCurrentZone().getZoneNumber()]);
            drawZone(sb);
            sb.End();
        }

        private void drawZone(SpriteBatch sb)
        {

            float drawWindowTopX = gameInit.getPlayer().getGlobalLocation().X - gameInit.getPlayer().getDrawLocation().X;
            float drawWindowTopY = gameInit.getPlayer().getGlobalLocation().Y - gameInit.getPlayer().getDrawLocation().Y - gameInit.getPlayer().getDrawOffsetY();

            for (int i = 0; i < currentZoneImages.Count; i++)
            {
                if (gameInit.getPlayer().getCurrentZoneLevel() == i)
                {
                    sb.Draw(currentZoneImages[i], gameInit.getZoneFactory().getCurrentZone().getDrawLocation(), Color.White);

                    List<NPC> inFrontNPCs = new List<NPC>();
                    List<NPC> behindNPCs = new List<NPC>();

                    for (int j = 0; j < gameInit.getZoneFactory().getCurrentZone().getNPCs().Count; j++)
                    {
                        if (gameInit.getZoneFactory().getCurrentZone().getNPCs()[j].getCurrentLocation().Y > gameInit.getPlayer().getGlobalLocation().Y)
                        {
                            inFrontNPCs.Add(gameInit.getZoneFactory().getCurrentZone().getNPCs()[j]);
                        }
                        else
                        {
                            behindNPCs.Add(gameInit.getZoneFactory().getCurrentZone().getNPCs()[j]);
                        }
                    }

                    drawNPCs(sb, behindNPCs, drawWindowTopX, drawWindowTopY, i);
                    drawPlayer(sb);
                    drawNPCs(sb, inFrontNPCs, drawWindowTopX, drawWindowTopY, i);
                }
                else
                {
                    sb.Draw(currentZoneImages[i], gameInit.getZoneFactory().getCurrentZone().getDrawLocation(), Color.White);
                    drawNPCs(sb, gameInit.getZoneFactory().getCurrentZone().getNPCs(), drawWindowTopX, drawWindowTopY, i);
                }
            }
        }

        private void drawPlayer(SpriteBatch sb)
        {
            sb.Draw(gameInit.getContentHandler().getPlayerImages()[gameInit.getPlayer().getFacingDirection()], gameInit.getPlayer().getDrawLocation(), Color.White);
            if (gameInit.getPlayer().getSwordOut())
            {
                if (gameInit.getPlayer().getFacingDirection() == gameInit.getPlayer().UP)
                {
                    sb.Draw(gameInit.getContentHandler().getSwordImages()[0], gameInit.getPlayer().getDrawLocation() + new Vector2(8, -20), Color.White);
                }
                else if (gameInit.getPlayer().getFacingDirection() == gameInit.getPlayer().DOWN)
                {
                    sb.Draw(gameInit.getContentHandler().getSwordImages()[1], gameInit.getPlayer().getDrawLocation() + new Vector2(8, 40), Color.White);
                }
                else if (gameInit.getPlayer().getFacingDirection() == gameInit.getPlayer().RIGHT)
                {
                    sb.Draw(gameInit.getContentHandler().getSwordImages()[2], gameInit.getPlayer().getDrawLocation() + new Vector2(25, 25), Color.White);
                }
                else
                {
                    sb.Draw(gameInit.getContentHandler().getSwordImages()[3], gameInit.getPlayer().getDrawLocation() + new Vector2(-25, 25), Color.White);
                }
            }
        }

        private void drawNPCs(SpriteBatch sb, List<NPC> npcs, float windowX, float windowY, int currentLevel)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                NPC currentNPC = npcs[i];
                if (currentNPC.getCurrentLevel() == currentLevel)
                {
                    float NPCX = currentNPC.getCurrentLocation().X;
                    float NPCY = currentNPC.getCurrentLocation().Y;
                    float xLeft = NPCX + currentNPC.getWidth();
                    float xRight = NPCX;
                    float yTop = NPCY + currentNPC.getHeight();
                    float yBot = NPCY - currentNPC.getYOffset();

                    if (xLeft > windowX && xRight < windowX + 900 && yTop > windowY && yBot < windowY + 600)
                    {
                        sb.Draw(gameInit.getContentHandler().getNPCImages()[currentNPC.getName()][0], new Vector2(NPCX - windowX, NPCY - windowY - currentNPC.getYOffset()), Color.White);
                    }
                }
            }
        }

        public void updateZoneImages(List<Texture2D> newImages)
        {
            currentZoneImages = newImages;
        }
    }
}
