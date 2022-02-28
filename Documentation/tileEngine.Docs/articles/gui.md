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
![GUI Anchor Diagram](/images/gui-anchor-diagram)

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