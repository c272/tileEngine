# Collision
Collisions within tileEngine are handled by the currently running scene's update loop, and are processed *after* GameObject updates have concluded.
Whether two objects are colliding are determined by their attached `ColliderComponent` components. If there are no collider components attached to
a GameObject, then it will not be processed for collision, and therefore be non-solid.

There are several types of basic collision built into tileEngine, including a basic circular and box collider, which can be found in
`tileEngine.SDK.Components`. If you wish to create your own custom collision for a GameObject, however (for instance if it has an odd shape or
changes shape dynamically), you can create a component inheriting from `ColliderComponent` and override the required methods. Here's a barebones
example of a collider class, without implementation:

```cs
/// <summary>
/// Represents a simple box collider within tileEngine.
/// </summary>
public class BoxColliderComponent : ColliderComponent
{
    /// <summary>
    /// Draws this collider as a debugging tool, if enabled.
    /// </summary>
    public override void Draw(GameObject gameObject, SpriteBatch spriteBatch)
    {
        if (!DrawColliders)
            return;
        //...
    }

    /// <summary>
    /// Checks if this box collider is colliding with any collision hull elements.
    /// </summary>
    public override List<Point> Colliding(GameObject gameObject, TileLayer layer)
    {
        //...
    }

    /// <summary>
    /// Returns whether this collider is colliding with a specific tile location.
    /// </summary>
    public override bool CollidingWith(GameObject gameObject, TileLayer layer, Point tile)
    {
        //...
    }
}
```