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

        public bool Equals(Matrix2D? other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                this.A == other.A &&
                this.B == other.B &&
                this.C == other.C &&
                this.D == other.D;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
