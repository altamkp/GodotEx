namespace GodotEx;

internal interface ILayerAttribute {
    uint Flags { get; }
}

/// <summary>
/// Attribute that is recognized by <see cref="NodeExtensions.SetLayers(Godot.Node)"/> to set
/// the target node's layer property to the provided flags.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class LayerAttribute : Attribute, ILayerAttribute {
    /// <summary>
    /// Returns a new <see cref="LayerAttribute"/> which is used by <see cref="NodeExtensions.SetLayers(Godot.Node)"/>
    /// to set the target node's layer property to the provided flags. The node must have exactly one property
    /// with name containing "layer" and flags must be castable to <see cref="uint"/>.
    /// </summary>
    /// <param name="flags">Flags to apply</param>
    /// <exception cref="InvalidCastException"><paramref name="flags"/> is not of type uint.</exception>
    public LayerAttribute(object flags) {
        try {
            Flags = (uint)flags;
        } catch (Exception) {
            throw new InvalidCastException($"Failed to cast flags of type {flags.GetType().Name} to uint.");
        }
    }

    /// <summary>
    /// Layer flags.
    /// </summary>
    public uint Flags { get; }
}

/// <summary>
/// Attribute that is recognized by <see cref="NodeExtensions.SetLayers(Godot.Node)"/> to set
/// the target node's mask property to the provided flags.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class MaskAttribute : Attribute, ILayerAttribute {
    /// <summary>
    /// Returns a new <see cref="MaskAttribute"/> which is used by <see cref="NodeExtensions.SetLayers(Godot.Node)"/>
    /// to set the target node's mask property to the provided flags. The node must have exactly one property
    /// with name containing "mask" and flags must be castable to <see cref="uint"/>.
    /// </summary>
    /// <param name="flags">Flags to apply</param>
    /// <exception cref="InvalidCastException"><paramref name="flags"/> is not of type uint.</exception>
    public MaskAttribute(object flags) {
        try {
            Flags = (uint)flags;
        } catch (Exception) {
            throw new InvalidCastException($"Failed to cast flags of type {flags.GetType().Name} to uint.");
        }
    }

    /// <summary>
    /// Mask flags.
    /// </summary>
    public uint Flags { get; }
}
