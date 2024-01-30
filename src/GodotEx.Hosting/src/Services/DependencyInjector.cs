using DotEx.Reflections;
using Godot;
using System.Reflection;

namespace GodotEx.Hosting;

[Eager]
internal class DependencyInjector : IDisposable {
    private const BindingFlags BINDING_FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    private readonly SceneTree _sceneTree;

    private readonly Dictionary<Type, MemberInfo[]> _members = new();

    public DependencyInjector(SceneTree sceneTree) {
        _sceneTree = sceneTree;
        _sceneTree.NodeAdded += Inject;
    }

    public void Dispose() {
        _sceneTree.NodeAdded -= Inject;
    }

    private void Inject(Node node) {
        var type = node.GetType();

        if (!_members.TryGetValue(type, out var members)) {
            var properties = type.GetPropertiesWithAttribute(InjectAttribute.TYPE, BINDING_FLAGS);
            var fields = type.GetFieldsWithAttribute(InjectAttribute.TYPE, BINDING_FLAGS);
            members = properties.Cast<MemberInfo>().Concat(fields).ToArray();
            _members[type] = members;
        }

        foreach (var member in members) {
            var memberType = member.GetMemberType();
            var service = node.GetHost()?.GetService(memberType)
                ?? throw new InvalidOperationException($"Service of type {memberType} not found.");
            member.SetValue(node, service);
        }
    }
}
