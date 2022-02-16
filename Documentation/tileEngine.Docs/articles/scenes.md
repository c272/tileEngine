# Scene Management
### Creating Scenes
Scenes are separate environments with their own map, events, and code within tileEngine, and are created by simply creating a class inheriting from
the "Scene" class found in `tileEngine.SDK`. Once you have created a scene class, a barebones setup may look something like the following:

```cs
public class TutorialScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();
        //...
    }

    public override void Update(GameTime delta)
    {
        base.Update(delta);
        //...
    }
}
```
*Editor Note: Once you've created a new scene and built your C# project, you can press the "Reload Project" (blue refresh icon) button within the
editor to load this new scene in the project tree.*

Scenes have several virtual methods which you can use to add functionality to your game on various events in the engine, such as during the update
loop, and during initialization (first startup) of the scene. Be aware that you should **always call the base function** when overriding these methods,
as important base functionality is performed within the Scene class to avoid you having to do it manually.

This base class also contains many helper methods for converting between different point systems (eg. from grid space to screen space, and vice
versa, and from tile coordinates to grid space and vice versa), as well as several methods for handling adding and removing GameObjects from your
scene. This article will not go into full detail on the entire scene API, however you can find full information on the [API documentation page.](../api/tileEngine.SDK.Scene.html)

### Switching Scene
Now that you've created a scene, it must be set as the current scene for the game to begin drawing to the screen and running code. In this example,
the scene is switched to upon game startup, however you could do this anywhere within your codebase. Switching to a scene is performed by calling
the `SetScene()` method on the current `TileEngine` instance.

```cs
class TutorialGame : TileEngineGame
{
    public override void Initialize()
    {
        TileEngine.Instance.SetScene(typeof(TutorialScene));
    }

    //...
}
```

The method takes an argument of a type, which must inherit from `Scene`.