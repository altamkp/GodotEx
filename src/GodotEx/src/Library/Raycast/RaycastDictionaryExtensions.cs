using Godot;

namespace GodotEx;

public static class RaycastDictionaryExtensions {
    /// <summary>
    /// Converts and encapsulates the result dictionary obtained with
    /// <see cref="PhysicsDirectSpaceState3D.IntersectRay(PhysicsRayQueryParameters3D)"/>
    /// into <see cref="RaycastHit"/>.
    /// </summary>
    /// <param name="dictionary">Result dictionary from 
    /// <see cref="PhysicsDirectSpaceState3D.IntersectRay(PhysicsRayQueryParameters3D)"/>.</param>
    /// <returns>The converted RaycastHit struct that represents the result dictionary.</returns>
    /// <exception cref="ArgumentException">Dictionary does not contain one or more keys that 
    /// represent raycast result, see https://docs.godotengine.org/en/stable/classes/class_physicsdirectspacestate3d.html#:~:text=Dictionary%20intersect_ray%20(,is%20returned%20instead.</exception>
    public static RaycastHit? ToRaycastHit(this Godot.Collections.Dictionary dictionary) {
        if (dictionary.Count == 0) {
            return null;
        }

        if (!dictionary.TryGetValue(RaycastKeys.POSITION, out var position)) {
            throw new ArgumentException($"Raycast dictionary should contain the key {RaycastKeys.POSITION}");
        }
        if (!dictionary.TryGetValue(RaycastKeys.NORMAL, out var normal)) {
            throw new ArgumentException($"Raycast dictionary should contain the key {RaycastKeys.NORMAL}");
        }
        if (!dictionary.TryGetValue(RaycastKeys.COLLIDER, out var collider)) {
            throw new ArgumentException($"Raycast dictionary should contain the key {RaycastKeys.COLLIDER}");
        }
        if (!dictionary.TryGetValue(RaycastKeys.COLLIDER_ID, out var colliderId)) {
            throw new ArgumentException($"Raycast dictionary should contain the key {RaycastKeys.COLLIDER_ID}");
        }
        if (!dictionary.TryGetValue(RaycastKeys.RID, out var rid)) {
            throw new ArgumentException($"Raycast dictionary should contain the key {RaycastKeys.RID}");
        }
        if (!dictionary.TryGetValue(RaycastKeys.SHAPE, out var shape)) {
            throw new ArgumentException($"Raycast dictionary should contain the key {RaycastKeys.SHAPE}");
        }
        return new RaycastHit(position.AsVector3(),
                              normal.AsVector3(),
                              (Node3D)collider.AsGodotObject(),
                              colliderId.AsString(),
                              rid.AsRid(),
                              shape.AsInt32());
    }
}
