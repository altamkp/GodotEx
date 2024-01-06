using DotnetEx.Reflections;
using Godot;
using GodotEx.Hosting;

namespace GodotEx.SoleNodes;

[Eager]
public class SoleNodeManager {
    public SoleNodeManager(SceneTree tree) {
        tree.NodeAdded += OnNodeAdded;
        tree.NodeRemoved += OnNodeRemoved;

        void OnNodeAdded(Node node) {
            if (node.GetType().IsDefined<SoleAttribute>()) {
                tree.AddSoleNode(node);
            }
        }

        void OnNodeRemoved(Node node) {
            if (node.GetType().IsDefined<SoleAttribute>()) {
                tree.RemoveSoleNode(node);
            }
        }
    }
}
