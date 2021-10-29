using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodeGame.Controls
{
    /// <summary>
    /// Represents a single state in the state machine for a node graph control.
    /// </summary>
    public enum NodeGraphState
    {
        Default,
        MovingCamera,
        MovingNode,
        ConnectingNode
    }
}
