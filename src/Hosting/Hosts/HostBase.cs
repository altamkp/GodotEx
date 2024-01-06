using Godot;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GodotEx.Hosting;

public abstract partial class HostBase : Node {
    private ServiceProvider _serviceProvider;

    public override void _EnterTree() {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();

        var eagerTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Concat(Assembly.GetCallingAssembly().GetTypes())
            .Where(t => t.IsDefined(typeof(EagerAttribute)));
        foreach (var eagerType in eagerTypes) {
            _ = GetService(eagerType)
                ?? throw new InvalidOperationException($"No service of type {eagerType.Name} found.");
        }
    }

    public object? GetService(Type serviceType) => _serviceProvider.GetService(serviceType);
    public object? GetService<T>() => _serviceProvider.GetService<T>();

    public object GetRequiredService(Type serviceType) => _serviceProvider.GetRequiredService(serviceType);
    public T GetRequiredService<T>() where T : notnull => _serviceProvider.GetRequiredService<T>();

    public IEnumerable<object?> GetServices(Type serviceType) => _serviceProvider.GetServices(serviceType);
    public IEnumerable<T> GetServices<T>() where T : notnull => _serviceProvider.GetServices<T>();

    protected virtual void ConfigureServices(IServiceCollection services) {
        services.AddSingleton(GetType(), this);
        services.AddSingleton(GetTree());
        services.AddSingleton<NodeInjector>();
        services.AddSingleton<SoleNodeManager>();
    }
}
