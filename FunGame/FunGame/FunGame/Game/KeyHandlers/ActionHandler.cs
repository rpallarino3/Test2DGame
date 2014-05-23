using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.NPCStuff;

namespace FunGame.Game.KeyHandlers
{
    class ActionHandler
    {
        private readonly string NONE = "NONE";
        private readonly string ACTIVATE = "ACTIVATE";
        private readonly string ENTER = "ENTER";
        private readonly string INSPECT = "INSPECT";
        private readonly string OPEN = "OPEN";
        private readonly string TALK = "TALK";

        private string currentAction;

        private bool talkToNPC;
        private NPC interactingNPC;

        public ActionHandler()
        {
            talkToNPC = false;
        }

        public void lookForAction(GameInit gameInit)
        {
            // anything that can be interacted with will be at least 1 tile in size and have a size that is a multiple of tile size
            talkToNPC = false;

            int xTile = (int)gameInit.getPlayer().getGlobalLocation().X / 30;
            int yTile = (int)gameInit.getPlayer().getGlobalLocation().Y / 30;

            int xOff = (int)gameInit.getPlayer().getGlobalLocation().X % 30;
            int yOff = (int)gameInit.getPlayer().getGlobalLocation().Y % 30;

            int direction = gameInit.getPlayer().getFacingDirection();

            if (direction == 0)
            {
                if (yOff == 0)
                {
                    checkForNPCs(gameInit);
                }
                else
                {
                    checkForNPCs(gameInit);
                }
            }
            else if (direction == 1)
            {
                if (yOff == 0)
                {
                    checkForNPCs(gameInit);
                }
                else
                {
                    checkForNPCs(gameInit);
                }
            }
            else if (direction == 2)
            {
                if (xOff == 0)
                {
                    checkForNPCs(gameInit);
                }
                else
                {
                    checkForNPCs(gameInit);
                }
            }
            else if (direction == 3)
            {
                if (xOff == 0)
                {
                    checkForNPCs(gameInit);
                }
                else
                {
                    checkForNPCs(gameInit);
                }
            }
        }

