# Creating a Game
To create a game within tileEngine, you'll first need to have compiled the editor. You can see instructions of how to do this on the
"[Building tileEngine](building.md)" page, so steps for building will be omitted from this article. Once the project is fully built, open the
editor and select "Create Project". Here, you can choose a name and file location for your project. Note that you must create the project in an
empty folder, so it may help to make a separate folder for your game project somewhere sensible.

Once your project has been created and you are greeted with the main editor window, examine the project in the file browser to see the basic
structure of a tileEngine project. It consists of the following:
- `projectName.teproj`: This contains all non-code data about your project, such as the maps, imported asset tree, and metadata. As this file is
a binary blob, it is incompatible with git merging, so must be treated carefully with source control.
- `projectName.csproj`: This is the C# project for all the code that will be used in your game. Note that this is a custom `.csproj` setup generated
by the editor, and you cannot simply delete and recreate a new `.csproj` in its place for whatever reason, as this will break the editor's compile.

Before we can launch our game, we first have to create a barebones setup for our game within the C# project. Open the `.csproj` with the C# IDE of
your choice (preferably Visual Studio 2022+), and add references to the following assemblies:
- `/bin/Debug/tileEngine.SDK.dll`
- `/bin/Debug/MonoGame.Framework.dll`

This will allow us to interact with code from the engine, as well as utilise MonoGame classes within our external code. You can add a reference to
DLLs by right clicking "References" in the Visual Studio project tree, selecting "Add Reference", and then clicking "Browse" in the newly opened
window.

Now that we have the appropriate references imported into the project, we can add the main game class, a "TileEngineGame". This is the class that
tileEngine will call to perform game initialization and shutdown at runtime, so you can begin loading scenes and performing your own code. Create
a new class and make it inherit from `TileEngineGame`, found in the `tileEngine.SDK` namespace. Your class should look something like this after
implementing the required methods:

```
public class TutorialGame : TileEngineGame
{
    public override void Initialize()
    {
        //...
    }

    public override void Shutdown()
    {
        //...
    }
}
```

You now have a complete barebones setup for your game. Return to the editor, and click the "Start Project" button to build and run your project.
A blank blue window should open up with the name of your project in the title bar. If this is the case, then you've succesfully created your basic
"Hello World" project.