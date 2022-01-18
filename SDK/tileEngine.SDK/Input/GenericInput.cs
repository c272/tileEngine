using Microsoft.Xna.Framework;

namespace tileEngine.SDK.Input
{
    /// <summary>
    /// Represents a single generic input from an input source.
    /// Can optionally have a two-axis component.
    /// </summary>
    public struct GenericInput
    {
        /// <summary>
        /// The generic name of the input.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The two-axis value of the input, if any.
        /// </summary>
        public Vector2 Value { get; set; }

        /// <summary>
        /// The source device of the input.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Data related to the originating source binding.
        /// Arbitrary based on the handler.
        /// </summary>
        public object BindingData { get; set; }
    }
}