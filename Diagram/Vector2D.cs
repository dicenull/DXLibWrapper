using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Diagram
{
    using Float2 = Vector2D<float>;
    using Vec2 = Vector2D<double>;
    using Point = Vector2D<int>;

    public struct Vector2D<T> where T : struct, IComparable<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Vector2D(Vector2D<T> vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public Vector2D(T x, T y)
        {
            X = x;
            Y = y;
        }

        #region 演算子
        public static Vector2D<T> operator +(Vector2D<T> vector)
        {
            return vector;
        }

        public static Vector2D<T> operator -(Vector2D<T> vector)
        {
            var negate = Operator<T>.Negate;

            return new Vector2D<T>(negate(vector.X), negate(vector.Y));
        }

        public static Vector2D<T> operator +(Vector2D<T> vector1, Vector2D<T> vector2)
        {
            var add = Operator<T>.Add;

            return new Vector2D<T>(add(vector1.X, vector2.X), add(vector1.Y, vector2.Y));
        }

        public static Vector2D<T> operator -(Vector2D<T> vector1, Vector2D<T> vector2)
        {
            var sub = Operator<T>.Subtract;

            return new Vector2D<T>(sub(vector1.X, vector2.X), sub(vector1.Y, vector2.Y));
        }

        public static Vector2D<T> operator *(Vector2D<T> vector1, T value)
        {
            var multi = Operator<T>.Multiply;

            return new Vector2D<T>(multi(vector1.X, value), multi(vector1.Y, value));
        }

        public static Vector2D<T> operator *(Vector2D<T> vector1, Vector2D<T> vector2)
        {
            var multi = Operator<T>.Multiply;

            return new Vector2D<T>(multi(vector1.X, vector2.X), multi(vector1.Y, vector2.Y));
        }

        public static Vector2D<T> operator /(Vector2D<T> vector1, T value)
        {
            var div = Operator<T>.Divide;

            return new Vector2D<T>(div(vector1.X, value), div(vector1.Y, value));
        }

        public static Vector2D<T> operator /(Vector2D<T> vector1, Vector2D<T> vector2)
        {
            var div = Operator<T>.Divide;

            return new Vector2D<T>(div(vector1.X, vector2.X), div(vector1.Y, vector2.Y));
        }

        public static bool operator ==(Vector2D<T> vector1, Vector2D<T> vector2)
        {
            return (vector1.X.CompareTo(vector2.X) == 0) && (vector1.Y.CompareTo(vector2.Y) == 0);
        }

        public static bool operator !=(Vector2D<T> vector1, Vector2D<T> vector2)
        {
            return (vector1.X.CompareTo(vector2.X) != 0) || (vector1.Y.CompareTo(vector2.Y) != 0);
        }
        #endregion

        public Vector2D<T> XX
        {
            get { return new Vector2D<T>(X, X); }
        }

        public Vector2D<T> XY
        {
            get { return new Vector2D<T>(X, Y); }
        }

        public Vector2D<T> YX
        {
            get { return new Vector2D<T>(Y, X); }
        }

        public Vector2D<T> YY
        {
            get { return new Vector2D<T>(Y, Y); }
        }
        
        public Vector2D<T> MovedBy(T x, T y)
        {
            return new Vector2D<T>(x, y);
        }

        public Vector2D<T> MovedBy(Vector2D<T> vector)
        {
            return this + vector;
        }

        public void MoveBy(T x, T y)
        {
            X = Operator<T>.Add(X, x);
            Y = Operator<T>.Add(Y, y);
        }

        public void MoveBy(Vector2D<T> vector)
        {
            this += vector;
        }

        public bool isZero()
        {
            T zero = (T)(object)0.0;

            return X.CompareTo(zero) == 0 && Y.CompareTo(zero) == 0;
        }

        public T Dot(Vector2D<T> vector)
        {
            var add = Operator<T>.Add;
            var multi = Operator<T>.Multiply;

            return add(multi(X, vector.X), multi(Y, vector.Y));
        }

        public T Cross(Vector2D<T> vector)
        {
            var sub = Operator<T>.Subtract;
            var multi = Operator<T>.Multiply;

            return sub(multi(X, vector.Y), multi(Y, vector.X));
        }

        public T Length()
        {
            return (T)(object)Math.Sqrt((double)(object)Dot(this));
        }

        public T DistanceFrom(Vector2D<T> vector)
        {
            return (this - vector).Length();
        }

        public Vector2D<T> Normalized()
        {
            return this / Length();
        }

        public void Normalize()
        {
            this /= Length();
        }

        public Vector2D<T> Rotated(T angle)
        {
            T s = (T)(object)Math.Sin((double)(object)angle);
            T c = (T)(object)Math.Cos((double)(object)angle);

            var add = Operator<T>.Add;
            var sub = Operator<T>.Subtract;
            var multi = Operator<T>.Multiply;

            return new Vector2D<T>(sub(multi(X, c), multi(Y, s)), add(multi(X, s), multi(Y, c)));
        }

        public void Rotate(T angle)
        {
            this = Rotated(angle);
        }

        public T GetAngle(Vector2D<T> vector)
        {
            if(isZero() || vector.isZero())
            {
                return (T)(object)double.NaN;
            }

            return (T)(object)Math.Atan2((double)(object)Cross(vector), (double)(object)Dot(vector));
        }
        
        public override string ToString()
        {
            return $"({ X.ToString() }, { Y.ToString() })";
        }
    }
}