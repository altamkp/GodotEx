using DotnetEx.Reflections;
using Godot;
using System.Reflection;

namespace GodotEx;

public static partial class NodeExtensions {
    private const string RESOLVED = "resolved";

    /// <summary>
    /// Checks if the dependencies of <paramref name="node"/> labeled by 
    /// <see cref="NodePathAttribute"/> has been resolved. Note that nodes created
    /// by <see cref="GDx.New{T}()"/> and its overload methods automatically resolves
    /// the node as soon as it is instantiated.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static bool IsResolved(this Node node) {
        return node.HasMeta(RESOLVED) && node.GetMeta(RESOLVED).AsBool();
    }

    /// <summary>
    /// Resolve field and property node dependencies labeled by <see cref="NodePathAttribute"/>.
    /// See <see cref="NodePathAttribute"/> for more.
    /// </summary>
    /// <param name="node">Node to resolve.</param>
    /// <exception cref="InvalidOperationException">Dependency not assignable to member.</exception>
    public static void Resolve(this Node node) {
        if (node.IsResolved()) {
            return;
        }

        var type = node.GetType();
        var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        var fields = type.GetFieldsAndAttributes<NodePathAttribute>(flags);
        var properties = type.GetPropertiesAndAttributes<NodePathAttribute>(flags);
        foreach (var (property, attributes) in properties) {
            ResolveDependency(property, attributes);
        }
        foreach (var (field, attributes) in fields) {
            ResolveDependency(field, attributes);
        }
        node.SetMeta(RESOLVED, true);

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
