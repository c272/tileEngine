# GameObjects & Components
### Creating GameObjects
GameObjects are non-tile based programmable objects within your game that you can use to create scripted objects in your scene, such as a player
character, enemy, or simply a projectile. These are created by inheriting from the `GameObject` class, found within `tileEngine.SDK`. A barebones
GameObject will look something like the following:

```
public class Player : GameObject
{
    public Player()
    {
        //Initialization code here.
        //Alternatively, create another public method for initialization and call it from your scene.
        //...
    }

    public override void Update(GameTime delta)
    {
        base.Update(delta);
        //...
    }
}
```

You should ensure that, as with inheriting `Scene` classes, the base updates are **always called**, as these may perform basic universal GameObject
functions that may cause undefined behaviour when removed. GameObjects contain various properties intended to help the programmer when updating
their object at runtime, including a `Scene` property which contains the current scene (if any), and null otherwise. In addition to this, all
GameObjects have a list of components, which are additional functionality for the GameObject that can be added and removed at runtime.

### Adding GameObjects to Scene
Once you've successfully created your GameObject, you may want to add it into a scene so it will receive update and draw calls. To do this, you can 
either call the `Scene.AddObject()` method, or set the GameObject's "Scene" property to the scene you wish to add it to. **Do not add objects to a
scene by manipulating the GameObjects list within your scene code.** These methods perform additional important operations such as setting the 
GameObject's "Scene" property appropriately, and bypassing them will cause undefined behaviour.

```
myScene.AddObject(new Player()); //This is fine.

var player = new Player(); //This is also fine.
player.Scene = myScene;

GameObjects.Add(new Player()); //This will cause undefined behaviour.
```

### GameObject Components
There are several built-in components that you can add to your GameObjects to help with adding basic functionality such as drawing a sprite,
collision, and more. To add components to your GameObject, you simply add an instance of a `Component` class to the GameObject's "Component"
list property. All components built into the engine can be found in the `tileEngine.SDK.Components` namespace, but in this example we'll just add
a simple box collider with a given size and location.

```
public Player()
{
    Components.Add(new BoxColliderComponent()
    {
        Size = new Vector2(30, 30)
    });

}
```

Now this component is added, it will be able to perform its own custom draw and update functions during the game's update loop, without any
extra work from the programmer within the GameObject class. You are not limited to using just the built in components, you can also create custom
components for use within your own GameObjects. To do this, simply create a new class inheriting from the Component class, found in
`tileEngine.SDK.Components`. Once this is done, there are several overrides you can perform to create a component. As an example, an abbreviated
version of the SpriteComponent source code is attached below:

```
/// <summary>
/// Represents a component that draws a sprite relative to the attached GameObject.
/// </summary>
public class SpriteComponent : Component
{
    //...

    /// <summary>
    /// Draws the sprite to the screen at the GameObject's (relative) location.
    /// </summary>
    public override void Draw(GameObject gameObject, SpriteBatch spriteBatch)
    {
        //If no texture, ignore.
        if (Texture == null)
            return;

        //...
        spriteBatch.Draw(Texture, drawPosition, sourceRect, Color.White * Opacity, 0f, new Vector2(0, 0), drawScale, SpriteEffects.None, 0);
    }
}
```
*Note: Components that act as colliders should instead inherit from the `ColliderComponent` base class, and not directly from `Component`, so they
can access the methods required for checking collisions.*