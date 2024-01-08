namespace GodotEx.DependencyInjection;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class InjectAttribute : Attribute { }
