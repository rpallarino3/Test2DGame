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
    }
}
