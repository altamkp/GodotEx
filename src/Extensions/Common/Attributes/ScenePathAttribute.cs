namespace GodotEx.Extensions;

/// <summary>
/// Attribute that is recognized by <see cref="GDx.New{T}()"/>, instantiate node
/// of the labeled type by using the provided scene path.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ScenePathAttribute : Attribute {
    public ScenePathAttribute(string path) {
        Path = path;
    }

    public string Path { get; }
}
