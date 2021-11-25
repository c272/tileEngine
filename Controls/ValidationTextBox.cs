using DarkUI.Config;
using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Controls
{
    /// <summary>
    /// Text box which displays an error outline when not valid.
    /// </summary>
    public class ValidationTextBox : DarkTextBox
    {
        /// <summary>
        /// Whether the text box currently contains a valid value.
        /// </summary>
        public bool Valid
        {
            get { return valid; }
            set
            {
                valid = value;
                mousedAlready = false;
                drawBorder();
            }
        }
        private bool valid = true;

        //Whether this control has already been moused over (no need to draw border).
        private bool mousedAlready = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            drawBorder();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            drawBorder();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mousedAlready = true;
        }

        //Draws the border.
        private void drawBorder()
        {
            if (!mousedAlready && !valid)
                ControlPaint.DrawBorder(this.CreateGraphics(), ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
