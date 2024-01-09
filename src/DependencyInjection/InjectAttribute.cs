namespace GodotEx.DependencyInjection;

/// <summary>
/// Attribute that is recognized by <see cref="NodeInjector"/> to inject field or 
/// property dependencies. Use with <see cref="GodotEx.Hosting.Host"/> is recommended.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class InjectAttribute : Attribute { }
