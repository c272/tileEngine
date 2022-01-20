# Asset Management
Assets in tileEngine are compiled into MonoGame's (originally from Microsoft's XNA framework) "`.xnb`" format for use within the engine at runtime.
To load and have these assets compiled for use in the game, you must first import these assets in the tileEngine editor, and will then be able to
reference them within code and use them within the map editor.

To import an asset into the tileEngine editor's project window, click the button at the bottom of the project tree window that is labelled
"Import Asset". Then, select the asset you wish to import into the project, and it will be placed into the project tree. When importing assets,
be aware that tileEngine uses a relative path to track the location of this asset for compiling, so changing the asset's position in the file system
relative to the `.teproj` file will break loading for that asset. To prevent this happening, it's recommended to place all assets you're using in
a subfolder within your project folder, rather than outside your project folder.

### Loading Assets in Code
To load an asset at runtime to be used within your external game code, you can utilise the `AssetManager` class, found within `tileEngine.SDK`.
This class allows you to attempt loading for any asset within the project tree that has been compiled to XNB format. To utilise it you can do
something like the following:
```
Texture2D myAsset = AssetManager.AttemptLoad<Texture2D>("SomeFolder/myAssetName.png");
```

The path provided to the `AttemptLoad` function here is directly correlated to where your asset is in the tileEngine editor's project tree. In the
above example, the asset was placed within a folder named "SomeFolder", which was in the project root. Path elements are separated by a forward slash.
If the asset you're trying to load can't be found, the game will show an error message, and possibly exit depending on the debug settings. The returned
value from this function will be `null`.

**Calling the asset manager to load any compiled XNB data is an expensive operation.** Do not try and perform this within a draw function or update
loop to grab a texture, instead perform asset loads like this only on initialization of wherever this asset is stored (eg. within `Scene.Initialize`
or a GameObject initialize function) and then save the asset in a variable for use during draw, or wherever else it is used.