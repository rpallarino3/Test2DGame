using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.ContentHandlers
{
    class PlayerContentHandler
    {

        private ContentManager content;

        private Dictionary<string, List<Texture2D>> playerAnimations;
        
        private List<Texture2D> stationaryUp;
        private List<Texture2D> stationaryDown;
        private List<Texture2D> stationaryRight;
        private List<Texture2D> stationaryLeft;

        private List<Texture2D> walkingUpAnimation;
        private List<Texture2D> walkingDownAnimation;
        private List<Texture2D> walkingLeftAnimation;
        private List<Texture2D> walkingRightAnimation;

        private List<Texture2D> pushUpAnimation;
        private List<Texture2D> pushDownAnimation;
        private List<Texture2D> pushRightAnimation;
        private List<Texture2D> pushLeftAnimation;

        private List<Texture2D> jumpUpAnimation;
        private List<Texture2D> jumpDownAnimation;
        private List<Texture2D> jumpRightAnimation;
        private List<Texture2D> jumpLeftAnimation;

        private List<Texture2D> drainUpAnimation;
        private List<Texture2D> drainDownAnimation;
        private List<Texture2D> drainRightAnimation;
        private List<Texture2D> drainLeftAnimation;
        private List<Texture2D> continuousDrainUp;
        private List<Texture2D> continuousDrainDown;
        private List<Texture2D> continuousDrainRight;
        private List<Texture2D> continuousDrainLeft;
        private List<Texture2D> releaseUp;
        private List<Texture2D> releaseDown;
        private List<Texture2D> releaseRight;
        private List<Texture2D> releaseLeft;

        public PlayerContentHandler(ContentManager content)
        {
            this.content = content;

            playerAnimations = new Dictionary<string, List<Texture2D>>();

            stationaryUp = new List<Texture2D>();
            stationaryDown = new List<Texture2D>();
            stationaryRight = new List<Texture2D>();
            stationaryLeft = new List<Texture2D>();

            walkingUpAnimation = new List<Texture2D>();
            walkingDownAnimation = new List<Texture2D>();
            walkingLeftAnimation = new List<Texture2D>();
            walkingRightAnimation = new List<Texture2D>();

            pushUpAnimation = new List<Texture2D>();
            pushDownAnimation = new List<Texture2D>();
            pushRightAnimation = new List<Texture2D>();
            pushLeftAnimation = new List<Texture2D>();

            jumpUpAnimation = new List<Texture2D>();
            jumpDownAnimation = new List<Texture2D>();
            jumpRightAnimation = new List<Texture2D>();
            jumpLeftAnimation = new List<Texture2D>();

            drainUpAnimation = new List<Texture2D>();
            drainDownAnimation = new List<Texture2D>();
            drainRightAnimation = new List<Texture2D>();
            drainLeftAnimation = new List<Texture2D>();
            continuousDrainUp = new List<Texture2D>();
            continuousDrainDown = new List<Texture2D>();
            continuousDrainRight = new List<Texture2D>();
            continuousDrainLeft = new List<Texture2D>();
            releaseUp = new List<Texture2D>();
            releaseDown = new List<Texture2D>();
            releaseRight = new List<Texture2D>();
            releaseLeft = new List<Texture2D>();
        }

        public void loadContent()
        {

            loadStationaryImages();
            loadWalkUp();
            loadWalkDown();
            loadWalkRight();
            loadWalkLeft();

            loadPush();
            loadJump();
            loadDrain();
        }

        private void loadStationaryImages()
        {
            stationaryUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            playerAnimations.Add("STATIONARY_UP", stationaryUp);

            stationaryDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            playerAnimations.Add("STATIONARY_DOWN", stationaryDown);

            stationaryRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            playerAnimations.Add("STATIONARY_RIGHT", stationaryRight);

            stationaryLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            playerAnimations.Add("STATIONARY_LEFT", stationaryLeft);
        }

        private void loadWalkUp()
        {
            walkingUpAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkForward1"));
            walkingUpAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkForward1"));
            walkingUpAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkForward1"));
            walkingUpAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkForward2"));
            walkingUpAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkForward2"));
            walkingUpAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkForward2"));

            playerAnimations.Add("WALK_UP", walkingUpAnimation);
        }

        private void loadWalkDown()
        {
            walkingDownAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkDown1"));
            walkingDownAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkDown1"));
            walkingDownAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkDown1"));
            walkingDownAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkDown2"));
            walkingDownAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkDown2"));
            walkingDownAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkDown2"));

            playerAnimations.Add("WALK_DOWN", walkingDownAnimation);
        }

        private void loadWalkRight()
        {
            walkingRightAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkRight1"));
            walkingRightAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkRight1"));
            walkingRightAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkRight1"));
            walkingRightAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkRight2"));
            walkingRightAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkRight2"));
            walkingRightAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkRight2"));

            playerAnimations.Add("WALK_RIGHT", walkingRightAnimation);
        }

        private void loadWalkLeft()
        {
            walkingLeftAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkLeft1"));
            walkingLeftAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkLeft1"));
            walkingLeftAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkLeft1"));
            walkingLeftAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkLeft2"));
            walkingLeftAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkLeft2"));
            walkingLeftAnimation.Add(content.Load<Texture2D>("Images/Player/Walking/PlayerWalkLeft2"));

            playerAnimations.Add("WALK_LEFT", walkingLeftAnimation);
        }

        private void loadPush()
        {
            pushUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            pushUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            pushUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            pushUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            pushUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            pushUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));

            playerAnimations.Add("PUSH_UP", pushUpAnimation);

            pushDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            pushDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            pushDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            pushDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            pushDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            pushDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));

            playerAnimations.Add("PUSH_DOWN", pushDownAnimation);

            pushRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            pushRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            pushRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            pushRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            pushRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            pushRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));

            playerAnimations.Add("PUSH_RIGHT", pushRightAnimation);

            pushLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            pushLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            pushLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            pushLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            pushLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            pushLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));

            playerAnimations.Add("PUSH_LEFT", pushLeftAnimation);
        }

        private void loadJump()
        {
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            jumpUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));

            playerAnimations.Add("JUMP_UP", jumpUpAnimation);

            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            jumpDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));

            playerAnimations.Add("JUMP_DOWN", jumpDownAnimation);

            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            jumpRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));

            playerAnimations.Add("JUMP_RIGHT", jumpRightAnimation);

            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            jumpLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));

            playerAnimations.Add("JUMP_LEFT", jumpLeftAnimation);
        }

        private void loadDrain()
        {
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            drainUpAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));

            playerAnimations.Add("DRAIN_UP", drainUpAnimation);

            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            drainDownAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));

            playerAnimations.Add("DRAIN_DOWN", drainDownAnimation);

            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            drainRightAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));

            playerAnimations.Add("DRAIN_RIGHT", drainRightAnimation);

            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            drainLeftAnimation.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));

            playerAnimations.Add("DRAIN_LEFT", drainLeftAnimation);

            continuousDrainUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            continuousDrainUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            continuousDrainUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            continuousDrainUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            continuousDrainUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            continuousDrainUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));

            playerAnimations.Add("CONTINUOUS_DRAIN_UP", continuousDrainUp);

            continuousDrainDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            continuousDrainDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            continuousDrainDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            continuousDrainDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            continuousDrainDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            continuousDrainDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));

            playerAnimations.Add("CONTINUOUS_DRAIN_DOWN", continuousDrainDown);

            continuousDrainRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            continuousDrainRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            continuousDrainRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            continuousDrainRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            continuousDrainRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            continuousDrainRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));

            playerAnimations.Add("CONTINUOUS_DRAIN_RIGHT", continuousDrainRight);

            continuousDrainLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            continuousDrainLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            continuousDrainLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            continuousDrainLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            continuousDrainLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            continuousDrainLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));

            playerAnimations.Add("CONTINUOUS_DRAIN_LEFT", continuousDrainLeft);

            releaseUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            releaseUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            releaseUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            releaseUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));

            playerAnimations.Add("RELEASE_UP", releaseUp);

            releaseDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            releaseDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            releaseDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            releaseDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));

            playerAnimations.Add("RELEASE_DOWN", releaseDown);

            releaseRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            releaseRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            releaseRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            releaseRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));

            playerAnimations.Add("RELEASE_RIGHT", releaseRight);

            releaseLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            releaseLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            releaseLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            releaseLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));

            playerAnimations.Add("RELEASE_LEFT", releaseLeft);
        }

        public Dictionary<string, List<Texture2D>> getPlayerAnimations()
        {
            return playerAnimations;
        }
    }
}
