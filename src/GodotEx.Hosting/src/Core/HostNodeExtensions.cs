using Godot;
using GodotEx;

namespace GodotEx.Hosting;

/// <summary>
/// Extensions for <see cref="Node"/> related to <see cref="Host"/>.
/// </summary>
public static class HostNodeExtensions {
    /// <summary>
    /// Returns the <see cref="Host"/> of the <paramref name="node"/>.
    /// </summary>
    /// <param name="node">Node of which to get host from.</param>
    /// <returns>Host object of the node.</returns>
    /// <exception cref="InvalidOperationException">Multiple autoload hosts discovered.</exception>
    public static Host? GetHost(this Node node) {
        var current = node;
        while (current != null) {
            if (current is Host host) {
                return host;
            }
            current = current.GetParent();
        }

        var hosts = node.GetTree().Root.GetChildren<Host>();
        var count = hosts.Count();
        if (count > 1) {
            throw new InvalidOperationException("Multiple autoload hosts discovered.");
        }
        return hosts.SingleOrDefault();
    }
}
