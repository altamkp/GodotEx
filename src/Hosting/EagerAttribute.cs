namespace GodotEx.Hosting;

/// <summary>
/// Attribute that is recognized by <see cref="Host"/>, initializing class labeled
/// with this attribute eagerly when the host enters the scene tree.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class EagerAttribute : Attribute { }
