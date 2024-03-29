# GodotEx.Async

Asynchronous extension library for Godot:

- Awaitables for common Godot object signals such as [Timer.Timeout](https://docs.godotengine.org/en/stable/classes/class_timer.html#:~:text=%C2%B6-,timeout) and [SceneTree.ProcessFrame](https://docs.godotengine.org/en/stable/classes/class_scenetree.html#:~:text=the%20SceneTree.-,process_frame)
- `CancellableSignalAwaiter` that wraps the Godot [SignalAwaiter](https://github.com/godotengine/godot/blob/master/modules/mono/glue/GodotSharp/GodotSharp/Core/SignalAwaiter.cs), provides functionality similar to that of [ToSignal()](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_signals.html#signals-as-c-events) while also accepting a [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-8.0)

## Prerequisites

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download)+
- [Godot Engine - .NET 4.0](https://godotengine.org/)+

## Installation

Install the `GodotEx.Async` nuget package with the following command:

```
dotnet add package GodotEx.Async
```
