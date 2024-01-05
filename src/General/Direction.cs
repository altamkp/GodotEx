using Godot;

namespace GodotEx;

public enum Direction {
    Up,
    Down,
    Left,
    Right,
    Forward,
    Back
}

public static class DirectionExtensions {
    public static Direction Flip(this Direction direction) {
        return direction switch {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            Direction.Forward => Direction.Back,
            Direction.Back => Direction.Forward,
            _ => throw new ArgumentException("Direction does not exist.")
        };
    }

    public static Vector3 ToVector(this Direction direction) {
        return direction switch {
            Direction.Up => Vector3.Up,
            Direction.Down => Vector3.Down,
            Direction.Left => Vector3.Left,
            Direction.Right => Vector3.Right,
            Direction.Forward => Vector3.Forward,
            Direction.Back => Vector3.Back,
            _ => throw new ArgumentException("Direction does not exist.")
        };
    }

    public static Vector3 ToDirectionVector(this Direction direction, Transform3D transform) {
        return direction switch {
            Direction.Up => transform.Up(),
            Direction.Down => transform.Down(),
            Direction.Left => transform.Left(),
            Direction.Right => transform.Right(),
            Direction.Forward => transform.Forward(),
            Direction.Back => transform.Back(),
            _ => throw new ArgumentException("Direction does not exist.")
        };
    }

    public static (Vector3, float) ToRotationVector(this Direction direction, Transform3D transform) {
        return direction switch {
            Direction.Up => (transform.Forward(), Mathf.Pi),
            Direction.Down => (transform.Forward(), 0),
            Direction.Left => (transform.Forward(), -Mathf.Pi * 0.5f),
            Direction.Right => (transform.Forward(), Mathf.Pi * 0.5f),
            Direction.Forward => (transform.Right(), -Mathf.Pi * 0.5f),
            Direction.Back => (transform.Right(), Mathf.Pi * 0.5f),
            _ => throw new ArgumentException("Direction does not exist.")
        };
    }
}
