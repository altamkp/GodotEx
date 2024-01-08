using AutoMapper.Internal;
using Godot;
using GodotEx.Hosting;
using System.Reflection;

namespace GodotEx.DependencyInjection;

[Eager]
internal class NodeInjector : IDisposable {
    private readonly SceneTree _sceneTree;

    private Dictionary<Type, MemberInfo[]> _dependsOns = new();

    public NodeInjector(SceneTree sceneTree) {
        _sceneTree = sceneTree;
        _sceneTree.NodeAdded += Process;
    }

    public void Dispose() {
        _sceneTree.NodeAdded -= Process;
    }

    private void Process(Node node) {
        var type = node.GetType();

        if (!_dependsOns.TryGetValue(type, out var memberInfos)) {
            memberInfos = type
                .GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(mi => mi.IsDefined(typeof(InjectAttribute)))
                .ToArray();
            _dependsOns[type] = memberInfos;
        }

        foreach (var member in memberInfos) {
            var memberType = member.GetMemberType();
            var service = node.GetHost()?.GetService(memberType)
                ?? throw new InvalidOperationException($"Service of type {memberType} not found.");
            member.SetMemberValue(node, service);
        }
    }
}
