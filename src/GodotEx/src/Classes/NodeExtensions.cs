using Godot;

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
    /// Returns all descendants of type <typeparamref name="T"/> under <paramref name="node"/> recursively.
    /// </summary>
    /// <typeparam name="T">Target type.</typeparam>
    /// <param name="node">Node to search.</param>
    /// <returns>All descendants matching <typeparamref name="T"/>.</returns>
    public static IEnumerable<T> GetDescendants<T>(this Node node) where T : Node {
        foreach (var child in node.GetChildren<T>()) {
            yield return child;
            
            foreach (var descendant in child.GetDescendants<T>()) {
                yield return descendant;
            }
        }
    }

    /// <summary>
    /// Returns closest ancestor of type <typeparamref name="T"/> of the <paramref name="node"/>, null if not found.
    /// </summary>
    /// <typeparam name="T">Target type.</typeparam>
    /// <param name="node">Node to search.</param>
    /// <returns>Closest ancestor of type <typeparamref name="T"/>, null if not found.</returns>
    public static T? GetClosestAncestor<T>(this Node node) where T : Node {
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
}
