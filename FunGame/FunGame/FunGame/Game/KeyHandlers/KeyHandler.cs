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

        public void updateKeys(KeyboardState keyboardState)
        {
            incrementCounters(keyboardState.GetPressedKeys());

            if (gameInit.getGameState().getState() == 0)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    gameInit.getGameState().setGameState(); // on transition to game state we should create all the zones based on the players current location
                    // that way we can use the content files in the creation of things
                }
            }
            else if (gameInit.getGameState().getState() == 1)
            {
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
                setFacingDirection();

                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    gameInit.getPlayer().swordOut();
                    swordCounter++;
                }
                else if (swordCounter > 10)
                {
                    gameInit.getPlayer().swordIn();
                    swordCounter = 0;
                }
                else if (swordCounter > 0 && swordCounter <= 10)
                {
                    swordCounter++;
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
