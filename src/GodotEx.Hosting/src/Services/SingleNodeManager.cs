using DotEx.Reflections;
using Godot;

namespace GodotEx.Hosting;

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
            _tree.AddSingle(node);
        }
    }

    private void OnNodeRemoved(Node node) {
        if (node.GetType().IsDefined<SingleNodeAttribute>()) {
            _tree.RemoveSingle(node);
        }
    }
}
