using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FunGame.Game.ContentHandlers
{
    class CharacterContentHandler
    {

        private ContentManager content;

        private Dictionary<string, Dictionary<string, Texture2D>> characters;
        private Dictionary<string, Dictionary<int, Texture2D>> numbers;

        public CharacterContentHandler(ContentManager content)
        {

            this.content = content;
            characters = new Dictionary<string, Dictionary<string, Texture2D>>();
            numbers = new Dictionary<string, Dictionary<int, Texture2D>>();
        }

        public void loadContent()
        {
            loadBlackNumbers();
        }

        private void loadBlackNumbers()
        {
            Dictionary<int, Texture2D> smallBlack = new Dictionary<int, Texture2D>();

            smallBlack.Add(0, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/0"));
            smallBlack.Add(1, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/1"));
            smallBlack.Add(2, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/2"));
            smallBlack.Add(3, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/3"));
            smallBlack.Add(4, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/4"));
            smallBlack.Add(5, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/5"));
            smallBlack.Add(6, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/6"));
            smallBlack.Add(7, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/7"));
            smallBlack.Add(8, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/8"));
            smallBlack.Add(9, content.Load<Texture2D>("Images/Characters/Numbers/SmallBlack/9"));

            numbers.Add("SMALLBLACK", smallBlack);

            Dictionary<int, Texture2D> mediumBlack = new Dictionary<int, Texture2D>();

            mediumBlack.Add(0, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/0black"));
            mediumBlack.Add(1, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/1black"));
            mediumBlack.Add(2, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/2black"));
            mediumBlack.Add(3, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/3black"));
            mediumBlack.Add(4, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/4black"));
            mediumBlack.Add(5, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/5black"));
            mediumBlack.Add(6, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/6black"));
            mediumBlack.Add(7, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/7black"));
            mediumBlack.Add(8, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/8black"));
            mediumBlack.Add(9, content.Load<Texture2D>("Images/Characters/Numbers/MediumBlack/9black"));

            numbers.Add("MEDIUMBLACK", mediumBlack);
        }

        public Dictionary<string, Dictionary<string, Texture2D>> getCharacters()
        {
            return characters;
        }

        public Dictionary<string, Dictionary<int, Texture2D>> getNumbers()
        {
            return numbers;
        }
    }
}
