using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Utilities;

namespace Diagram
{
    public class Rect
    {
        /// <summary>
        /// 長方形の大きさ
        /// </summary>
        Vector2 Size { get; set; }

        /// <summary>
        /// 長方形の左上の座標
        /// </summary>
        Vector2 Point { get; set; }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Rect()
        { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="size">大きさ</param>
        public Rect(Vector2 size)
            : this(new Vector2(0, 0), size) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        public Rect(float w, float h)
            : this(new Vector2(0, 0), new Vector2(w, h)) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(float x, float y, float w, float h, Location pos = Location.TopLeft)
            : this(new Vector2(x, y), new Vector2(w, h), pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="x">基準となる位置のX座標</param>
        /// <param name="y">基準となる位置のY座標</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(float x, float y, Vector2 size, Location pos = Location.TopLeft)
            : this(new Vector2(x, y), size, pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(Vector2 point, float w, float h, Location pos = Location.TopLeft)
            : this(point, new Vector2(w, h), pos) { }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="point">基準となる位置</param>
        /// <param name="size">大きさ</param>
        /// <param name="pos">起点の位置</param>
        public Rect(Vector2 point, Vector2 size, Location pos = Location.TopLeft)
        {
            point.ToTopLeft(size, pos);
            Point = point;
            Size = size;
        }

        /// <summary>
        /// 長方形を作成します
        /// </summary>
        /// <param name="rect">コピー元の長方形</param>
        public Rect(Rect rect)
            : this(rect.Point, rect.Size) { }
    }
}
