using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGame.Game.NPCStuff
{
    class ChatPage
    {
        private Dictionary<string, ChatPage> pageDestinations;
        private List<string> options;
        private List<List<string>> parsedOptions;
        private List<string> parsedString;
        private string text;
        private int lastIndex;

        private bool opt;
        private int currentOptionIndex;

        private string exitOption;

        public ChatPage()
        {
            pageDestinations = new Dictionary<string, ChatPage>();
            options = new List<string>();
            parsedOptions = new List<List<string>>();
            parsedString = new List<string>();
            opt = false;
            currentOptionIndex = 0;
        }

        public void parseString()
        {
            parsedString.Clear();
            lastIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (i == text.Length - 1 || text[i] == ' ')
                {
                    parsedString.Add(text.Substring(lastIndex, i - lastIndex + 1));
                    lastIndex = i + 1;
                }

            }
        }

        public List<string> getParsedString()
        {
            return parsedString;
        }

        public string getText()
        {
            return text;
        }

        public void setText(string txt)
        {
            text = txt;
        }

        public void moveOptionUp()
        {
            if (currentOptionIndex == 0)
            {
                currentOptionIndex = options.Count - 1;
            }
            else
            {
                currentOptionIndex--;
            }
        }

        public void moveOptionDown()
        {
            if (currentOptionIndex == options.Count - 1)
            {
                currentOptionIndex = 0;
            }
            else
            {
                currentOptionIndex++;
            }
        }

        public int getOptionIndex()
        {
            return currentOptionIndex;
        }

        public void setOptionIndex(int index)
        {
            currentOptionIndex = index;
        }

        public Dictionary<string, ChatPage> getPageDestinations()
        {
            return pageDestinations;
        }

        public void addDestination(string option, ChatPage destination)
        {
            int index = parsedOptions.Count;
            opt = true;
            options.Add(option);
            parsedOptions.Add(new List<string>());
            lastIndex = 0;
            for (int i = 0; i < option.Length; i++)
            {
                if (i == option.Length - 1 || option[i] == ' ')
                {
                    parsedOptions[index].Add(option.Substring(lastIndex, i - lastIndex + 1));
                    lastIndex = i + 1;
                }

            }
            pageDestinations.Add(option, destination);
        }

        public void setExitOption(string exitOption)
        {
            this.exitOption = exitOption;
        }

        public List<string> getOptions()
        {
            return options;
        }

        public List<List<string>> getParsedOptions()
        {
            return parsedOptions;
        }

        public string getExitOption()
        {
            return exitOption;
        }

        public bool areOptions()
        {
            return opt;
        }
    }
}
