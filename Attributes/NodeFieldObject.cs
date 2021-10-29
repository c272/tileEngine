using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodeGame.Attributes
{
    /// <summary>
    /// Represents a wildcard node field that can take in and pass out any object.
    /// Does not allow for user editing with UserCanEdit, which will always be disabled.
    /// </summary>
    class NodeFieldObject : NodeFieldBasic
    {
        public NodeFieldObject(string name, FieldType type) : base(name, type, typeof(object), Color.Gray) 
        {
            //User can never edit this field with a control.
            UserCanEdit = false;
        }

        public override bool ValueIsValid()
        {
            return true;
        }
    }
}
