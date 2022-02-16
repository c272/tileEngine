# Sound
## Preamble
Before you begin using the tileEngine sound API, it's important to first understand how the API is structured in the backend for the sake of
platform agnostic programming, and how this might affect how you write your code.

Sound in tileEngine is managed through a [generic API](../api/tileEngine.SDK.Audio.Sound.html), which is then implemented in the backend on a per-platform basis. Windows, Linux and 
(at some point) MacOS have their own individual sound API implementations, and therefore there may be platform differences in volume, 
latency and load-time performance. Because of this, you should not depend on the experience for loading and playing sounds being identical across 
all devices, and should plan to load sounds as early as possible in the runtime pipeline (eg. at the same time as initializing your other assets 
like sprites and fonts) before playing them, instead of playing sounds directly.

In addition to this, you should try and avoid loading huge (>50MB) sounds if possible. At runtime, sounds are required to be converted into a 
consistent sample rate and channel configuration to be played, so keep in mind the memory implications of loading a very large compressed file, 
such as a 50MB MP3, as this may unpack into a much larger memory space. This isn't a massive concern unless you're loading something like an hour's
worth of sound data at once, but it's something that you should be aware of.

## Adding Sounds
Adding sounds to your project is as simple as clicking the "Import Assets" button within the Project Explorer in the main tileEngine editor window,
and then moving it into the folder structure you feel is appropriate. This imported asset will then be referenced with it's tileEngine asset path
(eg. "music/myAsset"), as seen in the [asset management article](assets.md).

The following formats are supported to be played on all platforms:
- MP3\*
- AIFF (Audio Interchange File Format)
- WAV (Waveform Audio File Format)

\**Note: Some short, low bitrate MP3 files do not load properly with the Windows NAudio sound API implementation. If this occurs, try converting
the file into .WAV or .AIFF format instead.*

## Loading Sounds
To load a sound at runtime within your project, you can reference the engine's [`Sound`](../api/tileEngine.SDK.Audio.Sound.html) class, found at 
`TileEngine.Instance.Sound`. For the sake of simplicity, for the rest of this document the class will just be referred to as `Sound`. 
Loading a sound from your asset tree directly can be done like so:
```cs
SoundReference loadedSound = Sound.LoadSound("my/asset/path");
```

This returns a [`SoundReference`](../api/tileEngine.SDK.Audio.SoundReference.html), which is simply a refrerence to this loaded sound that you can 
use to play it later. Loading sounds should be done at the same time as your other asset loads such as sprites and fonts, to avoid hitting the 
filesystem during gameplay and possibly causing hitching/stutters.

Calling `LoadSound` will also perform platform specific processing to convert the sound into a runtime playable format, so calling this method is
naturally quite expensive, and should only be done at times where asset loading is appropriate.

## Playing Sounds
Playing a sound is incredibly simple, and works similarly to loading, however with a few minor differences. Sounds can be played directly from the
asset tree without being loaded first, like so:
```cs
//This will load and play a sound at the same time, if the sound has not already been loaded.
Sound.PlaySound("my/asset/path");
```

This is **not recommended**, and not good practice unless you're calling this in a location where loading is absolutely appropriate. A much better
way to achieve this result would be to pre-load your sound in some sort of asset loading method, and then use a reference to this loaded sound
to play it later on, as in the following example.
```cs
//Loading sound required later.
SoundReference loadedSound = Sound.LoadSound("my/asset/path");

//...

//Play previously loaded sound.
Sound.PlaySound(loadedSound);
```

## Volume Control & Looping
When playing sounds, you can individually control whether sounds will loop, and the volume of each individual instance of a sound. Controlling
global volume is simple, and is a top level property of the whole sound API. A simple example would be something like:
```cs
Sound.Volume = 0.5f; //half volume
```
All volumes within the tileEngine sound API range from `0.0f` to `1.0f`, completely silent to the default (full) volume of the sample. Setting values
above `1.0f` is permitted by the API, but not recommended as it may cause clipping and degrade audio quality.

To adjust volumes at runtime for sounds that are currently playing, you can reference the [`SoundInstance`](../api/tileEngine.SDK.Audio.SoundInstance.html) 
that is created when a sound is played when calling [`Sound.PlaySound`](../api/tileEngine.SDK.Audio.Sound.html#tileEngine_SDK_Audio_Sound_PlaySound_System_String_System_Boolean_).
This will allow you to dynamically alter the volume of samples as they are being played back, as well as switch looping for a currently playing
sample on and off.
```cs
SoundInstance playingSound = Sound.PlaySound("my/asset/path");
playingSound.Volume = 0.5f;

//...

playingSound.Volume = 1.0f;
playingSound.Looping = true;
```

You can also specify whether a sound should loop or not upon playing the sound, by passing this in as an optional second parameter. By default, sounds
do not loop, and will only play once before finishing.
```cs
SoundInstance loopingSound = Sound.PlaySound("my/asset/path", true); //this loops!
```

## Sound Cache
By default, all sounds upon load are cached until they are manually cleared within each platform's sound cache. This means that when you load a sound
`mysound.mp3` in one scene, and then load that sound again in another scene, it does not hit the filesystem again, and simply fetches the existing
sound reference from cache. However, there may be situations in which it is undesirable to continue caching sounds, especially when a large amount
of sounds have been loaded for a particular scene, and are not needed later on.

In this instance, you can manually clear the sound cache, and this is exposed through the `ClearSoundCache()` method of the [`Sound`](../api/tileEngine.SDK.Audio.Sound.html)
API. This can be called at any time, including when sounds in the cache are playing, and the entire cache will be flushed after calling.
```cs
//After this, the cache is immediately flushed.
Sound.ClearSoundCache();
```

There are some caveats with flushing the sound cache, however, namely that **all `SoundReference`s previously loaded will become invalid**. Take the
following instance for example, where a sound effect is loaded, the cache is flushed, and then the sound is attempted to be played:
```cs
var boomEffect = Sound.LoadSound("sounds/boom.wav");
Sound.ClearSoundCache();
Sound.PlaySound(boomEffect);
```

This will throw an exception, as when sounds are loaded and a reference is returned, that `SoundReference` is simply a reference to an item in the
platform's sound cache, and does not hold any data in itself.
```
[TE-1012] Error - Failed to play loaded sound from reference (ID 523237), this likely means you have cleared sound cache, but have attempted to use a stale sound reference.
```
In other words, when clearing sound cache, make sure to also invalidate any remaining sound references, as they will become stale and unplayable.