using Godot;

namespace GodotEx;

public static class TweenExtensions {
    /// <summary>
    /// Sets the tween to a default behaviour of parallel and in-out ease.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Default(this Tween tween) => tween.SetParallel().SetEase(Tween.EaseType.InOut);

    /// <summary>
    /// Sets the ease type of <paramref name="tween"/> to <see cref="Tween.EaseType.In"/>.
    /// </summary>
    /// <param name="tween"></param>
    /// <returns>Set tween.</returns>
    public static Tween In(this Tween tween) => tween.SetEase(Tween.EaseType.In);

    /// <summary>
    /// Sets the ease type of <paramref name="tween"/> to <see cref="Tween.EaseType.Out"/>.
    /// </summary>
    /// <param name="tween"></param>
    /// <returns>Set tween.</returns>
    public static Tween Out(this Tween tween) => tween.SetEase(Tween.EaseType.Out);

    /// <summary>
    /// Sets the ease type of <paramref name="tween"/> to <see cref="Tween.EaseType.InOut"/>.
    /// </summary>
    /// <param name="tween"></param>
    /// <returns>Set tween.</returns>
    public static Tween InOut(this Tween tween) => tween.SetEase(Tween.EaseType.InOut);

    /// <summary>
    /// Sets the ease type of <paramref name="tween"/> to <see cref="Tween.EaseType.OutIn"/>.
    /// </summary>
    /// <param name="tween"></param>
    /// <returns>Set tween.</returns>
    public static Tween OutIn(this Tween tween) => tween.SetEase(Tween.EaseType.OutIn);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Linear"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Linear(this Tween tween) => tween.SetTrans(Tween.TransitionType.Linear);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Sine"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Sine(this Tween tween) => tween.SetTrans(Tween.TransitionType.Sine);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Quint"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Quint(this Tween tween) => tween.SetTrans(Tween.TransitionType.Quint);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Quart"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Quart(this Tween tween) => tween.SetTrans(Tween.TransitionType.Quart);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Quad"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Quad(this Tween tween) => tween.SetTrans(Tween.TransitionType.Quad);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Expo"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Expo(this Tween tween) => tween.SetTrans(Tween.TransitionType.Expo);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Elastic"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Elastic(this Tween tween) => tween.SetTrans(Tween.TransitionType.Elastic);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Cubic"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Cubic(this Tween tween) => tween.SetTrans(Tween.TransitionType.Cubic);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Circ"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Circ(this Tween tween) => tween.SetTrans(Tween.TransitionType.Circ);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Bounce"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Bounce(this Tween tween) => tween.SetTrans(Tween.TransitionType.Bounce);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Back"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Back(this Tween tween) => tween.SetTrans(Tween.TransitionType.Back);

    /// <summary>
    /// Sets the transition type of <paramref name="tween"/> to <see cref="Tween.TransitionType.Spring"/>.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <returns>Set tween.</returns>
    public static Tween Spring(this Tween tween) => tween.SetTrans(Tween.TransitionType.Spring);

