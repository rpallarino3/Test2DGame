using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using FunGame.Game.Environment;
using FunGame.Game.Environment.ZoneTiles;

namespace FunGame.Game.KeyHandlers
{
    class KeyHandler // add menu moving stuff
    {

        private GameInit gameInit;
        private MovementHandler movementHandler;
        private ActionHandler actionHandler;
        private Dictionary<Keys, int> keyTime;
        private Dictionary<Keys, int> tempKeyTime;

        private bool environmentAnimation;
        private bool jumping;
        private bool sliding;
        private bool pushing;
        private bool walking;
        private bool draining;
        private bool casting;

        private readonly Keys UP_MOVE = Keys.W;
        private readonly Keys DOWN_MOVE = Keys.S;
        private readonly Keys RIGHT_MOVE = Keys.D;
        private readonly Keys LEFT_MOVE = Keys.A;

        private readonly Keys FEED = Keys.D1;
        private readonly Keys DRAIN = Keys.D3;
        private readonly Keys RELEASE = Keys.D2;
        private readonly Keys CYCLE_RIGHT = Keys.E;
        private readonly Keys CYCLE_LEFT = Keys.Q;
        private readonly Keys ACTION = Keys.Enter;

        private readonly Keys PAUSE = Keys.Space;
        //might want to change this class to set key flags that go on when certain keys are pressed
        
        private int pushingCounter;
        private ManipulatableObject animatingObject;
        private List<ManipulatableObject> manipulatedObjects;

        private List<ZoneTile> drainTiles;
        private int drainCounter;
        private Vector2 drainCenter;
        private int drainRadius;

        private bool moveUpFlag;
        private bool moveDownFlag;
        private bool moveRightFlag;
        private bool moveLeftFlag;

        private int pushThreshold = 10;
        private bool pauseFlag;

        public KeyHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            movementHandler = new MovementHandler(gameInit);
            actionHandler = new ActionHandler();
            keyTime = new Dictionary<Keys, int>();
            tempKeyTime = new Dictionary<Keys, int>();

            environmentAnimation = false;
            jumping = false;
            sliding = false;
            pushing = false;
            walking = false;
            casting = false;
            draining = false;

            moveUpFlag = false;
            moveDownFlag = false;
            moveRightFlag = false;
            moveLeftFlag = false;

            pauseFlag = false;

