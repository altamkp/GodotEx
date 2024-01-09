using Godot;

namespace GodotEx.Extensions;

public static class SceneTreeExtensions {
    /// <summary>
    /// Returns a <see cref="SignalAwaiter"/> that awaits the completion of the current process frame.
    /// </summary>
    /// <param name="tree">Scene tree to await.</param>
    /// <returns>A Godot signal awaiter that awaits the process frame.</returns>
    public static SignalAwaiter ProcessFrameAsync(this SceneTree tree) {
        return tree.ToSignal(tree, SceneTree.SignalName.ProcessFrame);
    }

    /// <summary>
    /// Returns a <see cref="SignalAwaiter"/> that awaits the completion of the current physics frame.
    /// </summary>
    /// <param name="tree">Scene tree to await.</param>
    /// <returns>A Godot signal awaiter that awaits the physics frame.</returns>
    public static SignalAwaiter PhysicsFrameAsync(this SceneTree tree) {
        return tree.ToSignal(tree, SceneTree.SignalName.PhysicsFrame);
    }
}
