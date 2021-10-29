using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace nodeGame.Utility
{
    /// <summary>
    /// Implements a globally unique public ID per instance for differentiating instances easily.
    /// </summary>
    public abstract class Snowflake : IEquatable<Snowflake>
    {
        /// <summary>
        /// The unique identifying ID of this node instance.
        /// </summary>
        public int ID = Guid.NewGuid().GetHashCode();

        /// <summary>
        /// Returns whether this snowflake is the same instance as another.
        /// </summary>
        public bool Equals(Snowflake other)
        {
            if (other == null) { return false; }
            return other.ID == ID;
        }
    }

    /// <summary>
    /// Implements a globally unique public ID per instance for differentiating instances,
    /// for attribute classes.
    /// </summary>
    public class SnowflakeAttribute : Attribute, IEquatable<SnowflakeAttribute>
    {
        /// <summary>
        /// The unique identifying ID of this node instance.
        /// </summary>
        public int ID = Guid.NewGuid().GetHashCode();

        /// <summary>
        /// Returns whether this snowflake is the same instance as another.
        /// </summary>
        public bool Equals(SnowflakeAttribute other)
        {
            if (other == null) { return false; }
            return other.ID == ID;
        }
    }
}
