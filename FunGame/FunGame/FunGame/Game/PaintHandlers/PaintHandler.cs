using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.NPCStuff;
using FunGame.Game.EnemyStuff;

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

                    List<Vector2> globalPoints = new List<Vector2>();
                    List<Vector2> drawPoints = new List<Vector2>();
                    List<Texture2D> images = new List<Texture2D>();
                    
                    globalPoints.Add(gameInit.getPlayer().getGlobalLocation());
                    drawPoints.Add(gameInit.getPlayer().getDrawLocation());
                    //images.Add(gameInit.getContentHandler().getPlayerImages()[gameInit.getPlayer().getFacingDirection()]);
                    Console.WriteLine("Animation Size: " + gameInit.getPlayer().getActiveAnimation().Count);
                    images.Add(gameInit.getPlayer().getActiveAnimation()[gameInit.getPlayer().getAnimationIndex()]);

                    List<NPC> npcs = gameInit.getZoneFactory().getCurrentZone().getNPCs();

                    for (int j = 0; j < npcs.Count; j++)
                    {
                        NPC currentNPC = npcs[j];
                        if (currentNPC.getCurrentLevel() == i)
                        {
                            float NPCX = currentNPC.getCurrentLocation().X;
                            float NPCY = currentNPC.getCurrentLocation().Y;
                            float xLeft = NPCX + currentNPC.getWidth();
                            float xRight = NPCX;
                            float yTop = NPCY + currentNPC.getHeight();
                            float yBot = NPCY - currentNPC.getYOffset();

                            if (xLeft > drawWindowTopX && xRight < drawWindowTopX + 900 && yTop > drawWindowTopY && yBot < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(NPCX, NPCY), globalPoints);
                                drawPoints.Insert(index, new Vector2(NPCX - drawWindowTopX, NPCY - drawWindowTopY - currentNPC.getYOffset()));
                                images.Insert(index, gameInit.getContentHandler().getNPCImages()[currentNPC.getName()][0]);
                            }
                        }
                    }

                    List<Enemy> enemies = gameInit.getZoneFactory().getCurrentZone().getEnemies();

                    for (int k = 0; k < enemies.Count; k++)
                    {
                        Enemy currentEnemy = enemies[k];
                        if (currentEnemy.getCurrentZoneLevel() == i)
                        {
                            float enemyX = currentEnemy.getLocation().X;
                            float enemyY = currentEnemy.getLocation().Y;
                            float xLeft = enemyX;
                            float xRight = enemyX + currentEnemy.getSize().X;
                            float yTop = enemyY - currentEnemy.getSize().Y + currentEnemy.getWalkingSize().Y;
                            float yBot = enemyY + currentEnemy.getWalkingSize().Y;

                            if (xRight > drawWindowTopX && xLeft < drawWindowTopX + 900 && yBot > drawWindowTopY && yTop < drawWindowTopX + 600)
                            {
                                int index = getIndex(new Vector2(enemyX, enemyY), globalPoints);
                                drawPoints.Insert(index, new Vector2(xLeft - drawWindowTopX, yTop - drawWindowTopY));
                                images.Insert(index, gameInit.getContentHandler().getGoblinImages()[0]); // fix this to reflect enemy type
                            }
                        }
                    }

                    //add one for enemies too, and anything else
                    List<EnemySpawner> es = gameInit.getZoneFactory().getCurrentZone().getEnemySpawners();

                    for (int l = 0; l < es.Count; l++)
                    {
                        EnemySpawner currentSpawner = es[l];
                        if (currentSpawner.getZoneLevel() == i)
                        {
                            float spawnerXLeft = currentSpawner.getLocation().X;
                            float spawnerYTop = currentSpawner.getLocation().Y;
                            float spawnerXRight = spawnerXLeft + currentSpawner.getWidth();
                            float spawnerYBottom = spawnerYTop + currentSpawner.getHeight();

                            if (spawnerXRight > drawWindowTopX && spawnerXLeft < drawWindowTopX + 900 && spawnerYBottom > drawWindowTopY && spawnerYTop < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(spawnerXLeft, spawnerYTop), globalPoints);
                                drawPoints.Insert(index, new Vector2(spawnerXLeft - drawWindowTopX, spawnerYTop - drawWindowTopY));
                                images.Insert(index, gameInit.getContentHandler().getSpawnerImages()[currentSpawner.getType()][0]);
                            }
                        }
                    }

                    for (int m = 0; m < drawPoints.Count; m++)
                    {
                        sb.Draw(images[m], drawPoints[m], Color.White);
                    }
                }
                else
                {
                    sb.Draw(currentZoneImages[i], gameInit.getZoneFactory().getCurrentZone().getDrawLocation(), Color.White);

                    List<Vector2> globalPoints = new List<Vector2>();
                    List<Vector2> drawPoints = new List<Vector2>();
                    List<Texture2D> images = new List<Texture2D>();

                    List<NPC> npcs = gameInit.getZoneFactory().getCurrentZone().getNPCs();

                    for (int j = 0; j < gameInit.getZoneFactory().getCurrentZone().getNPCs().Count; j++)
                    {
                        NPC currentNPC = npcs[j];
                        if (currentNPC.getCurrentLevel() == i)
                        {
                            float NPCX = currentNPC.getCurrentLocation().X;
                            float NPCY = currentNPC.getCurrentLocation().Y;
                            float xLeft = NPCX + currentNPC.getWidth();
                            float xRight = NPCX;
                            float yTop = NPCY + currentNPC.getHeight();
                            float yBot = NPCY - currentNPC.getYOffset();

                            if (xLeft > drawWindowTopX && xRight < drawWindowTopX + 900 && yTop > drawWindowTopY && yBot < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(NPCX, NPCY), globalPoints);
                                drawPoints.Insert(index, new Vector2(NPCX - drawWindowTopX, NPCY - drawWindowTopY - currentNPC.getYOffset()));
                                images.Insert(index, gameInit.getContentHandler().getNPCImages()[currentNPC.getName()][0]);
                            }
                        }
                    }

                    List<Enemy> enemies = gameInit.getZoneFactory().getCurrentZone().getEnemies();

                    for (int k = 0; k < enemies.Count; k++)
                    {
                        Enemy currentEnemy = enemies[k];
                        if (currentEnemy.getCurrentZoneLevel() == i)
                        {
                            float enemyX = currentEnemy.getLocation().X;
                            float enemyY = currentEnemy.getLocation().Y;
                            float xLeft = enemyX;
                            float xRight = enemyX + currentEnemy.getSize().X;
                            float yTop = enemyY - currentEnemy.getSize().Y + currentEnemy.getWalkingSize().Y;
                            float yBot = enemyY + currentEnemy.getWalkingSize().Y;

                            if (xRight > drawWindowTopX && xLeft < drawWindowTopX + 900 && yBot > drawWindowTopY && yTop < drawWindowTopX + 600)
                            {
                                int index = getIndex(new Vector2(enemyX, enemyY), globalPoints);
                                drawPoints.Insert(index, new Vector2(xLeft - drawWindowTopX, yTop - drawWindowTopY));
                                images.Insert(index, gameInit.getContentHandler().getGoblinImages()[0]); // fix this to reflect enemy type
                            }
                        }
                    }

                    //add one for enemies too, and anything else
                    List<EnemySpawner> es = new List<EnemySpawner>();

                    for (int l = 0; l < gameInit.getZoneFactory().getCurrentZone().getEnemySpawners().Count; l++)
                    {
                        EnemySpawner currentSpawner = es[l];
                        if (currentSpawner.getZoneLevel() == i)
                        {
                            float spawnerXLeft = currentSpawner.getLocation().X;
                            float spawnerYTop = currentSpawner.getLocation().Y;
                            float spawnerXRight = spawnerXLeft + currentSpawner.getWidth();
                            float spawnerYBottom = spawnerYTop + currentSpawner.getHeight();

                            if (spawnerXRight > drawWindowTopX && spawnerXLeft < drawWindowTopX + 900 && spawnerYBottom > drawWindowTopY && spawnerYTop < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(spawnerXLeft, spawnerYTop), globalPoints);
                                drawPoints.Insert(index, new Vector2(spawnerXLeft - drawWindowTopX, spawnerYTop - drawWindowTopY));
                                images.Insert(index, gameInit.getContentHandler().getSpawnerImages()[currentSpawner.getType()][0]);
                            }
                        }
                    }

                    for (int m = 0; m < drawPoints.Count; m++)
                    {
                        sb.Draw(images[m], drawPoints[m], Color.White);
                    }
                }
            }
        }

        private int getIndex(Vector2 point, List<Vector2> globalPoints)
        {
            int index = 0;
            if (globalPoints.Count == 0)
            {
                globalPoints.Insert(0, point);
                return index;
            }
            else
            {
                for (int i = 0; i < globalPoints.Count; i++)
                {
                    if (point.Y < globalPoints[i].Y)
                    {
                        index = i;
                        globalPoints.Insert(i, point);
                        return index;
                    }
                }
                globalPoints.Insert(globalPoints.Count, point);
                return globalPoints.Count - 1;
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

        public void updateZoneImages(List<Texture2D> newImages)
        {
            currentZoneImages = newImages;
        }

    }
}
