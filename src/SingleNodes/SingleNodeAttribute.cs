namespace GodotEx.SingleNodes;

/// <summary>
/// Attribute that is recognized by <see cref="SingleNodeAttribute"/>, 
/// adding or removing the object labeled by this attribute to the scene tree
/// as single nodes as it is added to or removed from the tree.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class SingleNodeAttribute : Attribute { }
