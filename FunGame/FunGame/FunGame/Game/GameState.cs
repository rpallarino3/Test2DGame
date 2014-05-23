using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGame.Game
{
    class GameState
    {

        private readonly int START_MENU = 0;
        private readonly int GAME_STATE = 1;
        private readonly int INVENTORY = 2;
        private readonly int NPC_CHAT = 3;

        private int state;

        public GameState()
        {
            state = START_MENU;
        }

        public int getState()
        {
            return state;
        }

        public void setStartMenuState()
        {
            state = START_MENU;
        }

        public void setGameState()
        {
            state = GAME_STATE;
        }

        public void setInventoryState()
        {
            state = INVENTORY;
        }

        public void setChatState()
        {
            state = NPC_CHAT;
        }
    }
}
