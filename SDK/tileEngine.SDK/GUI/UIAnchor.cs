using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.GUI
{
    /// <summary>
    /// Represents anchoring for UI elements within the GUI system.
    /// </summary>
    public enum UIAnchor
    {
        Center = 0b0,
        Top = 0b1,
        Right = 0b10,
        Bottom = 0b100,
        Left = 0b1000,
        All = 0b1111,

        //Automatic positioning properties.
        AutoLeft = 0b11001,
        AutoInline = 0b101001,
        AutoCenter = 0b1000001,
        AutoRight = 0b10000011
    }
}
