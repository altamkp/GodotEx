using DotnetEx.Reflections;
using Godot;
using GodotEx.Hosting;
using System.Reflection;

namespace GodotEx.Extensions;

/// <summary>
/// Resolver for node dependencies, both fields and properties, labeled by <see cref="NodePathAttribute"/>.
/// Configured as singleton service in <see cref="GodotEx.Hosting.Host"/>.
/// </summary>
[Eager]
public class NodePathResolver : IDisposable {
    private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    private readonly SceneTree _tree;

    public NodePathResolver(SceneTree tree) {
        _tree = tree;
        _tree.NodeAdded += Resolve;
    }

    public void Dispose() {
        _tree.NodeAdded -= Resolve;
    }

    /// <summary>
    /// Resolve field and property node dependencies labeled by <see cref="NodePathAttribute"/>.
    /// See <see cref="NodePathAttribute"/> for more.
    /// </summary>
    /// <param name="node">Node to resolve.</param>
    /// <exception cref="InvalidOperationException">Dependency not assignable to member.</exception>
    public static void Resolve(Node node) {
        var type = node.GetType();

        var properties = type.GetPropertiesAndAttributes<NodePathAttribute>(FLAGS);
        foreach (var (property, attributes) in properties) {
            ResolveDependency(property, attributes);
        }

        var fields = type.GetFieldsAndAttributes<NodePathAttribute>(FLAGS);
        foreach (var (field, attributes) in fields) {
            ResolveDependency(field, attributes);
        }

        void ResolveDependency(MemberInfo member, IEnumerable<NodePathAttribute> attributes) {
            var path = attributes.Single().Path;
            Node dependency;
            if (path != null) {
                dependency = node.GetNode(path);
            } else {
                var name = member.Name.TrimStart('_').ToPascalCase();
                dependency = node.GetNodeOrNull(name) ?? node.GetNode($"%{name}");
            }

            var dependencyType = dependency.GetType();
            var memberType = member.GetMemberType();
            if (!dependencyType.IsAssignableTo(memberType)) {
                throw new InvalidOperationException($"Dependency of type {dependencyType} is not assignable to {memberType}.");
            }
            member.SetValue(node, dependency);
        }
    }
}
