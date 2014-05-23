using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FunGame.Game.Environment;

namespace FunGame.Game.NPCStuff
{
    class NPC
    {

        private Zone currentZone;
        private Vector2 currentLocation;
        private int currentLevel;

        private Vector2 size;
        private Vector2 drawSize;
        private Vector2 drawOffset;

        private String name;
        private int facingDirection;

        private List<Texture2D> currentAnimation;
        private int animationIndex;
        private bool animationFinished;
        private bool stationary;

        private List<ChatPage> chatPages;
        private ChatPage firstChatPage;
        private ChatPage currentChatPage;
        private ChatPage exitPage;

        public NPC(String name, Zone zone, Vector2 tileLocation, int level, Vector2 size, Vector2 drawSize, int facingDirection)
        {
            this.name = name;
            this.currentZone = zone;
            this.currentLocation = new Vector2(tileLocation.X * 30, tileLocation.Y * 30);
            this.currentLevel = level;
            this.size = size;
            this.drawSize = drawSize;
            this.facingDirection = facingDirection;

            chatPages = new List<ChatPage>();
            stationary = true;
            drawOffset = new Vector2(0, drawSize.Y - size.Y);
        }

        public List<ChatPage> getChatPages()
        {
            return chatPages;
        }

        public ChatPage getExitPage()
        {
            return exitPage;
        }

        public void setExitPage(ChatPage page)
        {
            exitPage = page;
        }

        public void setFirstChatPage(ChatPage page)
        {
            firstChatPage = page;
        }

        public void setCurrentChatPage(ChatPage page)
        {
            currentChatPage = page;
        }

        public ChatPage getFirstChatPage()
        {
            return firstChatPage;
        }

        public ChatPage getCurrentChatPage()
        {
            return currentChatPage;
        }

        public void addChatPage(ChatPage page)
        {
            chatPages.Add(page);
        }

        public Vector2 getDrawOffset()
        {
            return drawOffset;
        }

        public Vector2 getSize()
        {
            return size;
        }

        public Vector2 getDrawSize()
        {
            return drawSize;
        }

        public Zone getCurrentZone()
        {
            return currentZone;
        }

        public void setCurrentZone(Zone zone)
        {
            currentZone = zone;
        }

        public Vector2 getCurrentLocation()
        {
            return currentLocation;
        }

        public int getCurrentLevel()
        {
            return currentLevel;
        }

        public String getName()
        {
            return name;
        }

        public int getFacingDirection()
        {
            return facingDirection;
        }

        public void turn(int direction)
        {
            facingDirection = direction;
        }

        public void advanceAnimation()
        {
            if (animationIndex < currentAnimation.Count - 1)
            {
                animationIndex++;
            }
            else
            {
                animationFinished = true;
            }
        }

        public void setNewAnimation(List<Texture2D> animation)
        {
            animationIndex = 0;
            currentAnimation = animation;
            animationFinished = false;
        }

        public void noStationary()
        {
            stationary = false;
        }

        public void yesStationary()
        {
            stationary = true;
        }

        public bool isStationary()
        {
            return stationary;
        }

        public List<Texture2D> getCurrentAnimation()
        {
            return currentAnimation;
        }

        public Texture2D getCurrentImage()
        {
            return currentAnimation[animationIndex];
        }

        public bool isAnimationFinished()
        {
            return animationFinished;
        }


    }
}
