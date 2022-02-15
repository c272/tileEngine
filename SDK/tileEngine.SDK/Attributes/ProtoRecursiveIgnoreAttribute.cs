using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Attributes
{
    /// <summary>
    /// Makes the protobuf serializer ignore the class on recursive descent addition.
    /// </summary>
    public class ProtoRecursiveIgnoreAttribute : Attribute
    {
    }
}
