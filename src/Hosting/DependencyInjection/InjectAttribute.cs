namespace GodotEx.Hosting;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
public class InjectAttribute : Attribute { }
