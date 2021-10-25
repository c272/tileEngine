using easyCase.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCase.Nodes
{
    /// <summary>
    /// An example node for testing.
    /// </summary>
    public class ExampleNode : Node
    {
        //test value
        [NodeNumericField("SomeValue", FieldType.Input)]
        public int SomeValue { get; set; }

        public ExampleNode() : base("ExampleNode!", Color.Red, Color.White)
        {
        }
    }
}
