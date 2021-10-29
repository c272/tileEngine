using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using easyCase.Attributes;

namespace easyCase.Nodes
{
    /// <summary>
    /// Example node class demonstrating implementing a simple repeating node.
    /// </summary>
    public class RepeatNode : Node
    {
        [NodeFieldNumeric("Amount", FieldType.Input, IntegersOnly = true)]
        public float TimesToRepeat { get; set; }

        [NodeFieldFlow("On Repeat", FieldType.Output)]
        public Action RepeatAction { get; set; }

        [NodeFieldFlow("On End", FieldType.Output)]
        public Action EndAction { get; set; }

        //The number of the repeat we're currently on.
        [NodeFieldNumeric("Index", FieldType.Output)]
        public float RepeatNumber { get; set; }

        public RepeatNode() : base("For Loop", Color.Blue, Color.White) { }

        //Runs the for loop.
        protected override void Run()
        {
            //Execute N times.
            for (int i = 0; i < TimesToRepeat; i++)
            {
                RepeatNumber = i;
                RepeatAction();
            }
            EndAction();
        }
    }
}
