using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Serializer
{
    /// <summary>
    /// Allows for the loading of an assembly in a separate domain without loading in the
    /// executing domain, and returning an assembly reference as a result.
    /// </summary>
    public class AppDomainLoader : MarshalByRefObject
    {
        //The resulting loaded assembly.
        public Assembly Result = null;

        //The path of the assembly to load.
        private string path;

        /// <summary>
        /// Creates an AppDomain loader for the given DLL path.
        /// </summary>
        public AppDomainLoader(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Loads the assembly. This method should be passed as an argument to AppDomain.DoCallback.
        /// </summary>
        public void Run()
        {
            Result = AppDomain.CurrentDomain.Load(File.ReadAllBytes(path));
        }
    }
}
