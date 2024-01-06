using Godot;

namespace GodotEx.Hosting;

public static class NodeExtensions {
    public static HostBase? GetHost(this Node node) {
        var current = node;
        while (current != null) {
            if (current is HostBase host) {
                return host;
            }
            current = current.GetParent();
        }

        var hosts = node.GetTree()
            .Root
            .GetChildren()
            .Where(n => n is HostBase);
        try {
            return hosts.SingleOrDefault() as HostBase;
        } catch (InvalidOperationException) {
            throw new InvalidOperationException("Multiple autoload hosts discovered.");
        }
    }
}
