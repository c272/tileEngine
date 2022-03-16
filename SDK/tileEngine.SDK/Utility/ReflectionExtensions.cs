using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Utility
{
    /// <summary>
    /// Extension methods for reflections within the editor.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Returns a list of methods including inherited parent methods.
        /// </summary>
        public static IEnumerable<MethodInfo> GetMethodsWithInheritance(Type type)
        {
            IEnumerable<MethodInfo> methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (type.BaseType != null)
            {
                methods = methods.Concat(GetMethodsWithInheritance(type.BaseType));
            }
            return methods;
        }
    }
}
