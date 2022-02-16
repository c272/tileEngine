# Debugging
All debugging within tileEngine is performed through a single diagnostics class, `DiagnosticsHook`, which can be found in `tileEngine.SDK.Diagnostics`.
This class contains utility methods for sending an error, warning, notice, and debug messages, and emits all of these messages through an event
which can then be processed by other external and internal code.

The diagnostics hook class can be configured to run in two separate modes, "Editor" and "Standalone". When running external code, the diagnostics
hook will always be set to "Standalone" mode, so this is not a concern for external assemblies.

### Errors, Warnings & Notices
To send an error, warning, or notice to the user at runtime, the `LogMessage()` method can be used. This method takes in an error code, message,
and severity, and will then send this to all event listeners to be handled. If you encounter a fatal error within the game, and wish to exit the
application with an error message, this is the method to call.
```cs
DiagnosticsHook.LogMessage(1001, "This is a fatal error message that will exit the player.", DiagnosticsSeverity.Error);
```
*Note: The last parameter here is optional, and will default to "Error".*

### Debug Logging
To log a debug message for use during development, there is a separate function that should be used for this purpose. This function will only
have an effect when the player is running in Debug mode, and the end user in Release mode will not be able to see this output. To log a debug
message with the diagnostics hook, you can do something like the following.
```cs
DiagnosticsHook.DebugMessage("This is a debug message!");
```

Once this debug message is sent by the diagnostics hook, it will be visible in the player's debug window. This can be opened by pressing "F12"
when the player is running, and will display all debug output coming from the game inside the text area within the window.

### The Debug Window
As discussed prior, the debug window in the player contains several useful features to enable easy debug logging during development, however it also
has several other uses. Within the debug window, you can also enable "Draw Colliders", which will visually display the collision hull from all
tile map layers, as well as the collision components for all GameObjects, for debugging collision issues.