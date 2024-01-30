using Godot;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GodotEx.Hosting;

/// <summary>
/// A node that provides hosting service. Override <see cref="ConfigureServices(IServiceCollection)"/>
/// to configure services added to the internal <see cref="ServiceProvider"/>. 
/// <br/><br/>
/// Includes default services, namely:
/// <br/>Current <see cref="Host"/>
/// <br/><see cref="SceneTree"/>
/// <br/><see cref="DependencyInjector"/>
/// <br/><see cref="NodeResolver"/>
/// <br/><see cref="SingleNodeManager"/>
/// </summary>
/// <remarks>
/// <b>Note</b>: host nodes can exist any where within the current scene, 
/// but there may only be at most one autoload host.
/// </remarks>
public abstract partial class Host : Node {
    /// <summary>
    /// Autoload host instance configured in Project Settings.
    /// </summary>
    public static Host Autoload { get; private set; }

    private ServiceProvider _serviceProvider;

    /// <summary>
    /// Called when the node enters the Godot.SceneTree (e.g. upon instancing, scene
    /// changing, or after calling <see cref="Node.AddChild(Node, bool, InternalMode)"/>
    /// in a script). If the node has children, its Godot.Node._EnterTree callback will
    /// be called first, and then that of the children.
    /// </summary>
    public override void _EnterTree() {
        if (GetParent() == GetTree().Root && this != GetTree().CurrentScene) {
            if (Autoload != null) {
                throw new InvalidOperationException("Autoload host exists already.");
            }
            Autoload = this;
        }

        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();

        var eagerTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Concat(Assembly.GetCallingAssembly().GetTypes())
            .Where(t => t.IsDefined(typeof(EagerAttribute)));
        foreach (var eagerType in eagerTypes) {
            _ = GetService(eagerType) ?? throw new InvalidOperationException($"No service of type {eagerType.Name} found.");
        }
    }

    /// <summary>
    /// Returns service of <paramref name="type"/>.
    /// </summary>
    /// <param name="type">Type to match.</param>
    /// <returns>Service object of <paramref name="type"/>, null if not found.</returns>
    public object? GetService(Type type) => _serviceProvider.GetService(type);

    /// <summary>
    /// Returns service of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type to match.</typeparam>
    /// <returns>Service object of type <typeparamref name="T"/>, null if not found.</returns>
    public object? GetService<T>() => _serviceProvider.GetService<T>();

    /// <summary>
    /// Returns service of <paramref name="type"/>.
    /// </summary>
    /// <param name="type">Type to match.</param>
    /// <returns>Service object of <paramref name="type"/>.</returns>
    /// <exception cref="InvalidOperationException">Service of <paramref name="type"/> not found.</exception>
    public object GetRequiredService(Type type) => _serviceProvider.GetRequiredService(type);

    /// <summary>
    /// Returns service of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type to match.</typeparam>
    /// <returns>Service object of type <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidOperationException">Service of type <typeparamref name="T"/> not found.</exception>
    public T GetRequiredService<T>() where T : notnull => _serviceProvider.GetRequiredService<T>();

    /// <summary>
    /// Returns all services of <paramref name="type"/>.
    /// </summary>
    /// <param name="type">Type to match.</param>
    /// <returns>All service objects of <paramref name="type"/>.</returns>
    public IEnumerable<object?> GetServices(Type type) => _serviceProvider.GetServices(type);

    /// <summary>
    /// Returns all services of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type to match.</typeparam>
    /// <returns>All service objects of type <typeparamref name="T"/>.</returns>
    public IEnumerable<T> GetServices<T>() where T : notnull => _serviceProvider.GetServices<T>();

    /// <summary>
    /// Configures service collection.
    /// </summary>
    /// <param name="services">Service collection to configure.</param>
    protected virtual void ConfigureServices(IServiceCollection services) {
        services.AddSingleton(GetType(), this);
        services.AddSingleton(GetTree());
        services.AddSingleton<DependencyInjector>();
        services.AddSingleton<NodeResolver>();
        services.AddSingleton<SingleNodeManager>();
    }
}
