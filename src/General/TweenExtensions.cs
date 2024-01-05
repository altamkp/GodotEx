using Godot;

namespace GodotEx;

public static class TweenExtensions {
    public static Tween Expo(this Tween tween) {
        return tween.SetParallel(true).SetTrans(Tween.TransitionType.Expo).SetEase(Tween.EaseType.InOut);
    }

    public static Tween Sine(this Tween tween) {
        return tween.SetParallel(true).SetTrans(Tween.TransitionType.Sine).SetEase(Tween.EaseType.InOut);
    }

    public static Tween Linear(this Tween tween) {
        return tween.SetParallel(true).SetTrans(Tween.TransitionType.Linear).SetEase(Tween.EaseType.InOut);
    }

    public static bool SafeKill(this Tween tween) {
        if (tween.IsRunning()) {
            return false;
        } else {
            tween.Kill();
            return true;
        }
    }

    public static Tween InstantKill(this Tween tween) {
        tween.Kill();
        return tween;
    }

    public static void TweenUnscaled(this Tween tween, GodotObject @object, StringName property, Variant finalVal, float duration, Action? callback = null) {
        duration *= (float)Engine.TimeScale;
        tween.TweenProperty(@object, property.ToString(), finalVal, duration);
        if (callback != null) {
            tween.TweenCallback(Callable.From(callback)).SetDelay(duration);
        }
    }

    public static Task TweenUnscaledAsync(this Tween tween, GodotObject @object, StringName property, Variant finalVal, float duration, Action? callback = null) {
        tween.TweenUnscaled(@object, property, finalVal, duration);
        return tween.WaitAsync(callback);
    }

    public static Task WaitAsync(this Tween tween, Action? callback = null) {
        if (!tween.IsRunning()) {
            return Task.CompletedTask;
        } else {
            var taskCompletionSource = new TaskCompletionSource();
            Action onCompleted = () => {
                callback?.Invoke();
                taskCompletionSource.TrySetResult();
            };
            tween.Finished += onCompleted;
            return taskCompletionSource.Task;
        }
    }
}
