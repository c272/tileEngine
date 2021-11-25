using DarkUI.Docking;
using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tileEngine.Controls
{
    /// <summary>
    /// Represents a single document openable in the main editor window.
    /// NOTE: Due to a bug with Visual Studio 2019 and below, you can not edit sub-classes of this form using the
    /// designer. This is due to VS being a 32-bit process trying to load a 64-bit class library.
    /// See https://support.microsoft.com/en-us/topic/cannot-display-inherited-form-in-form-designer-when-base-form-defined-in-64-bit-assembly-29ca1d78-f6e6-24d3-37e2-f1d918037ebf
    /// To solve this issue, temporarily switch the assembly to 32-bit mode and then edit in the designer, then switch back.
    /// </summary>
    public partial class ProjectDocument : DarkDocument
    {
        /// <summary>
        /// A globally unique identifier for this project document.
        /// </summary>
        public int ID { get; private set; } = Guid.NewGuid().GetHashCode();

        /// <summary>
        /// The node this document is synced to.
        /// </summary>
        public ProjectTreeNode Node { get; private set; }

        //The name of the font used for editor documents.
        protected const string EDITOR_FONT_NAME = "Roboto-Medium.ttf";

        //Designer constructor.
        private ProjectDocument() { }

        public ProjectDocument(ProjectTreeNode node)
        {
            Node = node;
            InitializeComponent();
            DockText = node.DisplayText;
        }
    }
}
