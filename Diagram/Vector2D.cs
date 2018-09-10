using System;
using System.Collections.Generic;
using Utilities;

namespace Diagram
{
    public struct Vector2D<T> where T : struct, IComparable<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public static Vector2D<T> GetZero =>
            new Vector2D<T>(
                (T) Convert.ChangeType(0, typeof(T)), 
                (T) Convert.ChangeType(0, typeof(T)));

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

        public static Vector2D<T> operator +(Vector2D<T> vector, T value)
        {
            var add = Operator<T>.Add;

            return new Vector2D<T>(add(vector.X, value), add(vector.Y, value));
        }

        public static Vector2D<T> operator -(Vector2D<T> vector1, Vector2D<T> vector2)
        {
            var sub = Operator<T>.Subtract;

            return new Vector2D<T>(sub(vector1.X, vector2.X), sub(vector1.Y, vector2.Y));
        }

        public static Vector2D<T> operator -(Vector2D<T> vector, T value)
        {
            var sub = Operator<T>.Subtract;

            return new Vector2D<T>(sub(vector.X, value), sub(vector.Y, value));
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

        public Vector2D<T> XX => new Vector2D<T>(X, X);

        public Vector2D<T> XY => new Vector2D<T>(X, Y);

        public Vector2D<T> YX => new Vector2D<T>(Y, X);

        public Vector2D<T> YY => new Vector2D<T>(Y, Y);

        /// <summary>
        /// (x, y)だけ動かした先の座標を返す
        /// </summary>
        public Vector2D<T> MovedBy(T x, T y)
        {
            var add = Operator<T>.Add;
            return new Vector2D<T>(add(x, X), add(y, Y));
        }

        /// <summary>
        /// vectorだけ動かした先の座標を返す
        /// </summary>
        public Vector2D<T> MovedBy(Vector2D<T> vector)
        {
            return this + vector;
        }

        /// <summary>
        /// (x, y)だけ座標を動かす
        /// </summary>
        public void MoveBy(T x, T y)
        {
            X = Operator<T>.Add(X, x);
            Y = Operator<T>.Add(Y, y);
        }

        /// <summary>
        /// vectorだけ座標を動かす
        /// </summary>
        /// <param name="vector"></param>
        public void MoveBy(Vector2D<T> vector)
        {
            this += vector;
        }

        /// <summary>
        /// (x, y)どちらも0であるかを返す
        /// </summary>
        public bool IsZero()
        {
            return Convert.ToInt64(X) == 0 && Convert.ToInt64(Y) == 0;
        }

        /// <summary>
        /// vectorとの内積を返す
        /// </summary>
        public T Dot(Vector2D<T> vector)
        {
            var add = Operator<T>.Add;
            var multi = Operator<T>.Multiply;

            return add(multi(X, vector.X), multi(Y, vector.Y));
        }

        /// <summary>
        /// vectorとの外積を返す
        /// </summary>
        public T Cross(Vector2D<T> vector)
        {
            var sub = Operator<T>.Subtract;
            var multi = Operator<T>.Multiply;

            return sub(multi(X, vector.Y), multi(Y, vector.X));
        }

        /// <summary>
        /// 原点からの距離を返す
        /// </summary>
        public double Length()
        {
            return Math.Sqrt(Convert.ToDouble(Dot(this)));
        }

        /// <summary>
        /// vectorからの距離を返す
        /// </summary>
        public double DistanceFrom(Vector2D<T> vector)
        {
            return (this - vector).Length();
        }

        /// <summary>
        /// angleだけ回転させた座標を返す
        /// </summary>
        /// <param name="angle">[rad]</param>
        public Vector2D<double> Rotated(double angle)
        {
            var s = Math.Sin(angle);
            var c = Math.Cos(angle);
            var x = Convert.ToDouble(X);
            var y = Convert.ToDouble(Y);

            return new Vector2D<double>(x * c - y * s, x * s + y * c);
        }

        /// <summary>
        /// angleだけ座標を回転させる
        /// </summary>
        /// <param name="angle">[rad]</param>
        public void Rotate(double angle)
        {
            var p = Rotated(angle);
            var x = (T) Convert.ChangeType(p.X, typeof(T));
            var y = (T) Convert.ChangeType(p.Y, typeof(T));

            this = new Vector2D<T>(x, y);
        }

        /// <summary>
        /// vectorとこの座標が表す角度を返す
        /// </summary>
        public double GetAngle(Vector2D<T> vector)
        {
            return Math.Atan2(Convert.ToDouble(Cross(vector)), Convert.ToDouble(Dot(vector)));
        }

        public override string ToString()
        {
            return $"({X.ToString()}, {Y.ToString()})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2D<T>))
            {
                return false;
            }

            var d = (Vector2D<T>) obj;
            return EqualityComparer<T>.Default.Equals(X, d.X) &&
                   EqualityComparer<T>.Default.Equals(Y, d.Y);
        }

        public override int GetHashCode() => 1861411795 ^ X.GetHashCode() ^ Y.GetHashCode();
    }
}