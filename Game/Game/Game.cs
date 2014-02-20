using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using PlayerStuff;
using Environment;
using Menu;

namespace Game
{
    class Game : Form
    {

        public readonly int START_MENU = 0;
        public readonly int GAME_STATE = 1;

        private List<Keys> keysDown;
        private Graphics g;
        private KeyHandler keyHandler;
        private PaintHandler paintHandler;
        private Stopwatch stopwatch;
        private Zone currentZone;
        private Player player;
        private MenuFactory menuFactory;
        private GameState gameState;
        private int count = 0;
        //private bool waiting = false;

        private bool isPaused = false;

        public Game() //set focus
        {
            this.Paint += new PaintEventHandler(Screen_Paint);
            this.KeyDown += new KeyEventHandler(Screen_KeyDown);
            this.KeyUp += new KeyEventHandler(Screen_KeyUp);
            //Size = new System.Drawing.Size(900, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            //FormBorderStyle = FormBorderStyle.None;
            ClientSize = new System.Drawing.Size(900, 600);
            //MaximizeBox = false;
            keysDown = new List<Keys>();
            keyHandler = new KeyHandler();
            paintHandler = new PaintHandler();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            player = new Player();
            player.setGlobalLocation(100, 1000);
            currentZone = new TestZone(50, 50);
            stopwatch = new Stopwatch();
            stopwatch.Start();
            gameState = new GameState();
            menuFactory = new MenuFactory(gameState);
            gameLoop();
        }


        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //count++;
            //Console.WriteLine(count);
            if (gameState.getState() == START_MENU)
            {
                paintHandler.drawMenu(g, menuFactory);
                paintHandler.drawHighlightedMenu(g, menuFactory);
                keyHandler.menuMove(menuFactory, gameState);
            }
            else
            {
                paintHandler.drawZone(g, player, currentZone);
                keyHandler.movePlayer(player, currentZone);
                Console.WriteLine(player.getGlobalLocation());
            }
            gameLoop();
        }

        private void Screen_KeyDown(object sender, KeyEventArgs e)
        {
            keyHandler.keyDown(e);
        }

        private void Screen_KeyUp(object sender, KeyEventArgs e)
        {
            keyHandler.keyUp(e);
        }

        public Zone getCurrentZone()
        {
            return currentZone;
        }

        public void setCurrentZone(Zone zone)
        {
            currentZone = zone;
        }

        private void gameLoop() // this whole thing needs to be redone
        {
            while (stopwatch.ElapsedMilliseconds <= 40)
            {
            }
            stopwatch.Restart();//not sure if before or after
            this.Invalidate();
        }

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Game());
        }
    }
}
