using DotnetEx.Reflections;
using Godot;
using System.Diagnostics;
using System.Reflection;

namespace GodotEx.Extensions.Tests;

public partial class NodePathResolverTest : Node {
    [NodePath] 
    private Label _label;
    
    [NodePath("Label/AudioStreamPlayer2D")] 
    private AudioStreamPlayer2D _player;

    [NodePath]
    private Node _canvasLayer;

    [NodePath] public Label Label { get; set; }

    public override void _Ready() {
        NodePathResolver.Resolve(this);

        var type = GetType();
        var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        foreach (var property in type.GetPropertiesWithAttribute<NodePathAttribute>(flags)) {
            Debug.Assert(property.GetValue(this) != null);
        }
        foreach (var field in type.GetFieldsWithAttribute<NodePathAttribute>(flags)) {
            Debug.Assert(field.GetValue(this) != null);
        }
    }
}
