using Godot;

namespace GodotEx;

public static class SceneTreeExtensions {
    public static void AddUniqueNode<TNode>(this SceneTree tree, TNode node) where TNode : Node {
        var type = typeof(TNode);
        if (tree.HasGroup(type.Name)) {
            throw new InvalidOperationException($"Node of type {type.Name} already exists.");
        }
        node.AddToGroup(type.Name);
    }

    public static void RemoveUniqueNode<TNode>(this SceneTree tree, TNode node) where TNode : Node {
        var type = typeof(TNode);
        if (!tree.HasGroup(type.Name)) {
            throw new InvalidOperationException($"Node of type {type.Name} not found.");
        }
        node.RemoveFromGroup(type.Name);
    }

    public static Node? GetUniqueNode(this SceneTree tree, Type type) {
        return tree.GetFirstNodeInGroup(type.Name);
    }

    public static TNode? GetUniqueNode<TNode>(this SceneTree tree) where TNode : Node {
        return tree.GetUniqueNode(typeof(TNode)) as TNode;
    }

    public static Node GetRequiredUniqueNode(this SceneTree tree, Type type) {
        return tree.GetUniqueNode(type)
            ?? throw new InvalidOperationException($"Node of type {type.Name} not found.");
    }

    public static TNode GetRequiredUniqueNode<TNode>(this SceneTree tree) where TNode : Node {
        return tree.GetUniqueNode<TNode>()
            ?? throw new InvalidOperationException($"Node of type {typeof(TNode).Name} not found.");
    }
}
