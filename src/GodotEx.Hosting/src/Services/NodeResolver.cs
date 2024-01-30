using Godot;

namespace GodotEx.Hosting;

[Eager]
internal class NodeResolver : IDisposable {
    private readonly SceneTree _tree;

    public NodeResolver(SceneTree tree) {
        _tree = tree;
        _tree.NodeAdded += NodeExtensions.Resolve;
    }

    public void Dispose() {
        _tree.NodeAdded -= NodeExtensions.Resolve;
    }
}
