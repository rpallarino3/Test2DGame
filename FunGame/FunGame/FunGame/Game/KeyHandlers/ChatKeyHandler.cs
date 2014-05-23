using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using FunGame.Game.NPCStuff;

namespace FunGame.Game.KeyHandlers
{
    class ChatKeyHandler
    {
        private readonly int keyDelayCap = 6;

        private readonly Keys OPTION_UP = Keys.W;
        private readonly Keys OPTION_DOWN = Keys.S;
        private readonly Keys ADVANCE = Keys.Enter;

        private GameInit gameInit;

        private List<Vector2> fadeInOffset;
        private List<Vector2> fadeOutOffset;
        private int fadeCounter;
        private bool fadingIn;
        private bool fadingOut;
        private int keyDelay;

        private NPC talkingNPC;

        public ChatKeyHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            keyDelay = 0;
        }

        public void updateKeys(KeyboardState keyboardState)
        {
            if (fadingIn)
            {
                if (fadeCounter < 5)
                {
                    fadeCounter++;
                }
                else
                {
                    fadingIn = false;
                    fadeCounter = 0;
                }
            }
            else if (fadingOut)
            {
                if (fadeCounter < 5)
                {
                    fadeCounter++;
                }
                else
                {
                    fadingOut = false;
                    fadeCounter = 0;
                    gameInit.getGameState().setGameState();
                }
            }
            else
            {
                if (keyDelay < keyDelayCap)
                {
                    keyDelay++;
                }
                else
                {
                    if (keyboardState.IsKeyDown(ADVANCE))
                    {
                        keyDelay = 0;
                        string option = talkingNPC.getCurrentChatPage().getOptions()[talkingNPC.getCurrentChatPage().getOptionIndex()];
                        ChatPage newPage = talkingNPC.getCurrentChatPage().getPageDestinations()[option];

                        if (newPage == talkingNPC.getExitPage())
                        {
                            fadeOut();
                        }
                        else
                        {
                            talkingNPC.setCurrentChatPage(newPage);
                            newPage.setOptionIndex(0);
                            newPage.parseString();
                        }
                    }
                    else
                    {
                        if (keyboardState.IsKeyDown(OPTION_UP))
                        {
                            keyDelay = 0;
                            talkingNPC.getCurrentChatPage().moveOptionUp();
                        }
                        if (keyboardState.IsKeyDown(OPTION_DOWN))
                        {
                            keyDelay = 0;
                            talkingNPC.getCurrentChatPage().moveOptionDown();
                        }
                    }
                }
            }
        }

        public void fadeIn(NPC npc)
        {
            fadingIn = true;
            fadeCounter = 0;
            talkingNPC = npc;
            npc.getFirstChatPage().parseString();
            npc.getFirstChatPage().setOptionIndex(0);
            npc.setCurrentChatPage(npc.getFirstChatPage());
        }

        public void fadeOut()
        {
            fadingOut = true;
            fadeCounter = 0;
        }

        public bool isFadingIn()
        {
            return fadingIn;
        }

        public bool isFadingOut()
        {
            return fadingOut;
        }

        public NPC getTalkingNPC()
        {
            return talkingNPC;
        }
    }
}
