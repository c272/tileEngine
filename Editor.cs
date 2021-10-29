using easyCase.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        //The print node on the graph.
        private PrintNode printNode;

        public Editor()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            //Some add nodes.
            nodeGraphControl1.AddNode(new AddNode());
            nodeGraphControl1.AddNode(new AddNode()
            {
                Location = new Utility.Vector2(200, 200)
            });
            nodeGraphControl1.AddNode(new AddNode()
            {
                Location = new Utility.Vector2(-200, 200)
            });

            //A print node.
            printNode = new PrintNode()
            {
                Location = new Utility.Vector2(0, -200)
            };
            nodeGraphControl1.AddNode(printNode);
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        //Runs the print node on click.
        private void executeBtn_Click(object sender, EventArgs e)
        {
            printNode.Execute();
        }
    }
}
