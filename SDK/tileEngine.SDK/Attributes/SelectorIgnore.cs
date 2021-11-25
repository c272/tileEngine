using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Attributes
{
    /// <summary>
    /// Represents an attribute that will prevent selectors from adding this class to the option list.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SelectorIgnore : Attribute { }
}
