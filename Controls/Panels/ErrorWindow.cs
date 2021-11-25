using DarkUI.Config;
using DarkUI.Docking;
using tileEngine.SDK.Diagnostics;
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
    /// Represents a window where individual compile and runtime errors are presented to the user.
    /// </summary>
    public partial class ErrorWindow : DarkToolWindow
    {
        public ErrorWindow()
        {
            InitializeComponent();

            //Switch the diagnostics mode to editor, hook into messages.
            DiagnosticsHook.Mode = DiagnosticsMode.Editor;
            DiagnosticsHook.OnDiagnosticsMessage += messageLogged;
        }

        /// <summary>
        /// Triggered when a new diagnostics message is sent by the engine.
        /// </summary>
        private void messageLogged(DiagnosticsMessage msg)
        {
            //todo
        }
    }
}
