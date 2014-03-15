using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace FunGame.Game.KeyHandlers
{
    class KeyHandler // add menu moving stuff
    {

        private GameInit gameInit;
        private MovementHandler movementHandler;
        private Dictionary<Keys, int> keyTime;
        private Dictionary<Keys, int> tempKeyTime;

        private IAsyncResult result;

        private int swordCounter;

        public KeyHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            movementHandler = new MovementHandler(gameInit);
            keyTime = new Dictionary<Keys, int>();
            tempKeyTime = new Dictionary<Keys, int>();
            swordCounter = 0;
        }

        private void incrementCounters(Keys[] keysDown)
        {
            tempKeyTime.Clear();

            for (int i = 0; i < keysDown.Length; i++)
            {
                if (keyTime.ContainsKey(keysDown[i]))
                {
                    keyTime[keysDown[i]]++;
                    tempKeyTime.Add(keysDown[i], keyTime[keysDown[i]]);
                }
                else
                {
                    tempKeyTime.Add(keysDown[i], 1);
                }
            }

            keyTime.Clear();

            foreach (KeyValuePair<Keys, int> key in tempKeyTime)
            {
                keyTime.Add(key.Key, key.Value);
            }
        }

        public void updateKeys(KeyboardState keyboardState) // all this needs to be redone for the animations
        {
            incrementCounters(keyboardState.GetPressedKeys()); // all this stuff needs to be cleaned up a lot

            if (gameInit.getGameState().getState() == 0)
            {
                
            }
            else if (gameInit.getGameState().getState() == 1)
            {
                Console.WriteLine("Player Global: " + gameInit.getPlayer().getGlobalLocation());
                Console.WriteLine("Player Draw: " + gameInit.getPlayer().getDrawLocation());

                movementHandler.checkDamage(gameInit.getPlayer(), gameInit.getZoneFactory().getCurrentZone());
                if (!gameInit.getPlayer().isAnimationFinished())
                {
                    //Console.WriteLine("Advancing");
                    gameInit.getPlayer().advanceCurrentAnimation();
                }
                //Console.WriteLine("Priority:" + gameInit.getPlayer().getCurrentAnimationPriority());
                //Console.WriteLine("Sword counter: " + swordCounter);
                if (!gameInit.getPlayer().getSwordOut())
                {
                    setFacingDirection();
                }

                if (gameInit.getPlayer().getCurrentAnimationPriority() <= 2) // need to fix this stuff
                {
                    // priority 2 keys
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        if (gameInit.getPlayer().getCurrentAnimationPriority() <= 1 && swordCounter < 8)
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 0)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWING_SWORD_UP"], "SWING_SWORD_UP");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWING_SWORD_UP"], "BORDER_SWING_SWORD_UP");
                                gameInit.getPlayer().swordOut();
                                swordCounter++;
                            }
                            else if (gameInit.getPlayer().getFacingDirection() == 1)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWING_SWORD_DOWN"], "SWING_SWORD_DOWN");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWING_SWORD_DOWN"], "BORDER_SWING_SWORD_DOWN");
                                gameInit.getPlayer().swordOut();
                                swordCounter++;
                            }
                            else if (gameInit.getPlayer().getFacingDirection() == 2)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWING_SWORD_RIGHT"], "SWING_SWORD_RIGHT");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWING_SWORD_RIGHT"], "BORDER_SWING_SWORD_RIGHT");
                                gameInit.getPlayer().swordOut();
                                swordCounter++;
                            }
                            else if (gameInit.getPlayer().getFacingDirection() == 3)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWING_SWORD_LEFT"], "SWING_SWORD_LEFT");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWING_SWORD_LEFT"], "BORDER_SWING_SWORD_LEFT");
                                gameInit.getPlayer().swordOut();
                                swordCounter++;
                            }

                        }
                        else if (gameInit.getPlayer().getSwordOut() && swordCounter >= 8)
                        {
                            //Console.WriteLine("In stationary sword shit");
                            
                            if (gameInit.getPlayer().getFacingDirection() == 0)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWORD_UP"], "SWORD_UP");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWORD_UP"], "BORDER_SWORD_UP");
                            }
                            else if (gameInit.getPlayer().getFacingDirection() == 1)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWORD_DOWN"], "SWORD_DOWN");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWORD_DOWN"], "BORDER_SWORD_DOWN");
                            }
                            else if (gameInit.getPlayer().getFacingDirection() == 2)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWORD_RIGHT"], "SWORD_RIGHT");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWORD_RIGHT"], "BORDER_SWORD_RIGHT");
                            }
                            else if (gameInit.getPlayer().getFacingDirection() == 3)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["SWORD_LEFT"], "SWORD_LEFT");
                                gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_SWORD_LEFT"], "BORDER_SWORD_LEFT");
                            }

                            if (keyboardState.IsKeyDown(Keys.W))
                            {
                                movementHandler.movePlayerUp(gameInit.getPlayer(), gameInit.getZoneFactory());
                            }
                            if (keyboardState.IsKeyDown(Keys.S))
                            {
                                movementHandler.movePlayerDown(gameInit.getPlayer(), gameInit.getZoneFactory());
                            }
                            if (keyboardState.IsKeyDown(Keys.D))
                            {
                                movementHandler.movePlayerRight(gameInit.getPlayer(), gameInit.getZoneFactory());
                            }
                            if (keyboardState.IsKeyDown(Keys.A))
                            {
                                movementHandler.movePlayerLeft(gameInit.getPlayer(), gameInit.getZoneFactory());
                            }
                            swordCounter++;
                        }
                        else
                        {
                            swordCounter++;
                        }
                    }
                    else
                    {
                        gameInit.getPlayer().swordIn();
                        swordCounter = 0;
                    }
                    
                }

                if (gameInit.getPlayer().getCurrentAnimationPriority() <= 1)
                {
                    // priority 1 keys
                    if (keyboardState.IsKeyDown(Keys.W))
                    {
                        if (gameInit.getPlayer().getCurrentAnimationPriority() <= 0 && gameInit.getPlayer().getFacingDirection() == 0)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_UP"], "WALK_UP");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_WALK_UP"], "BORDER_WALK_UP");
                            movementHandler.movePlayerUp(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                        else
                        {
                            movementHandler.movePlayerUp(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                    }
                    if (keyboardState.IsKeyDown(Keys.S))
                    {
                        if (gameInit.getPlayer().getCurrentAnimationPriority() <= 0 && gameInit.getPlayer().getFacingDirection() == 1)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_DOWN"], "WALK_DOWN");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_WALK_DOWN"], "BORDER_WALK_DOWN");
                            movementHandler.movePlayerDown(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                        else
                        {
                            movementHandler.movePlayerDown(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                    }
                    if (keyboardState.IsKeyDown(Keys.D))
                    {
                        if (gameInit.getPlayer().getCurrentAnimationPriority() <= 0 && gameInit.getPlayer().getFacingDirection() == 2)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_RIGHT"], "WALK_RIGHT");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_WALK_RIGHT"], "BORDER_WALK_RIGHT");
                            movementHandler.movePlayerRight(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                        else
                        {
                            movementHandler.movePlayerRight(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                    }
                    if (keyboardState.IsKeyDown(Keys.A))
                    {
                        if (gameInit.getPlayer().getCurrentAnimationPriority() <= 0 && gameInit.getPlayer().getFacingDirection() == 3)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_LEFT"], "WALK_LEFT");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_WALK_LEFT"], "BORDER_WALK_LEFT");
                            movementHandler.movePlayerLeft(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                        else
                        {
                            movementHandler.movePlayerLeft(gameInit.getPlayer(), gameInit.getZoneFactory());
                        }
                    }

                }

                if (gameInit.getPlayer().getCurrentAnimationPriority() <= 0)
                {
                    // priority 0 keys
                    if (gameInit.getPlayer().getCurrentAnimationPriority() <= 0)
                    {
                        int direction = gameInit.getPlayer().getFacingDirection();
                        if (direction == 0)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_UP"], "STATIONARY_UP");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_STATIONARY_UP"], "BORDER_STATIONARY_UP");
                        }
                        else if (direction == 1)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_DOWN"], "STATIONARY_DOWN");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_STATIONARY_DOWN"], "BORDER_STATIONARY_DOWN");
                        }
                        else if (direction == 2)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_RIGHT"], "STATIONARY_RIGHT");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_STATIONARY_RIGHT"], "BORDER_STATIONARY_RIGHT");
                        }
                        else if (direction == 3)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_LEFT"], "STATIONARY_LEFT");
                            gameInit.getPlayer().setNewBorderAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["BORDER_STATIONARY_LEFT"], "BORDER_STATIONARY_LEFT");
                        }
                    }
                }

                if (gameInit.getPlayer().isAnimationFinished())
                {
                    gameInit.getPlayer().finishAnimation();
                }
                
            }

            
        }

        private void setFacingDirection()
        {
            int upTime = 0;
            int downTime = 0;
            int rightTime = 0;
            int leftTime = 0;

            if (keyTime.ContainsKey(Keys.W))
            {
                upTime = keyTime[Keys.W];
            }
            if (keyTime.ContainsKey(Keys.S))
            {
                downTime = keyTime[Keys.S];
            }
            if (keyTime.ContainsKey(Keys.D))
            {
                rightTime = keyTime[Keys.D];
            }
            if (keyTime.ContainsKey(Keys.A))
            {
                leftTime = keyTime[Keys.A];
            }

            if (upTime == 0 && downTime == 0 && rightTime == 0 && leftTime == 0)
            {
                gameInit.getPlayer().setFacingDirection(gameInit.getPlayer().getFacingDirection());
            }
            else
            {
                int greatest = upTime;
                int direction = gameInit.getPlayer().UP;

                if (downTime > greatest)
                {
                    greatest = downTime;
                    direction = gameInit.getPlayer().DOWN;
                }
                if (rightTime > greatest)
                {
                    greatest = rightTime;
                    direction = gameInit.getPlayer().RIGHT;
                }
                if (leftTime > greatest)
                {
                    greatest = leftTime;
                    direction = gameInit.getPlayer().LEFT;
                }
                gameInit.getPlayer().setFacingDirection(direction);
            }
            
        }

        public MovementHandler getMovementHandler()
        {
            return movementHandler;
        }
    }
}
