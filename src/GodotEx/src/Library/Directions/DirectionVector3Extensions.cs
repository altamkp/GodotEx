using DotnetEx.Maths;
using Godot;

namespace GodotEx;

/// <summary>
/// Extensions for <see cref="Direction"/> related to <see cref="Vector3"/>.
/// </summary>
public static class DirectionVectorExtensions {
    /// <summary>
    /// Converts <see cref="Vector2"/> to <see cref="Direction"/>.
    /// </summary>
    /// <param name="vector">Vector to convert.</param>
    /// <returns>Direction converted from the input vector.</returns>
    /// <exception cref="ArgumentException">Vector is not orthogonal to any directions.</exception>
    public static Direction ToDirection(this Vector2 vector) {
        if (vector.IsEqualApprox(Vector2.Left, MathDef.DEFAULT_PRECISION)) {
            return Direction.Left;
        } else if (vector.IsEqualApprox(Vector2.Right, MathDef.DEFAULT_PRECISION)) {
            return Direction.Right;
        } else if (vector.IsEqualApprox(Vector2.Up, MathDef.DEFAULT_PRECISION)) {
            return Direction.Up;
        } else if (vector.IsEqualApprox(Vector2.Down, MathDef.DEFAULT_PRECISION)) {
            return Direction.Down;
        } else {
            throw new ArgumentException($"Vector {vector} is not orthogonal to the any of the directions.");
        }
    }

    /// <summary>
    /// Converts <see cref="Vector3"/> to <see cref="Direction"/>.
    /// </summary>
    /// <param name="vector">Vector to convert.</param>
    /// <returns>Direction converted from the input vector.</returns>
    /// <exception cref="ArgumentException">Vector is not orthogonal to any directions.</exception>
    public static Direction ToDirection(this Vector3 vector) {
        if (vector.IsEqualApprox(Vector3.Forward, MathDef.DEFAULT_PRECISION)) {
            return Direction.Forward;
        } else if (vector.IsEqualApprox(Vector3.Back, MathDef.DEFAULT_PRECISION)) {
            return Direction.Back;
        } else if (vector.IsEqualApprox(Vector3.Left, MathDef.DEFAULT_PRECISION)) {
            return Direction.Left;
        } else if (vector.IsEqualApprox(Vector3.Right, MathDef.DEFAULT_PRECISION)) {
            return Direction.Right;
        } else if (vector.IsEqualApprox(Vector3.Up, MathDef.DEFAULT_PRECISION)) {
            return Direction.Up;
        } else if (vector.IsEqualApprox(Vector3.Down, MathDef.DEFAULT_PRECISION)) {
            return Direction.Down;
        } else {
            throw new ArgumentException($"Vector {vector} is not orthogonal to the any of the directions.");
        }
    }
}
