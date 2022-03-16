# Input Handling
### Generic Input
Input within tileEngine is not directly accessed by specifying a specific keyboard key, mouse button, or controller trigger, but is instead processed
into a more generic form of input before it is able to be utilised within the code. The programmer (you!) must first specify which of these more
specific inputs map to generic inputs before you can utilise them in your code. These translations are called "bindings" by tileEngine, and simply
specify what keys, buttons, or mouse inputs translate to what generic input names.

For example, I may specify that a generic input called "Jump" is going to cause my player character to jump when it is first pressed.
If this is the case, then I may create the following bindings to achieve that:
- A keyboard binding for the space key, that maps to the name "Jump".
- A controller binding for the A button, that maps to the name "Jump".

This way, regardless of if the player is using a controller or keyboard, in the code processing this input I don't have to alter anything to be
device specific, and they can be swapped between dynamically. In the following sections, methods of adding these bindings will be discussed,
as well as the different types of bindings that exist.

### Keyboard Input Bindings
To create keyboard input bindings, you can utilise the `KeyboardInputHandler` class through the current `TileEngine` instance. To add a simple
single-key binding to a generic input, you can do something like the following:
```cs
TileEngine.Instance.KeyboardInput.AddBinding(Keys.Space, "Jump");
```

This would create a binding that causes the generic input event "Jump" to be fired upon the space key being pressed. You can also specify in
these bindings which modifier keys have to be pressed for the input to fire, if you wanted to create a shortcut, for example. To create a binding
that mapped to "CTRL+Shift+Space", you could do the following:
```cs
//The last two parameters are "requiresCtrl" and "requiresShift" respectively.
TileEngine.Instance.KeyboardInput.AddBinding(Keys.Space, "SomeShortcut", true, true);
```

In addition to this, for these key bindings you can also specify a method to be called when the input is first fired. So, if you wanted an action
to happen immediately after the binding is pressed, and it's not well suited for placing in an update loop, you could do something like the following:
```cs
TileEngine.Instance.KeyboardInput.AddBinding(Keys.Space, "SomeShortcut", true, true, doSomeShortcut);

//...

private void doSomeShortcut()
{
	//Perform your shortcut code here!
	//...
}
```
*Note: The method that's passed to this binding as a callback must be a void method with no parameters. This is also called an "Action" delegate in C#.*

### Axis Input Bindings
The above section has detailed how to manage single and modifier key inputs, which are well suited to one-dimensional events such as a player's jump
or performing a shortcut, however can become more cumbersome when dealing with inputs that are going to be treated as two-dimensional, such as
player movement, or the moving of a cursor.

For this purpose, there is an alternate form of binding known as an "axis binding" within tileEngine that will allow you to treat a set of keys
as a two dimensional input field, represented by a 2D vector within the generic input. Creating these bindings is quite simple, as shown below.
```cs
//Arguments are: Axis X positive, Axis X negative, Axis Y positive, Axis Y negative.
TileEngine.Instance.KeyboardInput.AddAxisBinding(Keys.D, Keys.A, Keys.W, Keys.S, "Movement");
```

Axis bindings, unlike their single key binding cousins, are always active within the input handler once added, and when no inputs are fired have a
vector value of zero. This is also why axis bindings cannot have callbacks attached to them. The following code demonstrates this concept:
```cs
//This will always be true for axis bindings, as they are always "active", but may have a value of zero.
if (InputHandler.HasEvent("Movement"))
	//...
```

## Mouse Input Bindings
To add input bindings for mouse events, you can use the `TileEngine.Instance.MouseInput` input handler. The following types of events are available:
- Position: An always-active event that stores the current screen position of the mouse in the `Value` field of the input.
- ScrollWheel: An event that is fired every time the scroll wheel value is changed. Stores the cumulative scroll wheel value since game start in the `Value` field's "Y".
- LeftMouse: An event that is fired on left click.
- RightMouse: An event that is fired on right click.
- MiddleMouse: An event that is fired on middle click.

### Checking & Handling Input Events
Now that you've created several key and axis bindings, you will want to utilise within your code somewhere, such as in a GameObject update loop or
within the scene update loop. To do this, you can access the generic input API through the static "InputHandler" class, found within
`tileEngine.SDK.Input`. An example of how you'd process a single key event and an axis input event are shown below:
```cs
//If the jump input is down, jump.
if (InputHandler.HasEvent("Jump"))
	doJump();

//Apply movement to the character's position based on movement axis.
var movement = InputHandler.GetEvent("Movement");
Position = new Vector2(Position.X + movement.Value.X * delta,
					   Position.Y + movement.Value.Y * delta);
```