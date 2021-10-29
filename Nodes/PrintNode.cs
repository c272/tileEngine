using easyCase.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCase.Nodes
{
    [NodeFieldFlow(null, FieldType.Input)]
    public class PrintNode : Node
    {
        [NodeFieldObject("Input", FieldType.Input)]
        public object Input { get; set; } = null;

        public PrintNode() : base("Print", Color.Green, Color.White) { }

        //Writes the input to console.
        protected override void Run()
        {
            System.Diagnostics.Debug.WriteLine(Input);
        }
    }
}
