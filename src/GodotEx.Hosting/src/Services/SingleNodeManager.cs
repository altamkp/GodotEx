using DotnetEx.Reflections;
using Godot;

namespace GodotEx.Hosting;

/// <summary>
/// Manager class that adds/removes nodes labeled with <see cref="SingleNodeAttribute"/> 
/// to/from the scene tree as single nodes as they are added to/removed from the tree.
/// Configured as singleton service in <see cref="Host"/>.
/// </summary>
[Eager]
internal class SingleNodeManager : IDisposable {
    private readonly SceneTree _tree;

    public SingleNodeManager(SceneTree tree) {
        _tree = tree;
        _tree.NodeAdded += OnNodeAdded;
        _tree.NodeRemoved += OnNodeRemoved;
    }

    public void Dispose() {
        _tree.NodeAdded -= OnNodeAdded;
        _tree.NodeRemoved -= OnNodeRemoved;
    }

    private void OnNodeAdded(Node node) {
        if (node.GetType().IsDefined<SingleNodeAttribute>()) {
            _tree.AddSingleNode(node);
        }
    }

    private void OnNodeRemoved(Node node) {
        if (node.GetType().IsDefined<SingleNodeAttribute>()) {
            _tree.RemoveSingleNode(node);
        }
    }
}