            pushingCounter = 0;
            drainCounter = 0;
            drainRadius = 0;
            manipulatedObjects = new List<ManipulatableObject>();
            drainTiles = new List<ZoneTile>();
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
            // don't need animation priority anymore, animations are just standing, walking, or doing an action
            // actions can override walking and walking can override standing
            if (gameInit.getGameState().getState() == 0)
            {
                
            }
            else if (gameInit.getGameState().getState() == 1)
            {
                movementHandler.resetDistances();
                moveUpFlag = false;
                moveDownFlag = false;
                moveRightFlag = false;
                moveLeftFlag = false;

                cleanManipulatedObjects(gameInit);
                animateObjects(gameInit);
                //Console.WriteLine("Player Global: " + gameInit.getPlayer().getGlobalLocation());
                //Console.WriteLine("Player Draw: " + gameInit.getPlayer().getDrawLocation());
                //Console.WriteLine(gameInit.getZoneFactory().getCurrentZone().getManipulationMap().isObject(gameInit.getPlayer().getCurrentZoneLevel(), (int)gameInit.getPlayer().getGlobalLocation().Y / 30, (int)gameInit.getPlayer().getGlobalLocation().X / 30));
                if (environmentAnimation || casting || jumping || sliding || draining)
                {
                    if (keyboardState.IsKeyDown(PAUSE))
                    {
                        pauseFlag = true;
                    }
                    if (environmentAnimation) //something weird is still going on here
                    {
                        if (animatingObject.isAnimationFinished())
                        {
                            environmentAnimation = false;
                            animatingObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "STATIONARY");
                        }
                        else
                        {
                            animatingObject.advanceAnimation();
                        }
                    }
                    else if (casting)
                    {
                        if (gameInit.getPlayer().isAnimationFinished())
                        {
                            casting = false;

                            int direction = gameInit.getPlayer().getFacingDirection();

                            if (direction == 0)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_UP"]);
                            }
                            else if (direction == 1)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_DOWN"]);
                            }
                            else if (direction == 2)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_RIGHT"]);
                            }
                            else if (direction == 3)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_LEFT"]);
                            }
                        }
                        else
                        {
                            gameInit.getPlayer().advanceCurrentAnimation();
                        }
                    }
                    else if (draining)
                    {
                        if (keyboardState.IsKeyDown(DRAIN))
                        {
                            if (gameInit.getPlayer().isAnimationFinished())
                            {
                                int direction = gameInit.getPlayer().getFacingDirection();

                                if (direction == 0)
                                {
                                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["CONTINUOUS_DRAIN_UP"]);
                                }
                                else if (direction == 1)
                                {
                                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["CONTINUOUS_DRAIN_DOWN"]);
                                }
                                else if (direction == 2)
                                {
                                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["CONTINUOUS_DRAIN_RIGHT"]);
                                }
                                else if (direction == 3)
                                {
                                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["CONTINUOUS_DRAIN_LEFT"]);
                                }
                            }
                            else
                            {
                                gameInit.getPlayer().advanceCurrentAnimation();
                            }

                            if (drainRadius == 60)
                            {                                
                                if (gameInit.getPlayer().isAbilityAnimationFinished())
                                {
                                    int direction = gameInit.getPlayer().getFacingDirection();

                                    if (direction == 0)
                                    {
                                        gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["MAXDRAINUP"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["MAXDRAINUP"]);
                                    }
                                    else if (direction == 1)
                                    {
                                        gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["MAXDRAINDOWN"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["MAXDRAINDOWN"]);
                                    }
                                    else if (direction == 2)
                                    {
                                        gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["MAXDRAINRIGHT"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["MAXDRAINRIGHT"]);
                                    }
                                    else if (direction == 3)
                                    {
                                        gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["MAXDRAINLEFT"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["MAXDRAINLEFT"]);
                                    }
                                }
                                else
                                {
                                    gameInit.getPlayer().advanceAbilityAnimation();
                                }
                            }
                            else
                            {
                                drainRadius++;
                                gameInit.getPlayer().advanceAbilityAnimation();
                            }
                        }
                        else
                        {
                            gameInit.getPlayer().finishAbilityAnimation();
                            draining = false;

                            int direction = gameInit.getPlayer().getFacingDirection();

                            if (direction == 0)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["RELEASE_UP"]);
                            }
                            else if (direction == 1)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["RELEASE_DOWN"]);
                            }
                            else if (direction == 2)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["RELEASE_RIGHT"]);
                            }
                            else if (direction == 3)
                            {
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["RELEASE_LEFT"]);
                            }

                            casting = true;

                            drain(gameInit);
                        }
                    }
                    else if (jumping)
                    {
                        gameInit.getPlayer().advanceCurrentAnimation();
                        gameInit.getPlayer().setGlobalLocation(gameInit.getPlayer().getGlobalLocation() + gameInit.getPlayer().getJumpOffset()[gameInit.getPlayer().getAnimationIndex()]);

                        if (gameInit.getPlayer().isAnimationFinished())
                        {
                            jumping = false;
                        }

                        movementHandler.updateDrawLocations(gameInit.getPlayer(), gameInit.getZoneFactory().getCurrentZone());

                    }
                    else
                    {
                        gameInit.getPlayer().advanceCurrentAnimation();

                        if (gameInit.getPlayer().isAnimationFinished())
                        {
                            sliding = false;
                        }
                    }
                }
                else if (pushing)
                {
                    setFacingDirection();
                    lookForAction(gameInit);
                    // add the object to the manipulated objects list
                    if (keyboardState.IsKeyDown(PAUSE) || pauseFlag)
                    {
                        pause(gameInit);
                    }
                    else if (keyboardState.IsKeyDown(ACTION) && actionHandler.getCurrentAction() != "NONE")
                    {
                        executeAction(gameInit);
                    }
                    else if (keyboardState.IsKeyDown(FEED) || keyboardState.IsKeyDown(DRAIN) || keyboardState.IsKeyDown(RELEASE))
                    {
                        pushing = false;
                        pushingCounter = 0;

                        if (keyboardState.IsKeyDown(DRAIN))
                        {
                            draining = true;
                            beginDrain(gameInit);
                        }
                    }
                    else
                    {
                        int direction = gameInit.getPlayer().getFacingDirection();
                        int tileX = (int)gameInit.getPlayer().getGlobalLocation().X / 30;
                        int tileY = (int)gameInit.getPlayer().getGlobalLocation().Y / 30;
                        int xOff = (int)gameInit.getPlayer().getGlobalLocation().X % 30;
                        int yOff = (int)gameInit.getPlayer().getGlobalLocation().Y % 30;

                        if (!keyboardState.IsKeyDown(UP_MOVE) && !keyboardState.IsKeyDown(DOWN_MOVE) && !keyboardState.IsKeyDown(RIGHT_MOVE) && !keyboardState.IsKeyDown(LEFT_MOVE))
                        {
                            pushing = false;
                            pushingCounter = 0;
                            setStationaryAnimation(gameInit);
                        }
                        else
                        {
                            if (direction == 0)
                            {
                                if (yOff == 0 && tileY > 1)
                                {
                                    if (xOff == 0)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        pushObject(gameInit, pushingTile, destination);
                                    }
                                    else if (xOff < 15)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 1, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 2, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                    }
                                    else
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 1, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 2, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                    }
                                }
                                if (pushing == true)
                                {
                                    checkIfPushContinue(gameInit, keyboardState);
                                }
                            }
                            else if (direction == 1)
                            {
                                if (yOff == 0 && tileY < gameInit.getZoneFactory().getCurrentZone().getTileHeight() - 1)
                                {
                                    if (xOff == 0)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        pushObject(gameInit, pushingTile, destination);
                                    }
                                    else if (xOff < 15)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 2, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }

                                    }
                                    else
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 2, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }

                                    }

                                }

                                if (pushing == true)
                                {
                                    checkIfPushContinue(gameInit, keyboardState);
                                }
                            }
                            else if (direction == 2)
                            {
                                if (xOff == 0 && tileX < gameInit.getZoneFactory().getCurrentZone().getTileWidth() - 1)
                                {
                                    if (yOff == 0)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 2, gameInit.getPlayer().getCurrentZoneLevel());
                                        pushObject(gameInit, pushingTile, destination);
                                    }
                                    else if (yOff < 15)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 2, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX + 2, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                    }
                                    else
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX + 2, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 2, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                    }
                                }
                                if (pushing == true)
                                {
                                    checkIfPushContinue(gameInit, keyboardState);
                                }
                            }
                            else if (direction == 3)
                            {
                                if (xOff == 0 && tileX > 1)
                                {
                                    if (yOff == 0)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 2, gameInit.getPlayer().getCurrentZoneLevel());
                                        pushObject(gameInit, pushingTile, destination);
                                    }
                                    else if (yOff < 15)
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 2, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX - 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX - 2, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                    }
                                    else
                                    {
                                        ZoneTile pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX - 1, gameInit.getPlayer().getCurrentZoneLevel());
                                        ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX - 2, gameInit.getPlayer().getCurrentZoneLevel());
                                        if (pushingTile.isFull())
                                        {
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                        else
                                        {
                                            pushingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 1, gameInit.getPlayer().getCurrentZoneLevel());
                                            destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 2, gameInit.getPlayer().getCurrentZoneLevel());
                                            pushObject(gameInit, pushingTile, destination);
                                        }
                                    }
                                }
                                if (pushing == true)
                                {
                                    checkIfPushContinue(gameInit, keyboardState);
                                }
                            }
                        }
                    }
                    if (pushing == false)
                    {
                        movePlayer(gameInit);
                    }

                }
                else if (walking)
                {
                    setFacingDirection();
                    lookForAction(gameInit);
                    if (keyboardState.IsKeyDown(PAUSE) || pauseFlag)
                    {
                        pause(gameInit);
                    }
                    else if (keyboardState.IsKeyDown(ACTION) && actionHandler.getCurrentAction() != "NONE") 
                    {
                        executeAction(gameInit);
                    }
                    else if (keyboardState.IsKeyDown(FEED) || keyboardState.IsKeyDown(DRAIN) || keyboardState.IsKeyDown(RELEASE))
                    {
                        walking = false;
                        pushingCounter = 0;

                        if (keyboardState.IsKeyDown(DRAIN))
                        {
                            draining = true;
                            beginDrain(gameInit);
                        }
                    }
                    else
                    {
                        if (keyboardState.IsKeyDown(UP_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 0)
                            {
                                if (pushingCounter >= pushThreshold)
                                {
                                    if (gameInit.getPlayer().getGlobalLocation().Y % 30 != 0)
                                    {
                                        pushing = true;
                                        walking = false;
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_UP"]);
                                    }
                                    else
                                    {
                                        if (gameInit.getPlayer().getGlobalLocation().X % 30 != 0)
                                        {
                                            pushing = true;
                                            walking = false;
                                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_UP"]);
                                        }
                                        else
                                        {
                                            int tileY = (int)gameInit.getPlayer().getGlobalLocation().Y / 30; // need to check the tile you are jumping across
                                            int tileX = (int)gameInit.getPlayer().getGlobalLocation().X / 30;

                                            if (tileY > 1)
                                            {
                                                ZoneTile jumpingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                                ZoneTile destinationTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY - 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());

                                                jump(gameInit, jumpingTile, destinationTile);
                                            }
                                            else
                                            {
                                                pushing = true;
                                                walking = false;
                                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_UP"]);
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    if (gameInit.getPlayer().isAnimationFinished())
                                    {
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_UP"]);
                                    }
                                    else
                                    {
                                        gameInit.getPlayer().advanceCurrentAnimation();
                                    }
                                    moveUpFlag = true;
                                }
                            }
                            else
                            {
                                moveUpFlag = true;
                            }
                        }
                        if (keyboardState.IsKeyDown(DOWN_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 1)
                            {
                                if (pushingCounter >= pushThreshold)
                                {
                                    if (gameInit.getPlayer().getGlobalLocation().Y % 30 != 0)
                                    {
                                        pushing = true;
                                        walking = false;
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_DOWN"]);
                                    }
                                    else
                                    {
                                        if (gameInit.getPlayer().getGlobalLocation().X % 30 != 0)
                                        {
                                            pushing = true;
                                            walking = false;
                                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_DOWN"]);
                                        }
                                        else
                                        {
                                            int tileY = (int)gameInit.getPlayer().getGlobalLocation().Y / 30;
                                            int tileX = (int)gameInit.getPlayer().getGlobalLocation().X / 30;

                                            if (tileY < gameInit.getZoneFactory().getCurrentZone().getTileHeight() - 2)
                                            {

                                                ZoneTile jumpingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 1, tileX, gameInit.getPlayer().getCurrentZoneLevel());
                                                ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY + 2, tileX, gameInit.getPlayer().getCurrentZoneLevel());

                                                jump(gameInit, jumpingTile, destination);
                                            }
                                            else
                                            {
                                                pushing = true;
                                                walking = false;
                                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_DOWN"]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (gameInit.getPlayer().isAnimationFinished())
                                    {
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_DOWN"]);
                                    }
                                    else
                                    {
                                        gameInit.getPlayer().advanceCurrentAnimation();
                                    }
                                    moveDownFlag = true;
                                }
                            }
                            else
                            {
                                moveDownFlag = true;
                            }
                        }
                        if (keyboardState.IsKeyDown(RIGHT_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 2)
                            {
                                if (pushingCounter >= pushThreshold)
                                {
                                    if (gameInit.getPlayer().getGlobalLocation().X % 30 != 0)
                                    {
                                        pushing = true;
                                        walking = false;
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_RIGHT"]);
                                    }
                                    else
                                    {
                                        if (gameInit.getPlayer().getGlobalLocation().X % 30 != 0)
                                        {
                                            pushing = true;
                                            walking = false;
                                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_UP"]);
                                        }
                                        else
                                        {
                                            int tileY = (int)gameInit.getPlayer().getGlobalLocation().Y / 30;
                                            int tileX = (int)gameInit.getPlayer().getGlobalLocation().X / 30;

                                            if (tileX < gameInit.getZoneFactory().getCurrentZone().getTileWidth() - 2)
                                            {
                                                ZoneTile jumpingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 1, gameInit.getPlayer().getCurrentZoneLevel());
                                                ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX + 2, gameInit.getPlayer().getCurrentZoneLevel());

                                                jump(gameInit, jumpingTile, destination);
                                            }
                                            else
                                            {
                                                pushing = true;
                                                walking = false;
                                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_RIGHT"]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (gameInit.getPlayer().isAnimationFinished())
                                    {
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_RIGHT"]);
                                    }
                                    else
                                    {
                                        gameInit.getPlayer().advanceCurrentAnimation();
                                    }
                                    moveRightFlag = true;
                                }
                            }
                            else
                            {
                                moveRightFlag = true;
                            }
                        }
                        if (keyboardState.IsKeyDown(LEFT_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 3)
                            {
                                if (pushingCounter >= pushThreshold)
                                {
                                    if (gameInit.getPlayer().getGlobalLocation().X % 30 != 0)
                                    {
                                        pushing = true;
                                        walking = false;
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_LEFT"]);
                                    }
                                    else
                                    {
                                        if (gameInit.getPlayer().getGlobalLocation().X % 30 != 0)
                                        {
                                            pushing = true;
                                            walking = false;
                                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_UP"]);
                                        }
                                        else
                                        {
                                            int tileY = (int)gameInit.getPlayer().getGlobalLocation().Y / 30;
                                            int tileX = (int)gameInit.getPlayer().getGlobalLocation().X / 30;

                                            if (tileX > 1)
                                            {
                                                ZoneTile jumpingTile = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 1, gameInit.getPlayer().getCurrentZoneLevel());
                                                ZoneTile destination = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(tileY, tileX - 2, gameInit.getPlayer().getCurrentZoneLevel());

                                                jump(gameInit, jumpingTile, destination);
                                            }
                                            else
                                            {
                                                pushing = true;
                                                walking = false;
                                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_LEFT"]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (gameInit.getPlayer().isAnimationFinished())
                                    {
                                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_LEFT"]);
                                    }
                                    else
                                    {
                                        gameInit.getPlayer().advanceCurrentAnimation();
                                    }
                                    moveLeftFlag = true;
                                }
                            }
                            else
                            {
                                moveLeftFlag = true;
                            }
                        }

                        if (!keyboardState.IsKeyDown(LEFT_MOVE) && !keyboardState.IsKeyDown(RIGHT_MOVE) && !keyboardState.IsKeyDown(DOWN_MOVE) && !keyboardState.IsKeyDown(UP_MOVE))
                        {
                            walking = false;

                            setStationaryAnimation(gameInit);
                        }
                    }
                    movePlayer(gameInit);
                    checkPush();

                }
                else
                {
                    setFacingDirection();
                    lookForAction(gameInit);
                    if (keyboardState.IsKeyDown(PAUSE) || pauseFlag)
                    {
                        pause(gameInit);
                    }
                    else if (keyboardState.IsKeyDown(ACTION) && actionHandler.getCurrentAction() != "NONE")
                    {
                        executeAction(gameInit);
                    }
                    else if (keyboardState.IsKeyDown(FEED) || keyboardState.IsKeyDown(DRAIN) || keyboardState.IsKeyDown(RELEASE))
                    {
                        if (keyboardState.IsKeyDown(DRAIN))
                        {
                            draining = true;
                            beginDrain(gameInit);
                        }
                    }
                    else
                    {
                        if (keyboardState.IsKeyDown(UP_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 0)
                            {
                                walking = true;
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_UP"]);
                                moveUpFlag = true;
                            }
                            else
                            {
                                moveUpFlag = true;
                            }

                        }
                        if (keyboardState.IsKeyDown(DOWN_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 1)
                            {
                                walking = true;
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_DOWN"]);
                                moveDownFlag = true;
                            }
                            else
                            {
                                moveDownFlag = true;
                            }
                        }
                        if (keyboardState.IsKeyDown(RIGHT_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 2)
                            {
                                walking = true;
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_RIGHT"]);
                                moveRightFlag = true;
                            }
                            else
                            {
                                moveRightFlag = true;
                            }

                        }
                        if (keyboardState.IsKeyDown(LEFT_MOVE))
                        {
                            if (gameInit.getPlayer().getFacingDirection() == 3)
                            {
                                walking = true;
                                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_LEFT"]);
                                moveLeftFlag = true;
                            }
                            else
                            {
                                moveLeftFlag = true;
                            }
                        }

                        if (!walking)
                        {
                            setStationaryAnimation(gameInit);
                        }
                        movePlayer(gameInit);
                        checkPush();
                    }

                }

            }


            
        }

        private void pause(GameInit gameInit)
        {
            gameInit.getGameState().setInventoryState();
            gameInit.getInventoryKeyHandler().fadeIn();
        }

        private void lookForAction(GameInit gameInit)
        {
            actionHandler.lookForAction(gameInit);
        }

        private void executeAction(GameInit gameInit)
        {
            actionHandler.executeAction(gameInit);
        }

        private void animateObjects(GameInit gameInit)
        {
            List<ManipulatableObject> objectList = gameInit.getZoneFactory().getCurrentZone().getObjectList();

            for (int i = 0; i < objectList.Count; i++)
            {
                ManipulatableObject currentObject = objectList[i];

                if (currentObject.isStationary())
                {
                    if (currentObject.isAnimationFinished())
                    {
                        currentObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "STATIONARY");
                    }
                    else
                    {
                        currentObject.advanceAnimation();
                    }
                }
            }
        }

        private void cleanManipulatedObjects(GameInit gameInit)
        {
            for (int i = 0; i < manipulatedObjects.Count; i++)
            {
                ManipulatableObject currentObject = manipulatedObjects[i];

                if (currentObject.isAnimationFinished())
                {
                    manipulatedObjects.Remove(currentObject);
                    currentObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "STATIONARY");
                }
                else
                {
                    currentObject.advanceAnimation();
                }
            }
        }

        private void beginDrain(GameInit gameInit)
        {
            drainTiles.Clear();

            int direction = gameInit.getPlayer().getFacingDirection();

            if (direction == 0)
            {
                drainCenter = gameInit.getPlayer().getGlobalLocation() + new Vector2(15, -15);
                gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["CIRCLEGROWUP"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["CIRCLEGROWUP"]);
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["DRAIN_UP"]);
            }
            else if (direction == 1)
            {
                drainCenter = gameInit.getPlayer().getGlobalLocation() + new Vector2(15, 45);
                gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["CIRCLEGROWDOWN"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["CIRCLEGROWDOWN"]);
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["DRAIN_DOWN"]);
            }
            else if (direction == 2)
            {
                drainCenter = gameInit.getPlayer().getGlobalLocation() + new Vector2(45, 15);
                gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["CIRCLEGROWRIGHT"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["CIRCLEGROWRIGHT"]);
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["DRAIN_RIGHT"]);
            }
            else if (direction == 3)
            {
                drainCenter = gameInit.getPlayer().getGlobalLocation() + new Vector2(-15, 15);
                gameInit.getPlayer().setNewAbilityAnimation(gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimations()["CIRCLEGROWLEFT"], gameInit.getContentHandler().getAbilityContentHandler().getAbilityAnimationOffsets()["CIRCLEGROWLEFT"]);
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["DRAIN_LEFT"]);
            }

            drainCounter++;
            drainRadius = 10;


            //fillDrainTiles(gameInit);
        }

        private void drain(GameInit gameInit)
        {
            int xStart = (int)drainCenter.X - drainRadius;
            int yStart = (int)drainCenter.Y - drainRadius;

            int xTileStart;
            int yTileStart;

            int xLength;
            int yLength;

            int xTiles;
            int yTiles;

            if (xStart >= 0)
            {
                xTileStart = xStart / 30;
                xLength = 2 * drainRadius;
                xTiles = (xLength + 29 + xStart % 30) / 30;
            }
            else
            {
                xTileStart = 0;
                xLength = 2 * drainRadius + xStart;
                xTiles = (xLength + 29) / 30;
            }

            if (yStart >= 0)
            {
                yTileStart = yStart / 30;
                yLength = 2 * drainRadius;
                yTiles = (yLength + 29 + yStart % 30) / 30;
            }
            else
            {
                yTileStart = 0;
                yLength = 2 * drainRadius + yStart;
                yTiles = (yLength + 29) / 30;
            }

            Console.WriteLine("X: " + xTiles);
            Console.WriteLine("Y: " + yTiles);

            for (int i = 0; i < xTiles; i++)
            {
                for (int j = 0; j < yTiles; j++)
                {
                    if (xTileStart + i > 0 && xTileStart + i < gameInit.getZoneFactory().getCurrentZone().getTileWidth())
                    {
                        if (yTileStart + j > 0 && yTileStart + i < gameInit.getZoneFactory().getCurrentZone().getTileHeight())
                        {
                            if (gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(yTileStart + j, xTileStart + i, gameInit.getPlayer().getCurrentZoneLevel()).isObject())
                            {
                                ManipulatableObject currentObject = gameInit.getZoneFactory().getCurrentZone().getZoneTileMap().getTile(yTileStart + j, xTileStart + i, gameInit.getPlayer().getCurrentZoneLevel()).getTileObject();
                                if (currentObject.getDrainAmount() != 0 && currentObject.getEnergy() != 0 && currentObject.isStationary())
                                {
                                    currentObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "DRAIN");
                                    gameInit.getPlayer().drainEnergy(currentObject.getDrainAmount(), currentObject.getEnergyType());
                                    manipulatedObjects.Add(currentObject);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(manipulatedObjects.Count);                

        }

        private void pushObject(GameInit gameInit, ZoneTile pushingTile, ZoneTile destination)
        {
            if (pushingTile.isFull())
            {
                if (destination.isFree() && destination.isPushable())
                {
                    if (pushingTile.getTileObject().isPushable())
                    {
                        ManipulatableObject tileObject = pushingTile.getTileObject();

                        int direction = gameInit.getPlayer().getFacingDirection();

                        if (direction == 0)
                        {
                            tileObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "PUSH_UP");
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_UP"]);
                        }
                        else if (direction == 1)
                        {
                            tileObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "PUSH_DOWN");
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_DOWN"]);
                        }
                        else if (direction == 2)
                        {
                            tileObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "PUSH_RIGHT");
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_RIGHT"]);
                        }
                        else if (direction == 3)
                        {
                            tileObject.activate(gameInit.getContentHandler(), gameInit.getZoneFactory().getCurrentZone(), "PUSH_LEFT");
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_LEFT"]);
                        }
                        //manipulatedObjects.Add(tileObject);
                        animatingObject = tileObject;
                        environmentAnimation = true;
                        pushing = false;
                    }
                }
            }
        }

        private void jump(GameInit gameInit, ZoneTile jumpingTile, ZoneTile destination)
        {
            int direction = gameInit.getPlayer().getFacingDirection();

            if (jumpingTile.isJumpable())
            {
                if (destination.getType() == 0)
                {
                    if (destination.isFree())
                    {
                        walking = false;
                        jumping = true;
                        pushingCounter = 0;
                        if (direction == 0)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_UP"]);
                        }
                        else if (direction == 1)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_DOWN"]);
                        }
                        else if (direction == 2)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_RIGHT"]);
                        }
                        else if (direction == 3)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_LEFT"]);
                        }
                        gameInit.getPlayer().jump(direction);
                        gameInit.getPlayer().setGlobalLocation(gameInit.getPlayer().getGlobalLocation() + gameInit.getPlayer().getJumpOffset()[gameInit.getPlayer().getAnimationIndex()]);
                        movementHandler.updateDrawLocations(gameInit.getPlayer(), gameInit.getZoneFactory().getCurrentZone());
                    }
                }
                else if (destination.getType() == 1)
                {
                    if (destination.isFull())
                    {
                        walking = false;
                        jumping = true;
                        pushingCounter = 0;
                        if (direction == 0)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_UP"]);
                        }
                        else if (direction == 1)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_DOWN"]);
                        }
                        else if (direction == 2)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_RIGHT"]);
                        }
                        else if (direction == 3)
                        {
                            gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["JUMP_LEFT"]);
                        }
                        gameInit.getPlayer().jump(direction);
                        gameInit.getPlayer().setGlobalLocation(gameInit.getPlayer().getGlobalLocation() + gameInit.getPlayer().getJumpOffset()[gameInit.getPlayer().getAnimationIndex()]);
                        movementHandler.updateDrawLocations(gameInit.getPlayer(), gameInit.getZoneFactory().getCurrentZone());
                    }
                }
                else
                {
                    walking = false;
                    pushingCounter = 0;
                    setStationaryAnimation(gameInit);
                }
            }
            else
            {
                pushing = true;
                walking = false;
                if (direction == 0)
                {
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_UP"]);
                }
                else if (direction == 1)
                {
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_DOWN"]);
                }
                else if (direction == 2)
                {
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_RIGHT"]);
                }
                else if (direction == 3)
                {
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_LEFT"]);
                }
            }
        }

        private void checkIfPushContinue(GameInit gameInit, KeyboardState keyboardState)
        {
            int direction = gameInit.getPlayer().getFacingDirection();

            if (direction == 0)
            {
                if (keyboardState.IsKeyDown(DOWN_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_UP"]);
                }
                if (keyboardState.IsKeyDown(RIGHT_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_UP"]);
                    moveRightFlag = true;
                }
                if (keyboardState.IsKeyDown(LEFT_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_UP"]);
                    moveLeftFlag = true;
                }
                if (!keyboardState.IsKeyDown(DOWN_MOVE) && !keyboardState.IsKeyDown(RIGHT_MOVE) && !keyboardState.IsKeyDown(LEFT_MOVE))
                {
                    if (gameInit.getPlayer().isAnimationFinished())
                    {
                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_UP"]);
                    }
                    else
                    {
                        gameInit.getPlayer().advanceCurrentAnimation();
                    }
                }
            }
            else if (direction == 1)
            {
                if (keyboardState.IsKeyDown(UP_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_DOWN"]);
                }
                if (keyboardState.IsKeyDown(RIGHT_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_DOWN"]);
                    moveRightFlag = true;
                }
                if (keyboardState.IsKeyDown(LEFT_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_DOWN"]);
                    moveLeftFlag = true;
                }
                if (!keyboardState.IsKeyDown(UP_MOVE) && !keyboardState.IsKeyDown(RIGHT_MOVE) && !keyboardState.IsKeyDown(LEFT_MOVE))
                {
                    if (gameInit.getPlayer().isAnimationFinished())
                    {
                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_DOWN"]);
                    }
                    else
                    {
                        gameInit.getPlayer().advanceCurrentAnimation();
                    }
                }
            }
            else if (direction == 2)
            {
                if (keyboardState.IsKeyDown(DOWN_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_RIGHT"]);
                    moveDownFlag = true;
                }
                if (keyboardState.IsKeyDown(UP_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_RIGHT"]);
                    moveUpFlag = true;
                }
                if (keyboardState.IsKeyDown(LEFT_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_RIGHT"]);
                }
                if (!keyboardState.IsKeyDown(DOWN_MOVE) && !keyboardState.IsKeyDown(UP_MOVE) && !keyboardState.IsKeyDown(LEFT_MOVE))
                {
                    if (gameInit.getPlayer().isAnimationFinished())
                    {
                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_RIGHT"]);
                    }
                    else
                    {
                        gameInit.getPlayer().advanceCurrentAnimation();
                    }
                }
            }
            else if (direction == 3)
            {
                if (keyboardState.IsKeyDown(DOWN_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_LEFT"]);
                    moveDownFlag = true;
                }
                if (keyboardState.IsKeyDown(RIGHT_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_LEFT"]);
                }
                if (keyboardState.IsKeyDown(UP_MOVE))
                {
                    pushing = false;
                    pushingCounter = 0;
                    walking = true;
                    gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["WALK_LEFT"]);
                    moveUpFlag = true;
                }
                if (!keyboardState.IsKeyDown(DOWN_MOVE) && !keyboardState.IsKeyDown(RIGHT_MOVE) && !keyboardState.IsKeyDown(UP_MOVE))
                {
                    if (gameInit.getPlayer().isAnimationFinished())
                    {
                        gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["PUSH_LEFT"]);
                    }
                    else
                    {
                        gameInit.getPlayer().advanceCurrentAnimation();
                    }
                }
            }
        }

        private void setStationaryAnimation(GameInit gameInit)
        {
            int direction = gameInit.getPlayer().getFacingDirection();

            if (direction == 0)
            {
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_UP"]);
            }
            else if (direction == 1)
            {
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_DOWN"]);
            }
            else if (direction == 2)
            {
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_RIGHT"]);
            }
            else if (direction == 3)
            {
                gameInit.getPlayer().setNewAnimation(gameInit.getContentHandler().getPlayerContentHandler().getPlayerAnimations()["STATIONARY_LEFT"]);
            }
        }

        private void movePlayer(GameInit gameInit)
        {
            int verticalCounter = 0;
            int horizontalCounter = 0;

            movementHandler.resetFlags();

            if (moveUpFlag)
            {
                verticalCounter--;
            }
            if (moveDownFlag)
            {
                verticalCounter++;
            }
            if (moveRightFlag)
            {
                horizontalCounter++;
            }
            if (moveLeftFlag)
            {
                horizontalCounter--;
            }

            if (horizontalCounter > 0)
            {
                movementHandler.movePlayer(2, gameInit.getPlayer(), gameInit.getZoneFactory());
            }
            else if (horizontalCounter < 0)
            {
                movementHandler.movePlayer(3, gameInit.getPlayer(), gameInit.getZoneFactory());
            }

            if (verticalCounter > 0)
            {
                movementHandler.movePlayer(1, gameInit.getPlayer(), gameInit.getZoneFactory());
            }
            else if (verticalCounter < 0)
            {
                movementHandler.movePlayer(0, gameInit.getPlayer(), gameInit.getZoneFactory());
            }
        }

        private void checkPush()
        {
            if (movementHandler.pushTest() && walking)
            {
                pushingCounter++;
            }
            else
            {
                pushingCounter = 0;
            }
        }

        public void noPauseFlag()
        {
            pauseFlag = false;
        }

        public void setPauseFlag()
        {
            pauseFlag = true;
        }

        public bool getPauseFlag()
        {
            return pauseFlag;
        }

        private void setFacingDirection()
        {
            int upTime = 0;
            int downTime = 0;
            int rightTime = 0;
            int leftTime = 0;

            if (keyTime.ContainsKey(UP_MOVE))
            {
                upTime = keyTime[UP_MOVE];
            }
            if (keyTime.ContainsKey(DOWN_MOVE))
            {
                downTime = keyTime[DOWN_MOVE];
            }
            if (keyTime.ContainsKey(RIGHT_MOVE))
            {
                rightTime = keyTime[RIGHT_MOVE];
            }
            if (keyTime.ContainsKey(LEFT_MOVE))
            {
                leftTime = keyTime[LEFT_MOVE];
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

        public ActionHandler getActionHandler()
        {
            return actionHandler;
        }
    }
}
