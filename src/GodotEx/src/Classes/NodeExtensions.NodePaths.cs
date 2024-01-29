using DotEx.Reflections;
using Godot;
using System.Reflection;

namespace GodotEx;

public static partial class NodeExtensions {
    private const string RESOLVED = "resolved";

    private static readonly Dictionary<Type, IEnumerable<NodePathInfo>> NODE_PATH_INFOS = new();

    /// <summary>
    /// Checks if the dependencies of <paramref name="node"/> labeled by 
    /// <see cref="NodePathAttribute"/> has been resolved. Note that nodes created
    /// by <see cref="GDx.New{T}(Action{T}?)"/> and its overload methods automatically resolves
    /// the node as soon as it is instantiated.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static bool IsResolved(this Node node) {
        return node.TryGetMeta(RESOLVED, out bool resolved) && resolved;
    }

    /// <summary>
    /// Resolve field and property node dependencies labeled by <see cref="NodePathAttribute"/>.
    /// See <see cref="NodePathAttribute"/> for more.
    /// </summary>
    /// <param name="node">Node to resolve.</param>
    /// <exception cref="InvalidOperationException">Dependency not assignable to member.</exception>
    public static void Resolve(this Node node) {
        const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        if (node.IsResolved()) {
            return;
        }

        var type = node.GetType();
        if (!NODE_PATH_INFOS.TryGetValue(type, out var dependencies)) {
            var fields = type.GetFieldsAndAttributes<NodePathAttribute>(FLAGS)
                .Select(f => new NodePathInfo(f.FieldInfo, f.Attributes));
            var properties = type.GetPropertiesAndAttributes<NodePathAttribute>(FLAGS)
                .Select(p => new NodePathInfo(p.PropertyInfo, p.Attributes));
            dependencies = fields.Concat(properties).ToArray();
            NODE_PATH_INFOS.Add(type, dependencies);
        }

        foreach (var (member, attributes) in dependencies) {
            ResolveDependency(member, attributes);
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

    private class NodePathInfo {
        public NodePathInfo(MemberInfo memberInfo, IEnumerable<NodePathAttribute> attributes) {
            MemberInfo = memberInfo;
            Attributes = attributes;
        }

        public MemberInfo MemberInfo { get; }
        public IEnumerable<NodePathAttribute> Attributes { get; }

        public void Deconstruct(out MemberInfo memberInfo, out IEnumerable<NodePathAttribute> attributes) {
            memberInfo = MemberInfo;
            attributes = Attributes;
        }
    }
}
