using Godot;
using System.Runtime.CompilerServices;

namespace GodotEx.Extensions;

/// <summary>
/// Attribute that is recognized by <see cref="GDx.New{T}()"/> to instantiate custom 
/// node type labeled with this attribute by matching a tscn file with the same name 
/// under the same folder as the current script, or using the path if it is provided.
/// </summary>
/// <remarks>
/// <b>Example 1</b>: 
/// <br/>
/// [ScenePath]
/// <br/>
/// public class CustomLabel : Label { }
/// <br/>
/// <br/>
/// By using the default path, the attribute looks for a tscn file
/// with the same name and under the same folder as the current script. For example, if
/// CustomLabel.cs is located at res://src/UI/CustomLabel.cs, then it looks for
/// res://src/UI/CustomLabel.tscn to instantiate.
/// <br/>
/// <br/>
/// <b>Example 2</b>: 
/// <br/>
/// [ScenePath("res://src/UI/CustomImage.tscn")]
/// <br/>
/// public class CustomImage : TextureRect { }
/// <br/>
/// <br/>
/// By providing a path, the attribute looks for the tscn file at the given path. 
/// </remarks>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ScenePathAttribute : Attribute {
    private const string TSCN = ".tscn";

    public ScenePathAttribute(string? path = null, [CallerFilePath] string scriptPath = "") {
        if (path == null) {
            scriptPath = ProjectSettings.LocalizePath(scriptPath);
            Path = System.IO.Path.ChangeExtension(scriptPath, TSCN);
        } else {
            Path = path;
        }

        if (!Godot.FileAccess.FileExists(Path)) {
            throw new InvalidOperationException($"{Path} not found.");
        }
    }

    public string Path { get; }
}
