# The Camera
The camera in tileEngine is manipulated on a per-scene basis, and will be reset to the default position when changing between scenes. The camera's
position is relative to the top left of the screen, so at camera position (0, 0), the grid location (0, 0) will be located at the very top left
of the screen. The default location of the camera is (0, 0), and can be altered via. a scene object by utilising Scene.CameraPosition.

To alter the zoom of the camera, you can utilise the "Zoom" property of the Scene class. At 1.0x zoom (1.0f), every grid unit represents a single
pixel on the screen, so the distance between (0, 0) to (0, 1) is a single pixel. This relationship is scalar with the zoom applied, so at 1.5x zoom,
the distance for a single grid unit is 1.5 pixels. This is not something you have to consider within your external code, however, as the Scene class
has plenty of helper functions that will allow you to translate between screen and grid locations.

You can see a list of available helper methods on the [Scene API documentation page.](../api/tileEngine.SDK.Scene.html)