using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.PaintHandlers
{
    class ChatPaintHandler
    {
        private readonly Color FADECOLOR = Color.Gray;
        private readonly Color WHITECOLOR = Color.White;
        private readonly Color TEXTCOLOR = Color.Black;

        private readonly Vector2 WINDOWLOCATION = new Vector2(200, 350);
        private readonly Vector2 BIGWINDOWLOCATION = new Vector2(50, 50);
        private readonly Vector2 FIRSTLETTER = new Vector2(65, 55);
        private readonly Vector2 OPTIONBOX = new Vector2(550, 50);
        private readonly Vector2 FIRSTOPTION = new Vector2(565, 65);

        private GameInit gameInit;
        private int distance;
        private int line;


        public ChatPaintHandler(GameInit gameInit)
        {
            this.gameInit = gameInit;
            distance = 0;
            line = 0;
        }

        public void draw(SpriteBatch sb)
        {
            sb.Begin();
            drawChat(sb);
            sb.End();
        }

        private void drawChat(SpriteBatch sb)
        {
            SpriteFont chatFont = gameInit.getContentHandler().getChatContentHandler().getChatFont();
            gameInit.getPaintHandler().drawZone(sb, FADECOLOR);

            if (!gameInit.getChatKeyHandler().isFadingIn() && !gameInit.getChatKeyHandler().isFadingOut())
            {
                sb.Draw(gameInit.getContentHandler().getChatContentHandler().getBigChatWindow(), BIGWINDOWLOCATION, WHITECOLOR);
                
                distance = 0;
                line = 0;

                for (int i = 0; i < gameInit.getChatKeyHandler().getTalkingNPC().getCurrentChatPage().getParsedString().Count; i++)
                {
                    string currentLine = gameInit.getChatKeyHandler().getTalkingNPC().getCurrentChatPage().getParsedString()[i];
                    if (distance + (int)chatFont.MeasureString(currentLine).X >= 380)
                    {
                        distance = 0;
                        line++;
                    }
                    sb.DrawString(chatFont, currentLine, FIRSTLETTER + new Vector2(distance, line * 20), TEXTCOLOR);
                    distance += (int)chatFont.MeasureString(currentLine).X;
                }

                sb.Draw(gameInit.getContentHandler().getChatContentHandler().getOptionBox(), OPTIONBOX, WHITECOLOR);

                line = 0;

                for (int i = 0; i < gameInit.getChatKeyHandler().getTalkingNPC().getCurrentChatPage().getOptions().Count; i++)
                {
                    distance = 0;
                    if (gameInit.getChatKeyHandler().getTalkingNPC().getCurrentChatPage().getOptionIndex() == i)
                    {
                        sb.Draw(gameInit.getContentHandler().getChatContentHandler().getPointerArrow(), FIRSTOPTION + new Vector2(0, line * 20 + 10), WHITECOLOR);
                    }

                    for (int j = 0; j < gameInit.getChatKeyHandler().getTalkingNPC().getCurrentChatPage().getParsedOptions()[i].Count; j++)
                    {
                        string currentLine = gameInit.getChatKeyHandler().getTalkingNPC().getCurrentChatPage().getParsedOptions()[i][j];

                        if (distance + (int)chatFont.MeasureString(currentLine).X >= 240)
                        {
                            distance = 0;
                            line++;
                        }
                        sb.DrawString(chatFont, currentLine, FIRSTOPTION + new Vector2(10 + distance, line * 20), TEXTCOLOR);
                        distance += (int)chatFont.MeasureString(currentLine).X;
                    }
                    line++;
                    line++;
                }
            }

            
        }

    }
}
