namespace GodotEx.Extensions;

/// <summary>
/// Attribute that is recognized by <see cref="NodePathResolver"/> to resolve field or
/// property node dependencies. A path can be specified, otherwise the resolver uses
/// the trimmed pascal case version of the name of the field/property to first look for a node
/// directly under the currently node, otherwise use the '%' unique node prefix to look for the 
/// node if the first approach yield no result.
/// Use with <see cref="GodotEx.Hosting.Host"/> is recommended.
/// </summary>
/// <remarks>
/// <b>Example 1</b>:
/// <br/>
/// [NodePath] private Node _node;
/// <br/>
/// [NodePath] public Node Node { get; set; }
/// <br/>
/// <br/>
/// If path is not satisfied, <see cref="NodePathResolver"/> first looks for the node located 
/// directly under the current node with the name "Node", otherwise looks for the unique node
/// with "%Node".
/// <br/>
/// <b>Example 2</b>:
/// <br/>
/// [NodePath("Node1/Node2")] private Node _node;
/// <br/>
/// [NodePath("Node3/Node4")] public Node Node { get; set; }
/// <br/>
/// <br/>
/// If path is satisfied, <see cref="NodePathResolver"/> looks for the node located at the path
/// relative to the current node.
/// </remarks>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class NodePathAttribute : Attribute {
    public NodePathAttribute(string? path = null) {
        Path = path;
    }

    public string? Path { get; }
}
