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
        [NodeFieldNumeric("SomeInput", FieldType.Input)]
        public int SomeInput { get; set; }

        [NodeFieldNumeric("SomeOutput", FieldType.Output, UserCanEdit = false)]
        public int SomeOutput { get; set; }

        [NodeFieldNumeric("SomeOutput2", FieldType.Output)]
        public int AnotherOutput { get; set; }

        public ExampleNode() : base("Very Important Node", Color.Red, Color.White)
        {
        }
    }
}
