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
    [NodeFieldFlow(null, FieldType.Output)]
    public class AddNode : Node
    {
        //test value
        [NodeFieldNumeric("Number", FieldType.Input)]
        public float FirstNumber { get; set; }

        [NodeFieldNumeric("Number", FieldType.Input)]
        public float SecondNumber { get; set; }

        [NodeFieldNumeric("Result", FieldType.Output)]
        public float AnotherOutput { get; set; }

        public AddNode() : base("Addition", Color.Red, Color.White) { }

        //Executes when the node is run.
        protected override void Run()
        {
            AnotherOutput = FirstNumber + SecondNumber;
        }
    }
}
