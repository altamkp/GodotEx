using Godot;

namespace GodotEx.Async;

/// <summary>
/// Extensions for <see cref="Node"/>.
/// </summary>
public static class NodeExtensions {
    /// <summary>
    /// Asynchronously queue frees <paramref name="node"/>.
    /// </summary>
    /// <param name="node">Node to queue free.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task QueueFreeAsync(this Node node) {
        var tcs = new TaskCompletionSource();
        node.TreeExited += OnExited;
        node.QueueFree();
        return tcs.Task;

        void OnExited() {
            node.TreeExited -= OnExited;
            tcs.SetResult();
        }
    }

    /// <summary>
    /// Asynchronously queue frees all children of <paramref name="node"/>.
    /// </summary>
    /// <param name="node">Node of which children to queue free.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task QueueFreeChildrenAsync(this Node node) {
        var count = node.GetChildCount();
        var tasks = new Task[count];
        for (int i = count - 1; i >= 0; i--) {
            tasks[i] = node.GetChild(i).QueueFreeAsync();
        }
        return Task.WhenAll(tasks);
    }
}
