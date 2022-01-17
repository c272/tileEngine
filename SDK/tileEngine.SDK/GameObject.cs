namespace tileEngine.SDK
{
    /// <summary>
    /// Represents a single active game object within the scene.
    /// Intended as a programmable in-game entity.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// The layer that this game object is on.
        /// This corresponds to what layer on the map events/collisions will occur on.
        /// </summary>
        public int Layer { get; set; } = 0;
    }
}