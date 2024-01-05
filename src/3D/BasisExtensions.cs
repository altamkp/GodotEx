using Godot;

namespace GodotEx;

public static class BasisExtensions {
	public static Basis Trim(this Basis basis) {
		return new Basis(basis.X.Trim(), basis.Y.Trim(), basis.Z.Trim());
	}
}
