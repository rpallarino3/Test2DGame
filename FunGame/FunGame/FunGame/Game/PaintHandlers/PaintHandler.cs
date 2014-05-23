using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.NPCStuff;
using FunGame.Game.Environment;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.PaintHandlers
{
    class PaintHandler
    {

        private GameInit gameInit;

        private List<Texture2D> currentZoneImages;

        private List<Texture2D> fireUINumbers;
        private List<Texture2D> waterUINumbers;
        private List<Texture2D> natureUINumbers;

        private List<Vector2> fireNumberLocations;
        private List<Vector2> waterNumberLocations;
        private List<Vector2> natureNumberLocations;

        //private readonly Point MENU_DRAW_LOCATION = new Point(0, 0);
        //private Button currentButton;

        public PaintHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            currentZoneImages = new List<Texture2D>();

            fireUINumbers = new List<Texture2D>();
            waterUINumbers = new List<Texture2D>();
            natureUINumbers = new List<Texture2D>();

            fireNumberLocations = new List<Vector2>();
            waterNumberLocations = new List<Vector2>();
            natureNumberLocations = new List<Vector2>();

        }

        public void draw(SpriteBatch sb, Color color)
        {
            sb.Begin();
            updateZoneImages(gameInit.getContentHandler().getZoneContentHandler().getZoneImages()[gameInit.getZoneFactory().getCurrentZone().getZoneNumber()]);
            drawZone(sb, color);
            sb.End();
        }

        public void drawZone(SpriteBatch sb, Color color)
        {
            float drawWindowTopX = gameInit.getPlayer().getGlobalLocation().X - gameInit.getPlayer().getDrawLocation().X;
            float drawWindowTopY = gameInit.getPlayer().getGlobalLocation().Y + gameInit.getPlayer().getSize().Y - gameInit.getPlayer().getDrawingSize().Y - gameInit.getPlayer().getDrawLocation().Y;

            for (int i = 0; i < currentZoneImages.Count; i++)
            {
                if (gameInit.getPlayer().getCurrentZoneLevel() == i)
                {
                    sb.Draw(currentZoneImages[i], gameInit.getZoneFactory().getCurrentZone().getDrawLocation(), color);

                    List<Vector2> globalPoints = new List<Vector2>();
                    List<Vector2> drawPoints = new List<Vector2>();
                    List<Texture2D> images = new List<Texture2D>();

                    globalPoints.Add(gameInit.getPlayer().getGlobalLocation());
                    drawPoints.Add(gameInit.getPlayer().getDrawLocation());
                    //images.Add(gameInit.getContentHandler().getPlayerImages()[gameInit.getPlayer().getFacingDirection()]);
                    //Console.WriteLine("Animation Size: " + gameInit.getPlayer().getActiveAnimation().Count);
                    //Console.WriteLine("Animation Index: " + gameInit.getPlayer().getAnimationIndex());
                    images.Add(gameInit.getPlayer().getActiveAnimation()[gameInit.getPlayer().getAnimationIndex()]);

                    if (gameInit.getPlayer().isAbilityAnimationPlaying())
                    {
                        Vector2 location = gameInit.getPlayer().getGlobalLocation() + gameInit.getPlayer().getAbilityAnimationOffset()[gameInit.getPlayer().getAbilityAnimationIndex()];
                        int drawIndex = getIndex(location, globalPoints);
                        drawPoints.Insert(drawIndex, gameInit.getPlayer().getDrawLocation() + gameInit.getPlayer().getAbilityAnimationOffset()[gameInit.getPlayer().getAbilityAnimationIndex()] + new Vector2(0, 15));
                        images.Insert(drawIndex, gameInit.getPlayer().getAbilityAnimation()[gameInit.getPlayer().getAbilityAnimationIndex()]);
                    }
                    
                    List<NPC> npcs = gameInit.getZoneFactory().getCurrentZone().getNPCs();

                    for (int j = 0; j < npcs.Count; j++)
                    {
                        NPC currentNPC = npcs[j];
                        if (currentNPC.getCurrentLevel() == i)
                        {
                            float NPCX = currentNPC.getCurrentLocation().X;
                            float NPCY = currentNPC.getCurrentLocation().Y;
                            float xLeft = NPCX + currentNPC.getSize().X;
                            float xRight = NPCX;
                            float yTop = NPCY + currentNPC.getSize().Y;
                            float yBot = NPCY - currentNPC.getDrawOffset().Y;

                            if (xLeft > drawWindowTopX && xRight < drawWindowTopX + 900 && yTop > drawWindowTopY && yBot < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(NPCX, NPCY), globalPoints);
                                drawPoints.Insert(index, new Vector2(NPCX - drawWindowTopX, NPCY - drawWindowTopY - currentNPC.getDrawOffset().Y));
                                images.Insert(index, currentNPC.getCurrentImage());
                            }
                        }
                    }

                    List<ManipulatableObject> objects = gameInit.getZoneFactory().getCurrentZone().getObjectList();

                    for (int j = 0; j < objects.Count; j++)
                    {
                        ManipulatableObject currentObject = objects[j];
                        if (currentObject.getBottomLevel() == i)
                        {
                            float x = currentObject.getX() * 30;
                            float y = currentObject.getY() * 30;
                            float xLeft = x + currentObject.getWidth();
                            float xRight = x;
                            float yTop = y + 30;
                            float yBot = y - (currentObject.getHeight() - 1) * 30;

                            if (xLeft > drawWindowTopX && xRight < drawWindowTopX + 900 && yTop > drawWindowTopY && yBot < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(x, y), globalPoints);
                                drawPoints.Insert(index, new Vector2(x - drawWindowTopX, yBot - drawWindowTopY) + currentObject.getCurrentOffset());
                                images.Insert(index, currentObject.getCurrentImage());
                            }
                        }
                    }

                    for (int m = 0; m < drawPoints.Count; m++)
                    {
                        sb.Draw(images[m], drawPoints[m], color);
                    }
                }
                else
                {
                    sb.Draw(currentZoneImages[i], gameInit.getZoneFactory().getCurrentZone().getDrawLocation(), color);

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
                            float xLeft = NPCX + currentNPC.getSize().X;
                            float xRight = NPCX;
                            float yTop = NPCY + currentNPC.getSize().Y;
                            float yBot = NPCY - currentNPC.getDrawOffset().Y;

                            if (xLeft > drawWindowTopX && xRight < drawWindowTopX + 900 && yTop > drawWindowTopY && yBot < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(NPCX, NPCY), globalPoints);
                                drawPoints.Insert(index, new Vector2(NPCX - drawWindowTopX, NPCY - drawWindowTopY - currentNPC.getDrawOffset().Y));
                                images.Insert(index, currentNPC.getCurrentImage());
                            }
                        }
                    }

                    List<ManipulatableObject> objects = gameInit.getZoneFactory().getCurrentZone().getObjectList();

                    for (int j = 0; j < objects.Count; j++)
                    {
                        ManipulatableObject currentObject = objects[j];
                        if (currentObject.getBottomLevel() == i)
                        {
                            float x = currentObject.getX() * 30;
                            float y = currentObject.getY() * 30;
                            float xLeft = x + currentObject.getWidth();
                            float xRight = x;
                            float yTop = y + 30;
                            float yBot = y - (currentObject.getHeight() - 1) * 30;

                            if (xLeft > drawWindowTopX && xRight < drawWindowTopX + 900 && yTop > drawWindowTopY && yBot < drawWindowTopY + 600)
                            {
                                int index = getIndex(new Vector2(x, y), globalPoints);
                                drawPoints.Insert(index, new Vector2(x - drawWindowTopX, yBot - drawWindowTopY) + currentObject.getCurrentOffset());
                                images.Insert(index, currentObject.getCurrentImage());
                            }
                        }
                    }

                    for (int m = 0; m < drawPoints.Count; m++)
                    {
                        sb.Draw(images[m], drawPoints[m], color);
                    }
                }
            }

            //draw ui
            sb.Draw(gameInit.getContentHandler().getMenuUIContentHandler().getUIImages()["ENERGYCOUNTER"], new Vector2(0, 0), color);

            getUINumbers();

            for (int i = 0; i < fireUINumbers.Count; i++)
            {
                sb.Draw(fireUINumbers[i], fireNumberLocations[i], color);
            }

            for (int i = 0; i < waterUINumbers.Count; i++)
            {
                sb.Draw(waterUINumbers[i], waterNumberLocations[i], color);
            }

            for (int i = 0; i < natureUINumbers.Count; i++)
            {
                sb.Draw(natureUINumbers[i], natureNumberLocations[i], color);
            }

            sb.Draw(gameInit.getContentHandler().getMenuUIContentHandler().getUIImages()[gameInit.getKeyHandler().getActionHandler().getCurrentAction()], new Vector2(850, 0), color);
        }

        private void getUINumbers()
        {
            fireUINumbers.Clear();
            waterUINumbers.Clear();
            natureUINumbers.Clear();

            fireNumberLocations.Clear();
            waterNumberLocations.Clear();
            natureNumberLocations.Clear();

            int fire = gameInit.getPlayer().getStats().getCurrentFireEnergy();
            int water = gameInit.getPlayer().getStats().getCurrentWaterEnergy();
            int nature = gameInit.getPlayer().getStats().getCurrentNatureEnergy();

            if (fire >= 1000)
            {
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][fire / 1000]);
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(fire / 100) % 10]);
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(fire / 10) % 10]);
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][fire % 10]);

                fireNumberLocations.Add(new Vector2(8, 28));
                fireNumberLocations.Add(new Vector2(18, 28));
                fireNumberLocations.Add(new Vector2(28, 28));
                fireNumberLocations.Add(new Vector2(38, 28));
            }
            else if (fire >= 100)
            {
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(fire / 100)]);
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(fire / 10) % 10]);
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][fire % 10]);

                fireNumberLocations.Add(new Vector2(12, 28));
                fireNumberLocations.Add(new Vector2(22, 28));
                fireNumberLocations.Add(new Vector2(32, 28));
            }
            else if (fire >= 10)
            {
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(fire / 10)]);
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][fire % 10]);

                fireNumberLocations.Add(new Vector2(18, 28));
                fireNumberLocations.Add(new Vector2(28, 28));
            }
            else
            {
                fireUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][fire]);

                fireNumberLocations.Add(new Vector2(22, 28));
            }

            if (water >= 1000)
            {
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][water / 1000]);
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(water / 100) % 10]);
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(water / 10) % 10]);
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][water % 10]);

                waterNumberLocations.Add(new Vector2(8, 48));
                waterNumberLocations.Add(new Vector2(18, 48));
                waterNumberLocations.Add(new Vector2(28, 48));
                waterNumberLocations.Add(new Vector2(38, 48));

            }
            else if (water >= 100)
            {
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(water / 100)]);
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(water / 10) % 10]);
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][water % 10]);

                waterNumberLocations.Add(new Vector2(12, 48));
                waterNumberLocations.Add(new Vector2(22, 48));
                waterNumberLocations.Add(new Vector2(32, 48));
            }
            else if (water >= 10)
            {
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(water / 10)]);
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][water % 10]);

                waterNumberLocations.Add(new Vector2(18, 48));
                waterNumberLocations.Add(new Vector2(28, 48));
            }
            else
            {
                waterUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][water]);

                waterNumberLocations.Add(new Vector2(22, 48));
            }

            if (nature >= 1000)
            {
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][nature / 1000]);
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(nature / 100) % 10]);
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(nature / 10) % 10]);
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][nature % 10]);

                natureNumberLocations.Add(new Vector2(8, 68));
                natureNumberLocations.Add(new Vector2(18, 68));
                natureNumberLocations.Add(new Vector2(28, 68));
                natureNumberLocations.Add(new Vector2(38, 68));
            }
            else if (nature >= 100)
            {
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(nature / 100)]);
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(nature / 10) % 10]);
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][nature % 10]);

                natureNumberLocations.Add(new Vector2(12, 68));
                natureNumberLocations.Add(new Vector2(22, 68));
                natureNumberLocations.Add(new Vector2(32, 68));
            }
            else if (nature >= 10)
            {
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][(nature / 10)]);
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][nature % 10]);

                natureNumberLocations.Add(new Vector2(18, 68));
                natureNumberLocations.Add(new Vector2(28, 68));
            }
            else
            {
                natureUINumbers.Add(gameInit.getContentHandler().getCharacterContentHandler().getNumbers()["SMALLBLACK"][nature]);

                natureNumberLocations.Add(new Vector2(22, 68));
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

        public void updateZoneImages(List<Texture2D> newImages)
        {
            currentZoneImages = newImages;
        }

    }
}