    /// <summary>
    /// Tries aborting all tweening operations if <paramref name="tween"/> is not currently running.
    /// </summary>
    /// <param name="tween">Tween to kill.</param>
    /// <returns>True if <paramref name="tween"/> is not running and thus successfully killed.</returns>
    public static bool TryKill(this Tween tween) {
        if (!tween.IsRunning()) {
            tween.Kill();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates and appends a PropertyTweener. This method tweens a property of an object between 
    /// an initial value and finalVal in a span of time equal to duration, in seconds. 
    /// The initial value by default is the property's value at the time the tweening of the PropertyTweener starts.
    /// </summary>
    /// <param name="tween">Tween to use.</param>
    /// <param name="object">Object to tween.</param>
    /// <param name="property">Property of the object to tween.</param>
    /// <param name="finalVal">Tween target.</param>
    /// <param name="duration">Tween duration.</param>
    /// <returns>Result property tweener.</returns>
    public static PropertyTweener TweenProperty(this Tween tween, GodotObject @object, StringName property, Variant finalVal, float duration) {
        return tween.TweenProperty(@object, property.ToString(), finalVal, duration);
    }

    /// <summary>
    /// Sets the tween's Unscaled metadata property to <paramref name="unscaled"/>.
    /// When calling any of the asynchronously extension methods, tweens will run
    /// disregarding the engine's current timescale if this property is set to true.
    /// </summary>
    /// <param name="tween">Tween to set.</param>
    /// <param name="unscaled">True to set tween to ignore engine timescale.</param>
    /// <returns>Set tween.</returns>
    public static Tween Unscaled(this Tween tween, bool unscaled = true) {
        tween.SetMeta(nameof(Unscaled), unscaled);
        return tween;
    }

    /// <summary>
    /// Asynchronously waits for the tween to finish, or returns immediately if tween 
    /// is not currently running.
    /// </summary>
    /// <param name="tween">Tween to wait.</param>
    /// <returns>A task that represents the asynchronous wait operation.</returns>
    public static Task WaitAsync(this Tween tween) {
        if (!tween.IsRunning()) {
            return Task.CompletedTask;
        }

        var tcs = new TaskCompletionSource();
        tween.Finished += OnFinished;
        return tcs.Task;

        void OnFinished() {
            tween.Finished -= OnFinished;
            tcs.SetResult();
        }
    }

    /// <summary>
    /// Asynchronously tweens an object's property between an initial value and 
    /// <paramref name="finalVal"/> in a span of <paramref name="duration"/> seconds.
    /// </summary>
    /// <param name="tween">Tween to use.</param>
    /// <param name="object">Object to tween.</param>
    /// <param name="property">Property of the object to tween.</param>
    /// <param name="finalVal">Tween target.</param>
    /// <param name="duration">Tween duration.</param>
    /// <returns>A task that represents the asynchronous tween operation.</returns>
    public static Task TweenPropertyAsync(this Tween tween, GodotObject @object, NodePath property, Variant finalVal, float duration) {
        tween.TweenProperty(@object, property, finalVal, GetDuration(tween, duration));
        return tween.WaitAsync();
    }

    /// <summary>
    /// Asynchronously tweens the <paramref name="property"/> of an <paramref name="object"/>
    /// between an initial value and  <paramref name="finalVal"/> within a span of 
    /// <paramref name="duration"/> seconds.
    /// </summary>
    /// <param name="tween">Tween to use.</param>
    /// <param name="object">Object to tween.</param>
    /// <param name="property">Property of the object to tween.</param>
    /// <param name="finalVal">Tween target.</param>
    /// <param name="duration">Tween duration.</param>
    /// <returns>A task that represents the asynchronous tween operation.</returns>
    public static Task TweenPropertyAsync(this Tween tween, GodotObject @object, StringName property, Variant finalVal, float duration) {
        tween.TweenProperty(@object, property.ToString(), finalVal, GetDuration(tween, duration));
        return tween.WaitAsync();
    }

    /// <summary>
    /// Asynchronously calls a series of <paramref name="method"/> by supplying the tweened argument
    /// between <paramref name="from"/> and <paramref name="to"/> within a span of 
    /// <paramref name="duration"/> seconds.
    /// </summary>
    /// <param name="tween">Tween to use.</param>
    /// <param name="method">Method to tween.</param>
    /// <param name="from">Initial argument value.</param>
    /// <param name="to">Final argument value.</param>
    /// <param name="duration">Tween duration.</param>
    /// <returns>A task that represents the asynchronous tween operation.</returns>
    public static Task TweenMethodAsync(this Tween tween, Callable method, Variant from, Variant to, float duration) {
        tween.TweenMethod(method, from, to, GetDuration(tween, duration));
        return tween.WaitAsync();
    }

    /// <summary>
    /// Asynchronously calls a series of <paramref name="method"/> by supplying the tweened argument
    /// between <paramref name="from"/> and <paramref name="to"/> within a span of 
    /// <paramref name="duration"/> seconds.
    /// </summary>
    /// <typeparam name="T">Variant type.</typeparam>
    /// <param name="tween">Tween to use.</param>
    /// <param name="method">Method to tween.</param>
    /// <param name="from">Initial argument value.</param>
    /// <param name="to">Final argument value.</param>
    /// <param name="duration">Tween duration.</param>
    /// <returns>A task that represents the asynchronous tween operation.</returns>
    public static Task TweenMethodAsync<[MustBeVariant] T>(this Tween tween, Action<T> method, T from, T to, float duration) {
        tween.TweenMethod(Callable.From(method), Variant.From(from), Variant.From(to), GetDuration(tween, duration));
        return tween.WaitAsync();
    }

    private static float GetDuration(Tween tween, float duration) {
        if (!tween.HasMethod(nameof(Unscaled))) {
            return duration;
        }
        var unscaled = tween.GetMeta(nameof(Unscaled)).AsBool();
        return unscaled ? (float)(duration / Engine.TimeScale) : duration;
    }
}
