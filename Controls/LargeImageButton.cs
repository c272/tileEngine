using DarkUI.Config;
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
    public partial class LargeImageButton : UserControl
    {
        /// <summary>
        /// The title of this image button.
        /// </summary>
        public string Title
        {
            get { return buttonTitle.Text; }
            set { buttonTitle.Text = value; }
        }

        /// <summary>
        /// The subtitle of this image button.
        /// </summary>
        public string Subtitle
        {
            get { return buttonSubtitle.Text; }
            set { buttonSubtitle.Text = value; }
        }

        /// <summary>
        /// The icon used on this image button.
        /// </summary>
        public Image Icon
        {
            get { return buttonIcon.Image; }
            set { buttonIcon.Image = value; }
        }

        //Event for when the name of this node is changed.
        public delegate void ButtonClickedHandler();
        public event ButtonClickedHandler OnButtonClicked;

        public LargeImageButton()
        {
            InitializeComponent();

            //Add the transparent control to capture all mouse events.
            var transparentControl = new TransparentControl();
            transparentControl.Size = Size;
            transparentControl.MouseEnter += mouseEntered;
            transparentControl.MouseLeave += mouseLeft;
            transparentControl.MouseClick += mouseClick;
            transparentControl.Parent = this;
            transparentControl.BringToFront();
        }

        /// <summary>
        /// Triggered when the mouse is clicked on the control.
        /// </summary>
        private void mouseClick(object sender, MouseEventArgs e)
        {
            OnButtonClicked?.Invoke();
        }

        /// <summary>
        /// Triggered when the mouse leaves the control.
        /// </summary>
        private void mouseLeft(object sender, EventArgs e)
        {
            BackColor = ThemeProvider.Theme.Colors.LightBackground;
        }

        /// <summary>
        /// Triggered when the mouse enters this control.
        /// </summary>
        private void mouseEntered(object sender, EventArgs e)
        {
            BackColor = ThemeProvider.Theme.Colors.LighterBackground;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BackColor = ThemeProvider.Theme.Colors.LightBackground;
        }
    }
}
