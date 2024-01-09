using Godot;

namespace GodotEx.Extensions;

public static class TimerExtensions {
    /// <summary>
    /// Returns a <see cref="SignalAwaiter"/> that awaits the timer timeout.
    /// </summary>
    /// <param name="timer">Timer to await.</param>
    /// <returns>A Godot signal awaiter that awaits the timer timeout.</returns>
    public static SignalAwaiter TimeoutAsync(this Godot.Timer timer) {
        return timer.ToSignal(timer, Godot.Timer.SignalName.Timeout);
    }
}
