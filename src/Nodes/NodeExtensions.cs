using Godot;

namespace GodotEx;

public static partial class NodeExtensions {
    public static IEnumerable<T> GetChildren<T>(this Node node) {
        var nodeCount = node.GetChildCount();
        for (int i = 0; i < nodeCount; i++) {
            var child = node.GetChild<Node>(i);
            if (child is T t) {
                yield return t;
            }
        }
    }

    public static IEnumerable<T> GetAllChildren<T>(this Node node) {
        var nodeCount = node.GetChildCount();
        for (int i = 0; i < nodeCount; i++) {
            var child = node.GetChild<Node>(i);
            if (child is T t) {
                yield return t;
            }
            foreach (var childOfChild in child.GetAllChildren<T>()) {
                yield return childOfChild;
            }
        }
    }

    public static void FreeAllChildren(this Node node) {
        var childCount = node.GetChildCount();
        for (int i = childCount - 1; i >= 0; i--) {
            node.GetChild(i).Free();
        }
    }

    public static void QueueFreeAllChildren(this Node node) {
        var childCount = node.GetChildCount();
        for (int i = childCount - 1; i >= 0; i--) {
            node.GetChild(i).QueueFree();
        }
    }
}
