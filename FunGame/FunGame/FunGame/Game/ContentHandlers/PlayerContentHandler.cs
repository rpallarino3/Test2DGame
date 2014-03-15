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

        private List<Texture2D> stationaryPlayerImages;

        private List<Texture2D> stationaryUp;
        private List<Texture2D> stationaryDown;
        private List<Texture2D> stationaryRight;
        private List<Texture2D> stationaryLeft;
        private List<Texture2D> stationaryBorderUp;
        private List<Texture2D> stationaryBorderDown;
        private List<Texture2D> stationaryBorderRight;
        private List<Texture2D> stationaryBorderLeft;

        private List<Texture2D> walkingUpAnimation;
        private List<Texture2D> walkingDownAnimation;
        private List<Texture2D> walkingLeftAnimation;
        private List<Texture2D> walkingRightAnimation;
        private List<Texture2D> walkingBorderUpAnimation;
        private List<Texture2D> walkingBorderDownAnimation;
        private List<Texture2D> walkingBorderLeftAnimation;
        private List<Texture2D> walkingBorderRightAnimation;

        private List<Texture2D> stationarySwordUp;
        private List<Texture2D> stationarySwordDown;
        private List<Texture2D> stationarySwordRight;
        private List<Texture2D> stationarySwordLeft;
        private List<Texture2D> stationaryBorderSwordUp;
        private List<Texture2D> stationaryBorderSwordDown;
        private List<Texture2D> stationaryBorderSwordRight;
        private List<Texture2D> stationaryBorderSwordLeft;

        private List<Texture2D> swingSwordUp;
        private List<Texture2D> swingSwordDown;
        private List<Texture2D> swingSwordRight;
        private List<Texture2D> swingSwordLeft;
        private List<Texture2D> swingBorderSwordUp;
        private List<Texture2D> swingBorderSwordDown;
        private List<Texture2D> swingBorderSwordRight;
        private List<Texture2D> swingBorderSwordLeft;


        public PlayerContentHandler(ContentManager content)
        {
            this.content = content;

            playerAnimations = new Dictionary<string, List<Texture2D>>();

            stationaryPlayerImages = new List<Texture2D>();

            stationaryUp = new List<Texture2D>();
            stationaryDown = new List<Texture2D>();
            stationaryRight = new List<Texture2D>();
            stationaryLeft = new List<Texture2D>();
            stationaryBorderUp = new List<Texture2D>();
            stationaryBorderDown = new List<Texture2D>();
            stationaryBorderRight = new List<Texture2D>();
            stationaryBorderLeft = new List<Texture2D>();

            walkingUpAnimation = new List<Texture2D>();
            walkingDownAnimation = new List<Texture2D>();
            walkingLeftAnimation = new List<Texture2D>();
            walkingRightAnimation = new List<Texture2D>();
            walkingBorderUpAnimation = new List<Texture2D>();
            walkingBorderDownAnimation = new List<Texture2D>();
            walkingBorderLeftAnimation = new List<Texture2D>();
            walkingBorderRightAnimation = new List<Texture2D>();

            stationarySwordUp = new List<Texture2D>();
            stationarySwordDown = new List<Texture2D>();
            stationarySwordRight = new List<Texture2D>();
            stationarySwordLeft = new List<Texture2D>();
            stationaryBorderSwordUp = new List<Texture2D>();
            stationaryBorderSwordDown = new List<Texture2D>();
            stationaryBorderSwordRight = new List<Texture2D>();
            stationaryBorderSwordLeft = new List<Texture2D>();

            swingSwordUp = new List<Texture2D>();
            swingSwordDown = new List<Texture2D>();
            swingSwordRight = new List<Texture2D>();
            swingSwordLeft = new List<Texture2D>();
            swingBorderSwordUp = new List<Texture2D>();
            swingBorderSwordDown = new List<Texture2D>();
            swingBorderSwordRight = new List<Texture2D>();
            swingBorderSwordLeft = new List<Texture2D>();

        }

        public void loadContent()
        {

            loadStationaryImages();
            loadWalkUp();
            loadWalkDown();
            loadWalkRight();
            loadWalkLeft();
            loadStationarySword();
            loadSwingSwordUp();
            loadSwingSwordDown();
            loadSwingSwordRight();
            loadSwingSwordLeft();
        }

        private void loadStationaryImages()
        {
            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            stationaryUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            playerAnimations.Add("STATIONARY_UP", stationaryUp);

            stationaryBorderUp.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            playerAnimations.Add("BORDER_STATIONARY_UP", stationaryBorderUp);

            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            stationaryDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            playerAnimations.Add("STATIONARY_DOWN", stationaryDown);

            stationaryBorderDown.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            playerAnimations.Add("BORDER_STATIONARY_DOWN", stationaryBorderDown);

            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            stationaryRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            playerAnimations.Add("STATIONARY_RIGHT", stationaryRight);

            stationaryBorderRight.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            playerAnimations.Add("BORDER_STATIONARY_RIGHT", stationaryBorderRight);

            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            stationaryLeft.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
            playerAnimations.Add("STATIONARY_LEFT", stationaryLeft);

            stationaryBorderLeft.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            playerAnimations.Add("BORDER_STATIONARY_LEFT", stationaryBorderLeft);
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

            walkingBorderUpAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderUpAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderUpAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderUpAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderUpAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderUpAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));

            playerAnimations.Add("BORDER_WALK_UP", walkingBorderUpAnimation);
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

            walkingBorderDownAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderDownAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderDownAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderDownAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderDownAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderDownAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));

            playerAnimations.Add("BORDER_WALK_DOWN", walkingBorderDownAnimation);
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

            walkingBorderRightAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderRightAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderRightAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderRightAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderRightAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderRightAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));

            playerAnimations.Add("BORDER_WALK_RIGHT", walkingBorderRightAnimation);
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

            walkingBorderLeftAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderLeftAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderLeftAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderLeftAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderLeftAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));
            walkingBorderLeftAnimation.Add(content.Load<Texture2D>("Images/Player/PlainBorder"));

            playerAnimations.Add("BORDER_WALK_LEFT", walkingBorderLeftAnimation);
        }

        private void loadStationarySword()
        {
            stationarySwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp3"));
            playerAnimations.Add("SWORD_UP", stationarySwordUp);

            stationaryBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp3"));
            playerAnimations.Add("BORDER_SWORD_UP", stationaryBorderSwordUp);

            stationarySwordDown.Add(content.Load<Texture2D>("images/Player/SwingingSword/Down/SwingSwordDown3"));
            playerAnimations.Add("SWORD_DOWN", stationarySwordDown);

            stationaryBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown3"));
            playerAnimations.Add("BORDER_SWORD_DOWN", stationaryBorderSwordDown);

            stationarySwordRight.Add(content.Load<Texture2D>("images/Player/SwingingSword/Right/SwingSwordRight3"));
            playerAnimations.Add("SWORD_RIGHT", stationarySwordRight);

            stationaryBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight3"));
            playerAnimations.Add("BORDER_SWORD_RIGHT", stationaryBorderSwordRight);

            stationarySwordLeft.Add(content.Load<Texture2D>("images/Player/SwingingSword/Left/SwingSwordLeft3"));
            playerAnimations.Add("SWORD_LEFT", stationarySwordLeft);

            stationaryBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft3"));
            playerAnimations.Add("BORDER_SWORD_LEFT", stationaryBorderSwordLeft);
        }

        private void loadSwingSwordUp()
        {
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp1"));
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp1"));
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp2"));
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp2"));
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp3"));
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp3"));
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp4"));
            swingSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwingSwordUp4"));

            playerAnimations.Add("SWING_SWORD_UP", swingSwordUp);

            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp1"));
            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp1"));
            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp2"));
            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp2"));
            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp3"));
            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp3"));
            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp4"));
            swingBorderSwordUp.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Up/SwordTipUp4"));

            playerAnimations.Add("BORDER_SWING_SWORD_UP", swingBorderSwordUp);
        }

        private void loadSwingSwordDown()
        {
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown1"));
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown1"));
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown2"));
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown2"));
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown3"));
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown3"));
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown4"));
            swingSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwingSwordDown4"));

            playerAnimations.Add("SWING_SWORD_DOWN", swingSwordDown);

            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown1"));
            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown1"));
            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown2"));
            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown2"));
            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown3"));
            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown3"));
            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown4"));
            swingBorderSwordDown.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Down/SwordTipDown4"));

            playerAnimations.Add("BORDER_SWING_SWORD_DOWN", swingBorderSwordDown);
        }

        private void loadSwingSwordRight()
        {
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight1"));
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight1"));
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight2"));
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight2"));
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight3"));
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight3"));
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight4"));
            swingSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwingSwordRight4"));

            playerAnimations.Add("SWING_SWORD_RIGHT", swingSwordRight);

            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight1"));
            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight1"));
            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight2"));
            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight2"));
            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight3"));
            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight3"));
            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight4"));
            swingBorderSwordRight.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Right/SwordTipRight4"));

            playerAnimations.Add("BORDER_SWING_SWORD_RIGHT", swingBorderSwordRight);
        }

        private void loadSwingSwordLeft()
        {
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft1"));
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft1"));
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft2"));
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft2"));
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft3"));
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft3"));
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft4"));
            swingSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwingSwordLeft4"));

            playerAnimations.Add("SWING_SWORD_LEFT", swingSwordLeft);

            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft1"));
            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft1"));
            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft2"));
            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft2"));
            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft3"));
            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft3"));
            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft4"));
            swingBorderSwordLeft.Add(content.Load<Texture2D>("Images/Player/SwingingSword/Left/SwordTipLeft4"));

            playerAnimations.Add("BORDER_SWING_SWORD_LEFT", swingBorderSwordLeft);
        }

        public List<Texture2D> getStationaryImages()
        {
            return stationaryPlayerImages;
        }

        public Dictionary<string, List<Texture2D>> getPlayerAnimations()
        {
            return playerAnimations;
        }
    }
}
