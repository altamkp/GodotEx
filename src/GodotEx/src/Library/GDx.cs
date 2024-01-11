using Godot;
using System.Reflection;

namespace GodotEx;

/// <summary>
/// GodotEx's global functions.
/// </summary>
public static class GDx {
    /// <summary>
    /// Instantiates node from packed scene using its <paramref name="path"/>.
    /// Nodes are automatically resolved using this method, see <see cref="NodeExtensions.Resolve(Node)"/>.
    /// </summary>
    /// <param name="path">Packed scene path.</param>
    /// <returns>Instantiated node.</returns>
    public static Node New(string path) {
        var node = GD.Load<PackedScene>(path).Instantiate();
        node.Resolve();
        return node;
    }

    /// <summary>
    /// Instantiates node from packed scene using its <paramref name="path"/>.
    /// Nodes are automatically resolved using this method, see <see cref="NodeExtensions.Resolve(Node)"/>.
    /// </summary>
    /// <typeparam name="T">Node type.</typeparam>
    /// <param name="path">Packed scene path.</param>
    /// <returns>Instantiated node of type <typeparamref name="T"/>.</returns>
    public static T New<T>(string path) where T : Node {
        var node = GD.Load<PackedScene>(path).Instantiate<T>();
        node.Resolve();
        return node;
    }

    /// <summary>
    /// Instantiates node from packed scene by matching a tscn file with the same name 
    /// under the same folder as the script defining the target node, or using the path 
    /// if it is provided. See <see cref="ScenePathAttribute"/>.
    /// Nodes are automatically resolved using this method, see <see cref="NodeExtensions.Resolve(Node)"/>.
    /// </summary>
    /// <param name="type">Node type.</param>
    /// <returns>Instantiated node of type <paramref name="type"/>.</returns>
    /// <exception cref="InvalidOperationException"><see cref="ScenePathAttribute"/>
    /// not defined for type <paramref name="type"/>.</exception>
    public static Node New(Type type) {
        var attribute = type.GetCustomAttribute<ScenePathAttribute>()
            ?? throw new InvalidOperationException($"ScenePath attribute not defined for {type.Name}.");
        var node = GD.Load<PackedScene>(attribute.Path).Instantiate();
        node.Resolve();
        return node;
    }

    /// <summary>
    /// Instantiates node from packed scene by matching a tscn file with the same name 
    /// under the same folder as the script defining the target node, or using the path 
    /// if it is provided. See <see cref="ScenePathAttribute"/>.
    /// Nodes are automatically resolved using this method, see <see cref="NodeExtensions.Resolve(Node)"/>.
    /// </summary>
    /// <typeparam name="T">Node type.</typeparam>
    /// <returns>Instantiated node of type <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidOperationException"><see cref="ScenePathAttribute"/>
    /// not defined for type <typeparamref name="T"/>.</exception>
    public static T New<T>() where T : Node {
        var type = typeof(T);
        var attribute = type.GetCustomAttribute<ScenePathAttribute>()
            ?? throw new InvalidOperationException($"ScenePath attribute not defined for {type.Name}.");
        var node = GD.Load<PackedScene>(attribute.Path).Instantiate<T>();
        node.Resolve();
        return node;
    }
}
