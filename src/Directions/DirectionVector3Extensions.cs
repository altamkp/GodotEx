using DotnetEx.Maths;
using Godot;
using GodotEx.Extensions;

namespace GodotEx.Directions;

public static class DirectionVector3Extensions {
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
            throw new ArgumentException($"Vector {vector} is not orthogonal to the any of the axes.");
        }
    }
}
