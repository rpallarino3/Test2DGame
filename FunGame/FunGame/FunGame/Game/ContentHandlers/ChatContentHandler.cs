using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FunGame.Game.ContentHandlers
{
    class ChatContentHandler
    {
        private ContentManager content;

        private Texture2D chatWindow;
        private Texture2D bigChatWindow;
        private Texture2D optionBox;
        private Texture2D pointerArrow;
        private SpriteFont chatFont;

        public ChatContentHandler(ContentManager content)
        {
            this.content = content;
        }

        public void loadContent()
        {
            loadChatWindow();
            loadFonts();
        }

        private void loadChatWindow()
        {
            chatWindow = content.Load<Texture2D>("Images/Chat/ChatBox");
            bigChatWindow = content.Load<Texture2D>("Images/Chat/BigChatBox");
            optionBox = content.Load<Texture2D>("Images/Chat/OptionBox");
            pointerArrow = content.Load<Texture2D>("Images/Chat/PointerArrow");
        }

        private void loadFonts()
        {
            chatFont = content.Load<SpriteFont>("Fonts/ChatFont");
        }

        public Texture2D getChatWindow()
        {
            return chatWindow;
        }

        public Texture2D getBigChatWindow()
        {
            return bigChatWindow;
        }

        public Texture2D getOptionBox()
        {
            return optionBox;
        }

        public Texture2D getPointerArrow()
        {
            return pointerArrow;
        }

        public SpriteFont getChatFont()
        {
            return chatFont;
        }
    }
}
