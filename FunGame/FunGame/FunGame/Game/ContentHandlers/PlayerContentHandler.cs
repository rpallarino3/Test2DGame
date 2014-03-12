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

        private List<Texture2D> walkingUpAnimation;
        private List<Texture2D> walkingDownAnimation;
        private List<Texture2D> walkingLeftAnimation;
        private List<Texture2D> walkingRightAnimation;

        public PlayerContentHandler(ContentManager content)
        {
            this.content = content;

            playerAnimations = new Dictionary<string, List<Texture2D>>();

            stationaryPlayerImages = new List<Texture2D>();

            stationaryUp = new List<Texture2D>();
            stationaryDown = new List<Texture2D>();
            stationaryRight = new List<Texture2D>();
            stationaryLeft = new List<Texture2D>();

            walkingUpAnimation = new List<Texture2D>();
            walkingDownAnimation = new List<Texture2D>();
            walkingLeftAnimation = new List<Texture2D>();
            walkingRightAnimation = new List<Texture2D>();
        }

        public void loadContent()
        {

            loadStationaryImages();
            loadWalkUp();
            loadWalkDown();
            loadWalkRight();
            loadWalkLeft();
        }

        private void loadStationaryImages()
        {
            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            stationaryUp.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerUp"));
            playerAnimations.Add("STATIONARY_UP", stationaryUp);

            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            stationaryDown.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerDown"));
            playerAnimations.Add("STATIONARY_DOWN", stationaryDown);

            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            stationaryRight.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerRight"));
            playerAnimations.Add("STATIONARY_RIGHT", stationaryRight);

            stationaryPlayerImages.Add(content.Load<Texture2D>("Images/Player/StationaryImages/PlayerLeft"));
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
