using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FunGame.Game.KeyHandlers
{
    class InventoryKeyHandler
    {
        private readonly string PAGE1 = "PAGE1HIGHLIGHT";
        private readonly string PAGE2 = "PAGE2HIGHLIGHT";
        private readonly string PAGE3 = "PAGE3HIGHLIGHT";
        private readonly string PAGE4 = "PAGE4HIGHLIGHT";

        private readonly Keys FLIPPAGELEFT = Keys.D1;
        private readonly Keys FLIPPAGERIGHT = Keys.D2;
        private readonly Keys EXIT1 = Keys.Space;

        private readonly Vector2 NOOFFSET = new Vector2(0, 0);

        private string currentPage;
        private Vector2 drawOffset;
        private List<Vector2> fadeInOffset;
        private List<Vector2> fadeOutOffset;
        private int fadeCounter;
        private bool fadingIn;
        private bool fadingOut;

        private readonly int keyDelayCap = 5;
        private int keyDelay;

        private GameInit gameInit;

        public InventoryKeyHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            currentPage = PAGE1;
            keyDelay = 0;
            fadeCounter = 0;
            drawOffset = new Vector2(0, 0);
            fadingIn = false;
            fadingOut = false;

            fadeInOffset = new List<Vector2>();
            fadeOutOffset = new List<Vector2>();

            fillOffsets();
        }


        public void updateKeys(KeyboardState keyboardState)
        {
            if (fadingIn)
            {
                drawOffset = fadeInOffset[fadeCounter];
                if (fadeCounter == fadeInOffset.Count - 1)
                {
                    fadeCounter = 0;
                    fadingIn = false;
                }
                else
                {
                    fadeCounter++;
                }
            }
            else if (fadingOut)
            {
                drawOffset = fadeOutOffset[fadeCounter];
                if (fadeCounter == fadeOutOffset.Count - 1)
                {
                    fadeCounter = 0;
                    fadingOut = false;
                    gameInit.getGameState().setGameState();
                }
                else
                {
                    fadeCounter++;
                }
            }
            else
            {
                //Console.WriteLine("HERE");
                fadingIn = false;
                fadingOut = false;
                drawOffset = NOOFFSET;

                if (keyDelay < keyDelayCap)
                {
                    keyDelay++;
                }
                else
                {
                    if (keyboardState.IsKeyDown(EXIT1))
                    {
                        fadeOut();
                    }
                    else if (keyboardState.IsKeyDown(FLIPPAGERIGHT) || keyboardState.IsKeyDown(FLIPPAGELEFT))
                    {
                        if (keyboardState.IsKeyDown(FLIPPAGELEFT))
                        {
                            if (currentPage == PAGE1)
                            {
                                currentPage = PAGE4;
                            }
                            else if (currentPage == PAGE2)
                            {
                                currentPage = PAGE1;
                            }
                            else if (currentPage == PAGE3)
                            {
                                currentPage = PAGE2;
                            }
                            else if (currentPage == PAGE4)
                            {
                                currentPage = PAGE3;
                            }
                            keyDelay = 0;
                        }
                        if (keyboardState.IsKeyDown(FLIPPAGERIGHT))
                        {
                            if (currentPage == PAGE1)
                            {
                                currentPage = PAGE2;
                            }
                            else if (currentPage == PAGE2)
                            {
                                currentPage = PAGE3;
                            }
                            else if (currentPage == PAGE3)
                            {
                                currentPage = PAGE4;
                            }
                            else if (currentPage == PAGE4)
                            {
                                currentPage = PAGE1;
                            }
                            keyDelay = 0;
                        }
                    }
                    else
                    {
                    }
                    
                }
            }
            
        }

        private void fillOffsets()
        {
            fadeInOffset.Add(new Vector2(0, -900));
            fadeInOffset.Add(new Vector2(0, -800));
            fadeInOffset.Add(new Vector2(0, -700));
            fadeInOffset.Add(new Vector2(0, -600));
            fadeInOffset.Add(new Vector2(0, -500));
            fadeInOffset.Add(new Vector2(0, -400));
            fadeInOffset.Add(new Vector2(0, -300));
            fadeInOffset.Add(new Vector2(0, -200));
            fadeInOffset.Add(new Vector2(0, -100));
            fadeInOffset.Add(new Vector2(0, 0));

            fadeOutOffset.Add(new Vector2(0, 0));
            fadeOutOffset.Add(new Vector2(0, -100));
            fadeOutOffset.Add(new Vector2(0, -200));
            fadeOutOffset.Add(new Vector2(0, -300));
            fadeOutOffset.Add(new Vector2(0, -400));
            fadeOutOffset.Add(new Vector2(0, -500));
            fadeOutOffset.Add(new Vector2(0, -600));
            fadeOutOffset.Add(new Vector2(0, -700));
            fadeOutOffset.Add(new Vector2(0, -800));
            fadeOutOffset.Add(new Vector2(0, -900));
        }

        public string getCurrentPage()
        {
            return currentPage;
        }

        public void fadeIn()
        {
            fadingIn = true;
            fadeCounter = 0;
            drawOffset = fadeInOffset[fadeCounter];
            fadeCounter++;
        }

        public void fadeOut()
        {
            fadingOut = true;
            fadeCounter = 0;
            drawOffset = fadeOutOffset[fadeCounter];
            fadeCounter++;
        }

        public Vector2 getDrawOffset()
        {
            return drawOffset;
        }

        public bool isFadingOut()
        {
            return fadingOut;
        }

        public bool isFadingIn()
        {
            return fadingIn;
        }
    }
}
