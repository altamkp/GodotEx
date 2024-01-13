# GodotEx

**Godot** **Ex**tra provides a set of extension libraries for Godot in C#.

Currently available extension libraries:

- [GodotEx](https://altamkp.github.io/GodotEx/docs/GodotEx/BasicExtensions.html)

  Basic extension library for Godot including:

  - Extension methods for Godot classes such as [InputEvent](https://docs.godotengine.org/en/stable/classes/class_inputevent.html), [Node](https://docs.godotengine.org/en/stable/classes/class_node.html), [Transform3D](https://docs.godotengine.org/en/stable/classes/class_transform3d.html), etc. 
  - Utilities for input management, raycast, node path resolving, etc.

- [GodotEx.Async](https://altamkp.github.io/GodotEx/docs/GodotEx.Async/AsynchronousExtensions.html)

  Asynchronous library for Godot including:

  - `CancellableSignalAwaiter` that wraps the Godot [`SignalAwaiter`](https://github.com/godotengine/godot/blob/master/modules/mono/glue/GodotSharp/GodotSharp/Core/SignalAwaiter.cs), provides functionality similar to that of [`GodotObject.ToSignal(GodotObject source, StringName signal)`](https://github.com/godotengine/godot/blob/master/modules/mono/glue/GodotSharp/GodotSharp/Core/GodotObject.base.cs#L175) while also accepting a [`CancellationToken`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-8.0)
  - Awaitables for common Godot object signals such as [`Timer.Timeout`](https://docs.godotengine.org/en/stable/classes/class_timer.html#:~:text=%C2%B6-,timeout) and [`SceneTree.ProcessFrame`](https://docs.godotengine.org/en/stable/classes/class_scenetree.html#:~:text=the%20SceneTree.-,process_frame)

- [GodotEx.Hosting](https://altamkp.github.io/GodotEx/docs/GodotEx.Hosting/Hosting.html)

  Hosting library for Godot including:

  - A `Host` node that provides hosting functionalities with [`ServiceProvider`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.serviceprovider?view=dotnet-plat-ext-8.0)
  - Dependency injection through the above `Host`

## Documentation

Please refer to [this page](https://altamkp.github.io/GodotEx) for a detailed documentation on all available extension libraries.

## License

Available under the [MIT License](LICENSE.md).

## Copyright

Copyright (c) 2024 [altamkp](https://github.com/altamkp)
