using Godot;

namespace GodotEx.SoleNodes;

public static class SceneTreeExtensions {
    public static void AddSoleNode(this SceneTree tree, Node node) {
        var type = node.GetType();
        if (tree.HasGroup(type.Name)) {
            throw new InvalidOperationException($"Node of type {type.Name} already exists.");
        }
        node.AddToGroup(type.Name);
    }

    public static void RemoveSoleNode(this SceneTree tree, Node node) {
        var type = node.GetType();
        if (!tree.HasGroup(type.Name)) {
            throw new InvalidOperationException($"Node of type {type.Name} not found.");
        }
        node.RemoveFromGroup(type.Name);
    }

    public static Node? GetSoleNode(this SceneTree tree, Type type) {
        return tree.GetFirstNodeInGroup(type.Name);
    }

    public static TNode? GetSoleNode<TNode>(this SceneTree tree) where TNode : Node {
        return tree.GetSoleNode(typeof(TNode)) as TNode;
    }

    public static Node GetRequiredSoleNode(this SceneTree tree, Type type) {
        return tree.GetSoleNode(type)
            ?? throw new InvalidOperationException($"Node of type {type.Name} not found.");
    }

    public static TNode GetRequiredSoleNode<TNode>(this SceneTree tree) where TNode : Node {
        return tree.GetSoleNode<TNode>()
            ?? throw new InvalidOperationException($"Node of type {typeof(TNode).Name} not found.");
    }
}
