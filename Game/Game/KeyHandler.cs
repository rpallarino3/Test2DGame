using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerStuff;
using Environment;
using Menu;

namespace Game
{
    class KeyHandler
    {

        private readonly int KEY_W = 1;
        private readonly int KEY_A = 2;
        private readonly int KEY_S = 4;
        private readonly int KEY_D = 8;
        private readonly int KEY_ENTER = 16;
        private readonly int KEY_SPACE = 32;

        private int keys = 0;

        private List<Keys> keysDown;
        private MovementHandler movementHandler;

        public KeyHandler()
        {
            keysDown = new List<Keys>();
            movementHandler = new MovementHandler();
        }

        public void keyDown(KeyEventArgs e)
        {
            if (!keysDown.Contains(e.KeyCode))
            {
                keysDown.Add(e.KeyCode);
            }
        }

        public void keyUp(KeyEventArgs e)
        {
            if (keysDown.Contains(e.KeyCode))
            {
                keysDown.Remove(e.KeyCode);
            }
        }

        public void movePlayer(Player player, ZoneFactory zoneFactory)
        {
            movementHandler.movePlayer(player, zoneFactory, keysDown);
        }

        public void menuMove(MenuFactory menuFactory, GameState gs)
        {
            if (keysDown.Contains(Keys.W))
            {
                menuFactory.getCurrentMenu().moveUp();
            }
            else if (keysDown.Contains(Keys.A))
            {
                menuFactory.getCurrentMenu().moveLeft();
            }
            else if (keysDown.Contains(Keys.S))
            {
                menuFactory.getCurrentMenu().moveDown();
            
            }
            else if (keysDown.Contains(Keys.D))
            {
                menuFactory.getCurrentMenu().moveLeft();
            }
            else if (keysDown.Contains(Keys.Enter))
            {
                menuFactory.swapMenus();
            }
            
            
        }

    }
}
