using Godot;
using System.Reflection;

namespace GodotEx.Extensions;

/// <summary>
/// GodotEx's global functions.
/// </summary>
public static class GDx {
    /// <summary>
    /// Instantiates node from packed scene using its path.
    /// </summary>
    /// <typeparam name="T">Node type.</typeparam>
    /// <param name="path">Packed scene path.</param>
    /// <returns>Instantiated node of type <typeparamref name="T"/>.</returns>
    public static T New<T>(string path) where T : Node {
        return GD.Load<PackedScene>(path).Instantiate<T>();
    }

    /// <summary>
    /// Instantiates node from packed scene using its path defined within the <see cref="ScenePathAttribute"/> .
    /// </summary>
    /// <typeparam name="T">Node type.</typeparam>
    /// <returns>Instantiated node of type <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidOperationException"><see cref="ScenePathAttribute"/>
    /// not defined for type <typeparamref name="T"/>.</exception>
    public static T New<T>() where T : Node {
        var type = typeof(T);
        var attribute = type.GetCustomAttribute<ScenePathAttribute>()
            ?? throw new InvalidOperationException($"ScenePath attribute not defined for {type.Name}.");
        return New<T>(attribute.Path);
    }
}
