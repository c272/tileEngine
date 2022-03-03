# GUI System
The GUI system within tileEngine is a fully adaptable anchor-based GUI system that uses the typical "element tree" model for building user interfaces
that are rendered on top of scenes within the game. This article is a basic introduction on how to initialize the GUI within tileEngine, and how
elements and groups can be laid out to automatically position elements correctly.

## Anchors
All elements within tileEngine are placed using anchors and offsets. The **anchor** of an element determines which location the element is pinned
to when it's **offset** is `(0, 0)`. For example, using the anchor `Top | Left` will result in the element being placed in the very top left of the
screen by default. This is also the default setting for all elements.

The following anchor types are currently available to use:
- All four cardinal directions (`Top`, `Left`, `Right`, `Down`) and `Center`, which can be combined using the binary OR operator.
- `AutoLeft`
- `AutoInline`
- `AutoCenter`
- `AutoRight`

The below diagram illustrates how these are laid out within the game window.
![GUI Anchor Diagram](../images/gui-anchor-diagram.png)

The anchors that are "non-auto" (the four directions and center) do not perform any automatic inlining or spacing relative to other elements.
In other words, they are **absolutely positioned**, meaning that elements that are added after/before them in the same parent GUI element can
(and likely will) overlap.

The anchors that are "auto" perform various forms of automatic placement.
- `AutoInline` places elements directly to the right of the previous element.
- `AutoLeft` places elements anchored to the left under the previous element.
- `AutoCenter` places elements anchored centrally (horizontally) under the previous element.
- `AutoRight` places elements anchored to the right under the previous element.

You can adjust the placement of all elements by changing the `Offset` of the element. This is always relative to the top left of the screen,
so positive X moves the element to the right, and positive Y moves the element down.

## Element Tree
The UI in tileEngine is a heirarchy-based system, with a collection of root nodes of the UI, which can contain child nodes, who themselves can
hold child nodes, et cetera. To add a root node to the UI system, you can simply do:
```cs
UI.AddElement(someElement);
```

This will add the element at the very top of the heirarchy. To then add a child to any UI element, you can use the same method signature:
```
someElement.AddElement(subElement);
```
The syntax for removing elements is fairly self explanatory, and is simply the method `RemoveElement(UIElement)`. You can also wipe the entire UI
system clean with `UI.Clear()`.

## Initializing the UI
Before you can begin using the UI system, you must first initialize it with the required setup properties, such as the font it will use for
drawing. To initialize the UI system, you simply call [`UI.Initialize`]() like so:
```
UI.Initialize("some/font.ttf");
```
Notice that there is an asset path passed in here; this is an asset path that refers directly to a **font asset**. You can import a font asset
into your project using the "Import Asset" button found in the Project Explorer in the tileEngine editor. Once this is done, you can refer to this
asset in the initialize function to use it in your UI. (For more information on asset paths, see [the assets article](assets.md).)