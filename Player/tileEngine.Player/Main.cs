using tileEngine.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Player
{
    public partial class Main : Form
    {
        /// <summary>
        /// The game that is running in this player.
        /// </summary>
        GameControl game;

        public Main()
        {
            InitializeComponent();

            //Add game control to the form, dock.
            game = new GameControl();
            Controls.Add(game);
            game.Dock = DockStyle.Fill;
        }
    }
}
