using Godot;
using System.Reflection;

namespace GodotEx.Hosting;

/// <summary>
/// Resolver for node property and field dependencies labeled by <see cref="NodePathAttribute"/>.
/// Configured as singleton service in <see cref="Host"/>.
/// </summary>
[Eager]
internal class NodePathResolver : IDisposable {
    private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    private readonly SceneTree _tree;

    public NodePathResolver(SceneTree tree) {
        _tree = tree;
        _tree.NodeAdded += NodeExtensions.Resolve;
    }

    public void Dispose() {
        _tree.NodeAdded -= NodeExtensions.Resolve;
    }
}
