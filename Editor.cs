using easyCase.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyCase
{
    public partial class Editor : Form
    {
        /// <summary>
        /// Incredibly nasty hack to solve a fundamental problem with WinForms drawing.
        /// Without WS_EX_COMPOSITED, WinForms will leave a giant gaping black hole in place while the
        /// child control is drawing over the invalidated part of the form, making it look really ugly.
        /// WS_EX_COMPOSITED solves this by not drawing until all child controls have been written.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                //Turn on WS_EX_COMPOSITED to stop child control flickering.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        //The node to execute first on the graph.
        private Node toExecute;

        public Editor()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            //Some add nodes.
            nodeGraphControl1.AddNode(new AddNode());

            //A print node.
            nodeGraphControl1.AddNode(new PrintNode()
            {
                Location = new Utility.Vector2(0, -200)
            });

            //A repeat node.
            toExecute = new RepeatNode()
            {
                Location = new Utility.Vector2(0, 200)
            };
            nodeGraphControl1.AddNode(toExecute);
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        //Runs the print node on click.
        private void executeBtn_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            toExecute.Execute();
            watch.Stop();
            System.Diagnostics.Debug.WriteLine("Execution path took " + watch.ElapsedMilliseconds + "ms.");
        }
    }
}
