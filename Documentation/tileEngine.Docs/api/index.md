# Welcome to the tileEngine API Documentation.
Welcome to the tileEngine API docs. In this section, details of all public and internal APIs are available for all projects within tileEngine. Below is a quick
outline of what each project does, and what you'd likely use it for, as a quick pointer to help you figure out where to go.

| Namespace      | Purpose |
| ----------- | ----------- |
| **tileEngine** | This namespace contains core tileEngine Editor components such as the main editor screen, project data structures, and the project manager/compiler. |
| **tileEngine.Controls** | This namespace contains core tileEngine Editor components such as the main editor screen, project data structures, and the project manager/compiler. |
| **tileEngine.Controls.Properties** | This is a small namespace comprising of controls for properties windows in the editor. |
| **tileEngine.Engine** | This namespace contains all of the core engine code such as scene loading, drawing, game data handling and font loading. |
| **tileEngine.Forms** | This namespace contains all forms (screens) used within the tileEngine editor but the main screen. |
| **tileEngine.Player** | This namespace contains the runtime player for tileEngine games, that the end user will start up and run. It also has some debug features for development purposes. |
| **tileEngine.SDK** | The main SDK namespace for tileEngine. This namespace and it's children contain all of the API that is accessible from outside tileEngine (eg. from a game project.) In the core SDK namespace are the main TileEngine API, TileEngineGame, and some core engine related classes. |
| **tileEngine.SDK.Attributes** | This contains attributes used for interaction with the main engine, as well as with the Editor selection window. |
| **tileEngine.SDK.Components** | This contains built-in GameObject components shared with external assemblies. |
| **tileEngine.SDK.Diagnostics** | This contains the API for debugging and errors during runtime of a game. *Utilise this in place of System.Diagnostics.* |
| **tileEngine.SDK.Input** | This contains all input handlers and input APIs for use in external game code. |
| **tileEngine.SDK.Map** |  This contains data classes for tile maps, map events, and map event handling within tileEngine. |
| **tileEngine.Serializer** | This contains helper classes for serializing classes within tileEngine. Used internally in tileEngine.Editor & tileEngine.Player for loading/saving. |
| **tileEngine.Utility** | This contains various utility and helper classes that are internally shared between projects. |