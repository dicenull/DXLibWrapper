using System;
using Utilities;
using DxLibDLL;
using System.Collections.Generic;
using System.Linq;

namespace DxLibUtilities
{
    public class Texture
    {
        public static IEnumerable<Texture> LoadDivision(string path, int w, int h)
        {
            (int w, int h) size;
            DX.GetGraphSize(DX.LoadGraph(path), out size.w, out size.h);

            int[] handles = new int[w * h];
            DX.LoadDivGraph(path, w * h, w, h, size.w / w, size.h / h, handles);

            foreach(var handle in handles)
            {
                yield return new Texture(handle);
            }
        }

        private int handle;
        private double degree = 0;
        private (double w, double h) scale = (1, 1);

        public Vector2D Size { get; }


        public Texture(string path)
            : this(DX.LoadGraph(path)) { }

        public Texture(int handle)
        {
            this.handle = handle;

            int w, h;
            DX.GetGraphSize(handle, out w, out h);
            Size = new Vector2D(w, h);
        }

        public void Draw()
        {
            Draw(Vector2D.GetZero);
        }

        /// <summary>
        /// 画像を描画する
        /// </summary>
        /// <param name="pos">描画する左上の座標</param>
        public void Draw(Vector2D pos)
        {
            var scaledSize = new Vector2D((int)(Size.X * scale.w), (int)(Size.Y * scale.h));
            var center = pos + scaledSize / 2;

            if (degree % 360 == 0)
            {
                DX.DrawExtendGraph(pos.X, pos.Y, pos.X + scaledSize.X, pos.Y + scaledSize.Y, handle, DX.TRUE);
            }
            else
            {
                DX.DrawRotaGraph3(center.X, center.Y, center.X, center.Y,
                                scale.w, scale.h, Math.PI / 180.0 * degree, handle, DX.TRUE);
            }

            degree = 0;
            scale = (1, 1);
        }

        public void DrawAt()
        {
            DrawAt(Vector2D.GetZero);
        }

        /// <summary>
        /// 画像を描画する
        /// </summary>
        /// <param name="center">描画する中心座標</param>
        public void DrawAt(Vector2D center)
        {
            Draw(center - Size / 2);
        }

        public Texture Rotated(int degree)
        {
            this.degree += degree;

            return this;
        }

        public Texture Scaled(double w, double h)
        {
            scale.w *= w;
            scale.h *= h;

            return this;
        }

    }
}
