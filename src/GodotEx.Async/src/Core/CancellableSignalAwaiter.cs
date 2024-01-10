using Godot;
using System.Runtime.CompilerServices;

namespace GodotEx.Async;

/// <summary>
/// A cancellable signal awaiter that wraps the Godot <see cref="SignalAwaiter"/>. Using ToSignal 
/// with an additional <see cref="CancellationToken"/> as parameter automatically returns this awaiter. 
/// See <see cref="GodotObjectExtensions.ToSignal(GodotObject, GodotObject, StringName, CancellationToken)"/>.
/// </summary>
public class CancellableSignalAwaiter : IAwaiter<Variant[]>, INotifyCompletion, IAwaitable<Variant[]> {
    private readonly SignalAwaiter _signalAwaiter;
    private readonly CancellationToken _cancellationToken;
    private readonly CancellationTokenRegistration _cancellationTokenRegistration;

    private Action? _continuation;
    private bool _isCancelled;

    public CancellableSignalAwaiter(SignalAwaiter signalAwaiter, CancellationToken cancellationToken) {
        _signalAwaiter = signalAwaiter;
        _cancellationToken = cancellationToken;
        _cancellationTokenRegistration = _cancellationToken.Register(() => {
            _cancellationTokenRegistration.Dispose();
            _isCancelled = true;
            OnAwaiterCompleted();
        });
    }

    public bool IsCompleted => _isCancelled || _signalAwaiter.IsCompleted;

    public void OnCompleted(Action continuation) {
        _continuation = continuation;
        _signalAwaiter.OnCompleted(OnAwaiterCompleted);
    }

    public IAwaiter<Variant[]> GetAwaiter() => this;

    public Variant[] GetResult() => _signalAwaiter.GetResult();

    private void OnAwaiterCompleted() {
        var continuation = _continuation;
        _continuation = null;
        continuation?.Invoke();
    }
}
