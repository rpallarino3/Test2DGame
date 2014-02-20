using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Game;

namespace Menu
{
    class MenuFactory
    {

        private readonly int START_MENU = 0;
        private readonly int OPTIONS = 1;
        private readonly int GAME = 2;
        private readonly int LOAD = 3;
        private readonly int EXIT = 4;
        private readonly int VOL_UP = 5;
        private readonly int VOL_DOWN = 6;

        private Menu startMenu;
        private Menu optionsMenu;
        private Menu loadMenu;
        private Menu currentMenu;

        private GameState gameState;

        public MenuFactory(GameState gameState)
        {
            this.gameState = gameState;
            createMenus();
        }

        public void createMenus()
        {
            createStartMenu();
            createOptionsMenu();
            createLoadMenu();
            currentMenu = startMenu;
        }

        public void createStartMenu()
        {
            startMenu = new StartMenu(4, 1, Image.FromFile("../../../Images/Menus/StartMenu/StartMenu.png"));
            startMenu.fillDestination(0, 0, new Button(new Point(200, 100), GAME, Image.FromFile("../../../Images/Menus/StartMenu/Buttons/StartNewGame.png")));
            startMenu.fillDestination(1, 0, new Button(new Point(200, 200), LOAD, Image.FromFile("../../../Images/Menus/StartMenu/Buttons/LoadGame.png")));
            startMenu.fillDestination(2, 0, new Button(new Point(200, 300), OPTIONS, Image.FromFile("../../../Images/Menus/StartMenu/Buttons/Options.png")));
            startMenu.fillDestination(3, 0, new Button(new Point(200, 400), EXIT, Image.FromFile("../../../Images/Menus/StartMenu/Buttons/Exit.png")));
        }

        public void createOptionsMenu()
        {
            optionsMenu = new OptionsMenu(1, 1, Image.FromFile("../../../Images/Menus/OptionsMenu/Options.png"));
            optionsMenu.fillDestination(0, 0, new Button(new Point(200, 200), START_MENU, Image.FromFile("../../../Images/Menus/OptionsMenu/Buttons/Back.png")));
        }

        public void createLoadMenu()
        {
            loadMenu = new LoadMenu(1, 1, Image.FromFile("../../../Images/Menus/LoadMenu/LoadMenu.png"));
            loadMenu.fillDestination(0, 0, new Button(new Point(200, 200), START_MENU, Image.FromFile("../../../Images/Menus/LoadMenu/Buttons/Back.png")));
        }

        public Menu getCurrentMenu()
        {
            return currentMenu;
        }

        public void swapMenus()
        {
            Console.WriteLine("swapping menus");
            if (currentMenu.isAnimationFinished())
            {
                int dest = currentMenu.getCurrentButton().getDestination();

                if (dest == START_MENU)
                {
                    currentMenu = startMenu;
                    currentMenu.startAnimation();
                }
                else if (dest == OPTIONS)
                {
                    currentMenu = optionsMenu;
                    currentMenu.startAnimation();
                }
                else if (dest == GAME)
                {
                    gameState.setGameState();
                }
                else if (dest == LOAD)
                {
                    currentMenu = loadMenu;
                    currentMenu.startAnimation();
                }
            }           
            
            
        }

    }
}
