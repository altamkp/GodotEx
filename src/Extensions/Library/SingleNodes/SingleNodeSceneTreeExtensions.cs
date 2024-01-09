using Godot;

namespace GodotEx.Extensions;

public static class SingleNodeSceneTreeExtensions {
    /// <summary>
    /// Adds <paramref name="node"/> to the scene tree as single node.
    /// </summary>
    /// <param name="tree">Scene tree where the node is added.</param>
    /// <param name="node">Node to add.</param>
    /// <exception cref="InvalidOperationException">Node with the same type already exists.</exception>
    public static void AddSingleNode(this SceneTree tree, Node node) {
        var type = node.GetType();
        if (tree.HasGroup(type.Name)) {
            throw new InvalidOperationException($"Node of type {type.Name} already exists.");
        }
        node.AddToGroup(type.Name);
    }

    /// <summary>
    /// Removes <paramref name="node"/> from the scene tree as single node.
    /// </summary>
    /// <param name="tree">Scene tree where the node is removed.</param>
    /// <param name="node">Node to remove.</param>
    /// <exception cref="InvalidOperationException">Node with the same type not found.</exception>
    public static void RemoveSingleNode(this SceneTree tree, Node node) {
        var type = node.GetType();
        if (!tree.HasGroup(type.Name)) {
            throw new InvalidOperationException($"Node of type {type.Name} not found.");
        }
        node.RemoveFromGroup(type.Name);
    }

    /// <summary>
    /// Returns single node of type <paramref name="type"/>.
    /// </summary>
    /// <param name="tree">Scene tree to search from.</param>
    /// <param name="type">Type to match.</param>
    /// <returns>Node of <paramref name="type"/>, null if not found.</returns>
    public static Node? GetSingleNode(this SceneTree tree, Type type) {
        return tree.GetFirstNodeInGroup(type.Name);
    }

    /// <summary>
    /// Returns single node of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type to match.</typeparam>
    /// <param name="tree">Scene tree to search from.</param>
    /// <returns>Node of type <typeparamref name="T"/>, null if not found.</returns>
    public static T? GetSingleNode<T>(this SceneTree tree) where T : Node {
        return tree.GetSingleNode(typeof(T)) as T;
    }

    /// <summary>
    /// Returns single node of type <paramref name="type"/>.
    /// </summary>
    /// <param name="tree">Scene tree to search from.</param>
    /// <param name="type">Type to match.</param>
    /// <returns>Node of <paramref name="type"/>.</returns>
    /// <exception cref="InvalidOperationException">Node of <paramref name="type"/> not found.</exception>
    public static Node GetRequiredSingleNode(this SceneTree tree, Type type) {
        return tree.GetSingleNode(type)
            ?? throw new InvalidOperationException($"Node of type {type.Name} not found.");
    }

    /// <summary>
    /// Returns single node of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type to match.</typeparam>
    /// <param name="tree">Scene tree to search from.</param>
    /// <returns>Node of type <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidOperationException">Node of type <typeparamref name="T"/> not found.</exception>
    public static T GetRequiredSingleNode<T>(this SceneTree tree) where T : Node {
        return tree.GetSingleNode<T>()
            ?? throw new InvalidOperationException($"Node of type {typeof(T).Name} not found.");
    }
}
