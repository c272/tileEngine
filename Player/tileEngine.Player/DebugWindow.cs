using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.SDK.Components;
using tileEngine.SDK.Diagnostics;

namespace tileEngine.Player
{
    /// <summary>
    /// Represents a debugging window within the tileEngine player, used for
    /// development debugging purposes.
    /// </summary>
    public partial class DebugWindow : DarkForm
    {
        public DebugWindow()
        {
            InitializeComponent();
            DiagnosticsHook.OnDebugMessage += debugMessageReceived;
        }

        /// <summary>
        /// Triggered when this debug window receives a debug message.
        /// </summary>
        private void debugMessageReceived(string msg)
        {
            debugOutput.Text += msg + "\r\n";

            //Trim text if too long.
            if (debugOutput.Text.Length > 5000)
                debugOutput.Text = debugOutput.Text.Substring(debugOutput.Text.Length - 5000);

            //Scroll to end of debug log.
            debugOutput.SelectionStart = debugOutput.Text.Length;
            debugOutput.ScrollToCaret();
        }

        /// <summary>
        /// Triggered when the "Draw Colliders" checkbox is changed.
        /// </summary>
        private void drawCollidersChanged(object sender, EventArgs e)
        {
            ColliderComponent.DrawColliders = drawCollidersCb.Checked;
        }
    }
}
