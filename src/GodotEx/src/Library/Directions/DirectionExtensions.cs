using Godot;

namespace GodotEx;

public static class DirectionExtensions {
    /// <summary>
    /// Flips direction.
    /// </summary>
    /// <param name="direction">Direction to flip</param>
    /// <returns>Flipped direction</returns>
    public static Direction Flip(this Direction direction) {
        return direction switch {
            Direction.Right => Direction.Left,
            Direction.Left => Direction.Right,
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Forward => Direction.Back,
            Direction.Back => Direction.Forward,
            _ => throw new ArgumentException($"Non-existing direction {direction}.")
        };
    }

    /// <summary>
    /// Converts direction to <see cref="Vector2"/>.
    /// </summary>
    /// <param name="direction">Direction to convert.</param>
    /// <returns>Result vector.</returns>
    /// <exception cref="ArgumentException">Non-existing 2D direction.</exception>
    public static Vector2 ToVector2(this Direction direction) {
        return direction switch {
            Direction.Right => Vector2.Right,
            Direction.Left => Vector2.Left,
            Direction.Up => Vector2.Up,
            Direction.Down => Vector2.Down,
            _ => throw new ArgumentException($"Non-existing 2D direction {direction}.")
        };
    }

    /// <summary>
    /// Converts direction to <see cref="Vector3"/>.
    /// </summary>
    /// <param name="direction">Direction to convert.</param>
    /// <returns>Result vector.</returns>
    public static Vector3 ToVector3(this Direction direction) {
        return direction switch {
            Direction.Right => Vector3.Right,
            Direction.Left => Vector3.Left,
            Direction.Up => Vector3.Up,
            Direction.Down => Vector3.Down,
            Direction.Forward => Vector3.Forward,
            Direction.Back => Vector3.Back,
            _ => throw new ArgumentException($"Non-existing 3D direction {direction}.")
        };
    }

    public static Vector3 ToDirectionVector(this Direction direction, Transform3D transform) {
        return direction switch {
            Direction.Right => transform.Right(),
            Direction.Left => transform.Left(),
            Direction.Up => transform.Up(),
            Direction.Down => transform.Down(),
            Direction.Forward => transform.Forward(),
            Direction.Back => transform.Back(),
            _ => throw new ArgumentException($"Non-existing direction {direction}.")
        };
    }

    public static (Vector3, float) ToRotationVector(this Direction direction, Transform3D transform) {
        return direction switch {
            Direction.Right => (transform.Forward(), MathfDef.HALF_PI),
            Direction.Left => (transform.Forward(), -MathfDef.HALF_PI),
            Direction.Up => (transform.Forward(), Mathf.Pi),
            Direction.Down => (transform.Forward(), 0),
            Direction.Forward => (transform.Right(), -MathfDef.HALF_PI),
            Direction.Back => (transform.Right(), MathfDef.HALF_PI),
            _ => throw new ArgumentException($"Non-existing direction {direction}.")
        };
    }
}
