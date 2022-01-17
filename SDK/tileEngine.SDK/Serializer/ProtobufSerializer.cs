using Microsoft.Xna.Framework;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tileEngine.Utility;

namespace tileEngine.SDK.Serializer
{
    /// <summary>
    /// Represents a class utilising ProtoBuf for serialization within tileEngine.
    /// Performs setup & configuration of ProtoBuf for use with MonoGame & tileEngine base classes.
    /// </summary>
    public static class ProtobufSerializer
    {
        /// <summary>
        /// Whether the serializer has already been configured for use or not.
        /// </summary>
        public static bool SerializerPrepared { get; private set; } = false;

        /// <summary>
        /// Prepares the serializer to save tileEngine data to file by registering important
        /// classes as sub-types at runtime.
        /// </summary>
        public static void PrepareSerializer()
        {
            //If the serializer has already been prepared, ignore this call.
            if (SerializerPrepared)
                return;

            //Register all subtypes of necessary types for serialization.
            RegisterSubTypes(typeof(Snowflake), 500);

            //Force protobuf to compile MonoGame's Vector2.
            var vec2 = RuntimeTypeModel.Default.Add(typeof(Vector2));
            vec2.AddField(1, "X");
            vec2.AddField(2, "Y");

            //Force protobuf to serialize MonoGame's Point.
            var point = RuntimeTypeModel.Default.Add(typeof(Point));
            point.AddField(1, "X");
            point.AddField(2, "Y");
            SerializerPrepared = true;
        }

        /// <summary>
        /// Registers all subtypes of the given type into Protobuf-net, with the given starting ID.
        /// </summary>
        public static void RegisterSubTypes(Type baseType, int startID = 500)
        {
            //Get all sub-types of the given type.
            var assembly = baseType.Assembly;
            var subTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType) && t.BaseType == baseType);

            //Register them with the runtime model, starting at ID "startID".
            for (int i = 0; i < subTypes.Count(); i++)
            {
                Type subType = subTypes.ElementAt(i);
                RuntimeTypeModel.Default[baseType].AddSubType(startID + i, subType);
                RegisterSubTypes(subType, startID);
            }
        }
    }
}
