# Asynchronous Extensions

GodotEx asynchronous extensions are a set of asynchronous extension methods for Godot built-in classes such as [SceneTree](https://docs.godotengine.org/en/stable/classes/class_scenetree.html), [Timer](https://docs.godotengine.org/en/stable/classes/class_timer.html) and [Tween](https://docs.godotengine.org/en/stable/classes/class_tween.html).They are available through the `GodotEx.Async` package. 

Please refer to the [GodotEx.Async Api](~/api/GodotEx.Async.yml) for all available asynchronous extensions.

Godot allows awaiting object signals with [ToSignal()](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_signals.html#signals-as-c-events). Some common uses include:

```csharp
await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
await ToSignal(timer, Timer.SignalName.Timeout);
```

With the extensions, you can write:

```csharp
await GetTree().ProcessFrameAsync();
await timer.TimeoutAsync();
```

Some special types like `Tween` also provides asynchronous methods like `tween.TweenPropertyAsync(...)` and `tween.TweenMethodAsync(...)` which have the exact signatures as the original synchronous methods.
