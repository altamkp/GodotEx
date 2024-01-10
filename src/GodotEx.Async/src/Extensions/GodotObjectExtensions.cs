using Godot;

namespace GodotEx.Async;

/// <summary>
/// Extensions for <see cref="GodotObject"/>.
/// </summary>
public static class GodotObjectExtensions {
    /// <summary>
    /// Returns a new <see cref="CancellableSignalAwaiter"/> configured to complete either when the instance source 
    /// emits the signal specified by the signal parameter, or when cancellation is requested.
    /// </summary>
    /// <param name="object">Object to operate <see cref="GodotObject.ToSignal(GodotObject, StringName)"/> on.</param>
    /// <param name="source">Source of which signal is awaited.</param>
    /// <param name="signal">Signal to await.</param>
    /// <param name="cancellationToken">Cancellation token to provide the awaiter with.</param>
    /// <returns>A <see cref="CancellableSignalAwaiter"/> that completes either when the source emits the signal
    /// or when cancellation is requested.</returns>
    public static CancellableSignalAwaiter ToSignal(this GodotObject @object, GodotObject source, StringName signal, CancellationToken cancellationToken) {
        var signalAwaiter = @object.ToSignal(source, signal);
        return new CancellableSignalAwaiter(signalAwaiter, cancellationToken);
    }
}
