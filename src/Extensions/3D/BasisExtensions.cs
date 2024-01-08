using DotnetEx.Maths;
using Godot;

namespace GodotEx.Extensions;

public static class BasisExtensions {
    /// <summary>
    /// Trims basis to a given precision.
    /// </summary>
    /// <param name="basis">Basis to trim.</param>
    /// <param name="precision">Precision to use.</param>
    /// <returns>Trimmed basis.</returns>
    public static Basis Trim(this Basis basis, float precision = MathDef.DEFAULT_PRECISION) {
        return new(basis.X.Trim(precision), basis.Y.Trim(precision), basis.Z.Trim(precision));
    }
}
