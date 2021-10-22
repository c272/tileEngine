using easyCase.Controls;
using easyCase.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCase.Attributes
{
    /// <summary>
    /// Represents a single numeric field on a node.
    /// </summary>
    
    public class NodeNumericField : NodeField
    {
        public NodeNumericField(FieldType type) : base(type) { }

        /// <summary>
        /// Draws the numeric field to the control, at the provided position.
        /// </summary>
        public override void Draw(NodeGraphControl control, Graphics graphics, Vector2 position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the expected dimensions of this numeric field.
        /// </summary>
        public override Vector2 GetDimensions(NodeGraphControl control)
        {
            return new Vector2(0, 10);
            //throw new NotImplementedException();
        }
    }
}
