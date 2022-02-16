# Map Events
Events are entities within tileEngine that allow for the triggering of game code upon a range of triggers happening in the game world. They
are placed in the tileEngine map editor in the "Event" edit mode, and can be configured with the following options:
- The type of trigger that will cause the event to be fired. This includes things like a GameObject entering the tile with the event in, and
a GameObject performing an "interaction" with the tile.
- The linked event function that will be called when the event is fired. These will appear in the editor within a dropdown, and must be inside
the same class as the scene containing the event.

### Creating Event Functions
To create a function that you can link to an event in the map editor, you must create a method that has the following method signature:
```cs
[EventFunction("SomeName")]
private void MyEventFunction(TileEventData e)
{
	//...
}
```

The attribute applied above this event is an `EventFunctionAttribute`, and can be found in `tileEngine.SDK.Attributes`. This attribute must be
provided a name for the event function, and must be unique within the scene. Following this, the method must have a void return type, and take a
single argument of type `TileEventData`. Once these conditions are met, the function will appear in the editor window and will be able to be linked
to events on the map.

Don't forget that after creating an event function within the C# external project code, you must first compile the C# assembly and then reload it
within the tileEngine editor before it will appear within the event properties menu.

### Triggering Events
Events can be triggered in various ways, either by direct input interaction by the user, or by a collision with a GameObject. In the latter case,
the GameObject must meet certain conditions before it will trigger an event directly:
- It must be on the same layer as the event that is being triggered.
- It must have the "`TriggersEvents`" property set to `true`.

Once these conditions are met, the GameObject will trigger the collision event on that square.