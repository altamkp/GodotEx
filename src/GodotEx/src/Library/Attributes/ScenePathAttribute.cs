using System.Runtime.CompilerServices;

namespace GodotEx;

/// <summary>
/// Attribute that is recognized by <see cref="GDx.New{T}(Action{T}?)"/> to instantiate custom 
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
    private readonly string _scriptPath;
    private string? _scenePath;

    /// <summary>
    /// Creates a new <see cref="ScenePathAttribute"/> used with <see cref="GDx.New{T}(Action{T}?)"/>
    /// and similar overloads to instantiate scenes.
    /// </summary>
    /// <param name="scenePath">Scene path.</param>
    /// <param name="scriptPath">Script path.</param>
    /// <exception cref="InvalidOperationException">Scene file not found.</exception>
    public ScenePathAttribute(string? scenePath = null, [CallerFilePath] string scriptPath = "") {
        _scenePath = scenePath;
        _scriptPath = scriptPath;
    }

    /// <summary>
    /// File path of the scene with the annotated script attached.
    /// </summary>
    public string Path {
        get {
            _scenePath ??= BuildScenePath();
            return _scenePath;
        }
    }

    private string BuildScenePath() {
        const string COMPILE_ROOT = "compileRoot";

        var compileRoot = GDx.Config?[COMPILE_ROOT]
            ?? throw new InvalidOperationException($"'compileRoot' not provided in config.json.");

        int index;
        for (index = 0; index < compileRoot.Length; index++) {
            if (_scriptPath[index] != compileRoot[index]) {
                throw new InvalidOperationException($"Script path root {_scriptPath} does not match compile root {compileRoot}.");
            }
        }

        return $"res://{_scriptPath[(index + 1)..^3]}.tscn";
    }
}
