using System;
using System.Collections.Generic;
using Utilities;

namespace Diagram
{
    public struct Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Vector2D GetZero =>
            new Vector2D(0, 0);

        public Vector2D(Vector2D vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region 演算子

        public static Vector2D operator +(Vector2D vector)
        {
            return vector;
        }

        public static Vector2D operator -(Vector2D vector)
        {
            return new Vector2D(-vector.X, -vector.Y);
        }

        public static Vector2D operator +(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static Vector2D operator +(Vector2D vector, int value)
        {
            return new Vector2D(vector.X + value, vector.Y + value);
        }

        public static Vector2D operator -(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X - vector2.X, vector1.Y - vector2.Y);
        }

        public static Vector2D operator -(Vector2D vector, int value)
        {
            return new Vector2D(vector.X - value, vector.Y - value);
        }

        public static Vector2D operator *(Vector2D vector1, int value)
        {
            return new Vector2D(vector1.X * value, vector1.Y * value);
        }

        public static Vector2D operator *(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X * vector2.X, vector1.Y * vector2.Y);
        }

        public static Vector2D operator /(Vector2D vector1, int value)
        {
            return new Vector2D(vector1.X / value, vector1.Y / value);
        }

        public static Vector2D operator /(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X / vector2.X, vector1.Y / vector2.Y);
        }

        public static bool operator ==(Vector2D vector1, Vector2D vector2)
        {
            return vector1.X == vector2.X && vector1.Y == vector2.Y;
        }

        public static bool operator !=(Vector2D vector1, Vector2D vector2)
        {
            return (vector1.X != vector2.X) || (vector1.Y != vector2.Y);
        }

        #endregion

        public Vector2D XX => new Vector2D(X, X);

        public Vector2D XY => new Vector2D(X, Y);

        public Vector2D YX => new Vector2D(Y, X);

        public Vector2D YY => new Vector2D(Y, Y);

        /// <summary>
        /// (x, y)だけ動かした先の座標を返す
        /// </summary>
        public Vector2D MovedBy(int x, int y)
        {
            return new Vector2D(X + x, Y + y);
        }

        /// <summary>
        /// vectorだけ動かした先の座標を返す
        /// </summary>
        public Vector2D MovedBy(Vector2D vector)
        {
            return this + vector;
        }

        /// <summary>
        /// (x, y)だけ座標を動かす
        /// </summary>
        public void MoveBy(int x, int y)
        {
            X += x;
            Y += y;
        }

        /// <summary>
        /// vectorだけ座標を動かす
        /// </summary>
        /// <param name="vector"></param>
        public void MoveBy(Vector2D vector)
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
        public int Dot(Vector2D vector)
        {
            return (vector.X * X) + (vector.Y * Y);
        }

        /// <summary>
        /// vectorとの外積を返す
        /// </summary>
        public int Cross(Vector2D vector)
        {
            return (vector.Y * X) / (vector.X * Y);
        }

        /// <summary>
        /// 原点からの距離を返す
        /// </summary>
        public double Length()
        {
            return Math.Sqrt(Dot(this));
        }

        /// <summary>
        /// vectorからの距離を返す
        /// </summary>
        public double DistanceFrom(Vector2D vector)
        {
            return (this - vector).Length();
        }

        /// <summary>
        /// angleだけ回転させた座標を返す
        /// </summary>
        /// <param name="angle">[rad]</param>
        public Vector2D Rotated(double angle)
        {
            var s = (int)Math.Sin(angle);
            var c = (int)Math.Cos(angle);
            
            return new Vector2D(X * c - Y * s, X * s + Y * c);
        }

        /// <summary>
        /// angleだけ座標を回転させる
        /// </summary>
        /// <param name="angle">[rad]</param>
        public void Rotate(double angle)
        {
            this = Rotated(angle);
        }

        /// <summary>
        /// vectorとこの座標が表す角度を返す
        /// </summary>
        public double GetAngle(Vector2D vector)
        {
            return Math.Atan2(Cross(vector), Dot(vector));
        }

        public override string ToString()
        {
            return $"({X.ToString()}, {Y.ToString()})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2D))
            {
                return false;
            }

            var d = (Vector2D) obj;
            return X.Equals(d.X) && Y.Equals(d.Y);
        }

        public override int GetHashCode() => 1861411795 ^ X.GetHashCode() ^ Y.GetHashCode();
    }
}