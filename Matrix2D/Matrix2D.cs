using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        private int A { get; init; }
        private int B { get; init; }
        private int C { get; init; }
        private int D { get; init; }


        public static Matrix2D Zero { get;  } = new(0, 0, 0, 0);
        public static Matrix2D Id { get; } = new();


        public Matrix2D(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Matrix2D() : this(1, 0, 0, 1) { }

        public override string ToString() => $"[[{A}, {B}], [{C}, {D}]]";

        #region === Equals ===

        public bool Equals(Matrix2D? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                this.A == other.A &&
                this.B == other.B &&
                this.C == other.C &&
                this.D == other.D;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Matrix2D) return false;

            return Equals( obj as Matrix2D);
        }

        public override int GetHashCode() => HashCode.Combine(A, B, C, D);


        public static bool operator == (Matrix2D? left, Matrix2D? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;

            return left.Equals(right);
        }
        public static bool operator != (Matrix2D? left, Matrix2D? right) => !(left == right);

        #endregion
    }
}
