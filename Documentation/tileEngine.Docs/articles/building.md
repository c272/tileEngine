# Building tileEngine
To begin building tileEngine, you will first need to ensure the following prerequisites are met:
- The .NET Framework 4.7.2 SDK is installed for your Visual Studio version (this can be installed via. the *Visual Studio Installer*)
- All submodules for tileEngine have been cloned. You can do this by navigating to the root directory of the project and performing the following commands:
```
git submodule init
git submodule update
```
- NuGet packages for all projects in the solution have been restored. You can do this by right clicking the solution in the Visual Studio
project browser, and then clicking "Restore NuGet Packages".
- "[Visual C++ Redistributable Packages for Visual Studio 2013](https://www.microsoft.com/en-us/download/details.aspx?id=40784)" is installed. 

Once these prerequisites are met, you can build the tileEngine solution through visual studio with "Build Solution" (`CTRL+SHIFT+B`), or simply by running
`msbuild` from the root project directory. If builds are taking a long time, consider unloading the documentation project, tileEngine.Docs. The documentation
building engine for the project takes a considerable amount of time to re-generate the API documentation, and is mostly unneeded barring major releases.
Unloading can be done by right clicking the project and selecting "Unload Project" once opened in Visual Studio.

### Modifying `tileEngine.Player`
At some point you may wish to modify the behaviour of the engine window host project, tileEngine.Player. If this is the case, there are several things
to be aware of when starting, which should be abided by to avoid errors.

1. When modifying `tileEngine.Player` and testing this new player from the editor, make sure to use "Clean Project" before compiling and running the
game. By default, tileEngine does not re-copy the entire player on every compile, only if the player is not already present, to save on disk operations.
2. Any fatal crashes within `tileEngine.Player` will not be surfaced as exceptions within the Visual Studio debugger if you are using it through the
editor. This is because the editor simply invokes the program normally, and does not attach the debugger handle. To run debugging features and breakpoints
with the player, you can do the following:
	- Copy the "compiled" and "external" folders as well as "main.bin" from the game's `./bin` into `tileEngine.Player/bin/Debug/`.
	- Switch Visual Studio to start the player instead of the editor (this can be done with the dropdown to the left of the start button).
	- Start the player from within Visual Studio.