using Godot;
using System.Reflection;

namespace GodotEx;

/// <summary>
/// Extensions for <see cref="Node"/>.
/// </summary>
public static partial class NodeExtensions {
    /// <summary>
    /// Returns all children of type <typeparamref name="T"/> under <paramref name="node"/>.
    /// </summary>
    /// <typeparam name="T">Target type.</typeparam>
    /// <param name="node">Node to search.</param>
    /// <returns>All children matching <typeparamref name="T"/>.</returns>
    public static IEnumerable<T> GetChildren<T>(this Node node) where T : Node {
        foreach (var child in node.GetChildren()) {
            if (child is T t) {
                yield return t;
            }
        }
    }

    /// <summary>
    /// Returns all children and grandchildren of type <typeparamref name="T"/> under <paramref name="node"/>.
    /// </summary>
    /// <typeparam name="T">Target type.</typeparam>
    /// <param name="node">Node to search.</param>
    /// <returns>All children and grandchildren matching <typeparamref name="T"/>.</returns>
    public static IEnumerable<T> GetAllChildren<T>(this Node node) where T : Node {
        foreach (var child in node.GetChildren()) {
            if (child is T t) {
                yield return t;
            }
            foreach (var grandchild in child.GetAllChildren<T>()) {
                yield return grandchild;
            }
        }
    }

    /// <summary>
    /// Returns ancestor of type <typeparamref name="T"/> of the <paramref name="node"/>, null if not found.
    /// </summary>
    /// <typeparam name="T">Target type.</typeparam>
    /// <param name="node">Node to search.</param>
    /// <returns>Ancestor node of type <typeparamref name="T"/>, null if not found.</returns>
    public static T? GetAncestor<T>(this Node node) where T : Node {
        var parent = node.GetParent();
        while (parent != null && parent is not T) {
            parent = parent.GetParent();
        }
        return parent as T;
    }

    /// <summary>
    /// Frees all children under <paramref name="node"/>.
    /// </summary>
    /// <param name="node">Node of which children to free.</param>
    public static void FreeChildren(this Node node) {
        var count = node.GetChildCount();
        for (int i = count - 1; i >= 0; i--) {
            node.GetChild(i).Free();
        }
    }

    /// <summary>
    /// Queue frees all children under <paramref name="node"/>.
    /// </summary>
    /// <param name="node">Node of which children to queue free.</param>
    public static void QueueFreeChildren(this Node node) {
        var count = node.GetChildCount();
        for (int i = count - 1; i >= 0; i--) {
            node.GetChild(i).QueueFree();
        }
    }

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
