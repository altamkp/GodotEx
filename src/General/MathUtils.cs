using Godot;

namespace GodotEx;

public static class MathUtils {
    public const float DEFAULT_PRECISION = 1E-3f;
    public const float HALF_PI = Mathf.Pi / 2;

    public static float Trim(float value, float precision = DEFAULT_PRECISION) {
        if (precision <= 0 || precision >= 1) {
            throw new ArgumentOutOfRangeException(nameof(precision), "Precision should be positive and smaller than 1.");
        }
        return Mathf.Round(value / precision) * precision;
    }

    public static double Trim(double value, double precision = DEFAULT_PRECISION) {
        if (precision <= 0 || precision >= 1) {
            throw new ArgumentOutOfRangeException(nameof(precision), "Precision should be positive and smaller than 1.");
        }
        return Mathf.Round(value / precision) * precision;
    }

    public static bool IsEqualApprox(float a, float b, float precision = DEFAULT_PRECISION) {
        return a == b || Mathf.Abs(a - b) < precision;
    }

    public static bool IsZeroApprox(float value, float precision = DEFAULT_PRECISION) {
        return IsEqualApprox(value, 0, precision);
    }

    public static bool IsEqualApprox(double a, double b, double precision = DEFAULT_PRECISION) {
        return a == b || Mathf.Abs(a - b) < precision;
    }

    public static bool IsZeroApprox(double value, double precision = DEFAULT_PRECISION) {
        return IsEqualApprox(value, 0, precision);
    }
}
