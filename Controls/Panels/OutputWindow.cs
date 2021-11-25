using DarkUI.Config;
using DarkUI.Docking;
using MonoGame.RuntimeBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents the compiler output window (default right) in tileEngine.
    /// </summary>
    public partial class OutputWindow : DarkToolWindow
    {
        //String builder logger for compiler output.
        private StringBuilderLogger logger = new StringBuilderLogger();

        public OutputWindow()
        {
            InitializeComponent();
            logText.BackColor = ThemeProvider.Theme.Colors.DarkBackground;
            ProjectCompiler.Logger = logger;
            logger.OnMessageLogged += messageLogged;
        }

        /// <summary>
        /// Triggered when a new message is logged.
        /// </summary>
        private void messageLogged(string message)
        {
            logText.Text = logger.Log.ToString();
        }

        /// <summary>
        /// Resets the output window text.
        /// </summary>
        public void Reset()
        {
            logger.Log.Clear();
        }
    }
}