        private void checkForNPCs(GameInit gameInit)
        {
            int direction = gameInit.getPlayer().getFacingDirection();

            if (direction == 0)
            {
                int yLocation = (int)gameInit.getPlayer().getGlobalLocation().Y;
                int xLocation = (int)gameInit.getPlayer().getGlobalLocation().X;

                if (yLocation >= 0)
                {
                    for (int i = 0; i < gameInit.getZoneFactory().getCurrentZone().getNPCs().Count; i++)
                    {
                        NPC currentNPC = gameInit.getZoneFactory().getCurrentZone().getNPCs()[i];

                        if (currentNPC.getCurrentLevel() == gameInit.getPlayer().getCurrentZoneLevel())
                        {
                            int npcLocation = (int)currentNPC.getCurrentLocation().Y + (int)currentNPC.getSize().Y - 1;

                            if (npcLocation < yLocation && npcLocation >= yLocation - 5)
                            {
                                if (currentNPC.getCurrentLocation().X >= xLocation && currentNPC.getCurrentLocation().X < xLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                                else if (currentNPC.getCurrentLocation().X + currentNPC.getSize().X - 1 >= xLocation && currentNPC.getCurrentLocation().X + currentNPC.getSize().X - 1 < xLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                            }
                        }

                    }
                }
                if (!talkToNPC)
                {
                    currentAction = NONE;
                }
            }
            else if (direction == 1)
            {
                int yLocation = (int)gameInit.getPlayer().getGlobalLocation().Y;
                int xLocation = (int)gameInit.getPlayer().getGlobalLocation().X;

                if (yLocation < gameInit.getZoneFactory().getCurrentZone().getHeight())
                {
                    for (int i = 0; i < gameInit.getZoneFactory().getCurrentZone().getNPCs().Count; i++)
                    {
                        NPC currentNPC = gameInit.getZoneFactory().getCurrentZone().getNPCs()[i];

                        if (currentNPC.getCurrentLevel() == gameInit.getPlayer().getCurrentZoneLevel())
                        {
                            int npcLocation = (int)currentNPC.getCurrentLocation().Y;

                            if (npcLocation > yLocation + 29 && npcLocation <= yLocation + 29 + 5)
                            {
                                if (currentNPC.getCurrentLocation().X >= xLocation && currentNPC.getCurrentLocation().X < xLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                                else if (currentNPC.getCurrentLocation().X + currentNPC.getSize().X - 1 >= xLocation && currentNPC.getCurrentLocation().X + currentNPC.getSize().X - 1 < xLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                            }
                        }

                    }
                }
                if (!talkToNPC)
                {
                    currentAction = NONE;
                }
            }
            else if (direction == 2)
            {
                int yLocation = (int)gameInit.getPlayer().getGlobalLocation().Y;
                int xLocation = (int)gameInit.getPlayer().getGlobalLocation().X;

                if (xLocation < gameInit.getZoneFactory().getCurrentZone().getWidth())
                {
                    for (int i = 0; i < gameInit.getZoneFactory().getCurrentZone().getNPCs().Count; i++)
                    {
                        NPC currentNPC = gameInit.getZoneFactory().getCurrentZone().getNPCs()[i];

                        if (currentNPC.getCurrentLevel() == gameInit.getPlayer().getCurrentZoneLevel())
                        {
                            int npcLocation = (int)currentNPC.getCurrentLocation().X;

                            if (npcLocation > xLocation + 29 && npcLocation <= xLocation + 29 + 5)
                            {
                                if (currentNPC.getCurrentLocation().Y >= yLocation && currentNPC.getCurrentLocation().Y < yLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                                else if (currentNPC.getCurrentLocation().Y + currentNPC.getSize().Y - 1 >= yLocation && currentNPC.getCurrentLocation().Y + currentNPC.getSize().Y < yLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                            }
                        }

                    }
                }
                if (!talkToNPC)
                {
                    currentAction = NONE;
                }
            }
            else if (direction == 3)
            {
                int yLocation = (int)gameInit.getPlayer().getGlobalLocation().Y;
                int xLocation = (int)gameInit.getPlayer().getGlobalLocation().X;

                if (xLocation >= 0)
                {
                    for (int i = 0; i < gameInit.getZoneFactory().getCurrentZone().getNPCs().Count; i++)
                    {
                        NPC currentNPC = gameInit.getZoneFactory().getCurrentZone().getNPCs()[i];

                        if (currentNPC.getCurrentLevel() == gameInit.getPlayer().getCurrentZoneLevel())
                        {
                            int npcLocation = (int)currentNPC.getCurrentLocation().X + (int)currentNPC.getSize().X - 1;

                            if (npcLocation < xLocation && npcLocation >= xLocation - 5)
                            {
                                if (currentNPC.getCurrentLocation().Y >= yLocation && currentNPC.getCurrentLocation().Y < yLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                                else if (currentNPC.getCurrentLocation().Y + currentNPC.getSize().Y - 1 >= yLocation && currentNPC.getCurrentLocation().Y + currentNPC.getSize().Y < yLocation + 30)
                                {
                                    if (talkToNPC)
                                    {
                                    }
                                    else
                                    {
                                        currentAction = TALK;
                                        talkToNPC = true;
                                        interactingNPC = currentNPC;
                                    }
                                }
                            }
                        }                        
                    }
                }

                if (!talkToNPC)
                {
                    currentAction = NONE;
                }
            }
        }

        public void executeAction(GameInit gameInit)
        {
            if (currentAction == ACTIVATE)
            {
            }
            else if (currentAction == ENTER)
            {
            }
            else if (currentAction == INSPECT)
            {
            }
            else if (currentAction == OPEN)
            {
            }
            else if (currentAction == TALK)
            {
                int direction = gameInit.getPlayer().getFacingDirection();
                
                if (direction == 0)
                {
                    interactingNPC.turn(1);
                    interactingNPC.setNewAnimation(gameInit.getContentHandler().getNPCContentHandler().getNPCImages()[interactingNPC.getName()]["STATIONARY_DOWN"]);
                }
                else if (direction == 1)
                {
                    interactingNPC.turn(0);
                    interactingNPC.setNewAnimation(gameInit.getContentHandler().getNPCContentHandler().getNPCImages()[interactingNPC.getName()]["STATIONARY_UP"]);
                }
                else if (direction == 2)
                {
                    interactingNPC.turn(3);
                    interactingNPC.setNewAnimation(gameInit.getContentHandler().getNPCContentHandler().getNPCImages()[interactingNPC.getName()]["STATIONARY_LEFT"]);
                }
                else if (direction == 3)
                {
                    interactingNPC.turn(2);
                    interactingNPC.setNewAnimation(gameInit.getContentHandler().getNPCContentHandler().getNPCImages()[interactingNPC.getName()]["STATIONARY_RIGHT"]);
                }

                gameInit.getGameState().setChatState();
                gameInit.getChatKeyHandler().fadeIn(interactingNPC);
            }
            
        }

        public string getCurrentAction()
        {
            return currentAction;
        }

        public bool isTalkToNPC()
        {
            return talkToNPC;
        }

        public NPC getInteractingNPC()
        {
            return interactingNPC;
        }
    }
}
