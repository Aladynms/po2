using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        #region === Ints ===

        private int A { get; init; }
        private int B { get; init; }
        private int C { get; init; }
        private int D { get; init; }

        #endregion

        #region === Methods && Constructors ===

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

        public static Matrix2D Transpose (Matrix2D left) =>
            new(
                left.A,
                left.C,
                left.B,
                left.D
                );

        public static int Determinant(Matrix2D left) => left.A * left.D - left.B * left.C;


        #endregion

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

        #endregion

        #region === Operators ===

        public static bool operator == (Matrix2D? left, Matrix2D? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;

            return left.Equals(right);
        }
        public static bool operator != (Matrix2D? left, Matrix2D? right) => 
            !(left == right);

        
        public static Matrix2D operator + (Matrix2D left, Matrix2D right) => 
            new(
                left.A + right.A,
                left.B + right.B,
                left.C + right.C,
                left.D + right.D
                );
        public static Matrix2D operator - (Matrix2D left, Matrix2D right) =>
            new(
                left.A - right.A,
                left.B - right.B,
                left.C - right.C,
                left.D - right.D
                );


        public static Matrix2D operator * (Matrix2D left, Matrix2D right) =>
            new(
                left.A * right.A + left.B * right.C,
                left.A * right.B + left.B * right.D,
                left.C * right.A + left.D * right.C,
                left.C * right.B + left.D * right.D
                );

        public static Matrix2D operator * (Matrix2D left, int s) =>
            new(
                left.A * s,
                left.B * s,
                left.C * s,
                left.D * s
                );

        public static Matrix2D operator * (int s, Matrix2D right) =>
            new(
                right.A * s,
                right.B * s,
                right.C * s,
                right.D * s
                );


        public static Matrix2D operator - (Matrix2D left) =>
            new(
                left.A * -1,
                left.B * -1,
                left.C * -1,
                left.D * -1
                );






        public static Matrix2D Parse(string s)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
