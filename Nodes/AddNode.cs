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
    public class AddNode : Node
    {
        //test value
        [NodeFieldNumeric("Number", FieldType.Input)]
        public float FirstNumber { get; set; }

        [NodeFieldNumeric("Number", FieldType.Input)]
        public float SecondNumber { get; set; }

        [NodeFieldFlow(null, FieldType.Output)]
        public Action FlowOut { get; set; }

        [NodeFieldNumeric("Result", FieldType.Output)]
        public float AnotherOutput { get; set; }

        public AddNode() : base("Addition", Color.Green, Color.White) { }

        //Executes when the node is run.
        protected override void Run()
        {
            AnotherOutput = FirstNumber + SecondNumber;
            FlowOut();
        }
    }
}
