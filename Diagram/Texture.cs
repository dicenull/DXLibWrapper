using System;
using Utilities;
using DxLibDLL;
using System.Collections.Generic;
using System.Linq;

namespace Graphics
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

        public int Handle { get; }

        public double Degree { get; private set; } = 0;
        public double Scale { get; private set; } = 1;

        public Vector2D Size { get; }

        public Vector2D ScaledSize { get { return new Vector2D((int)(Size.X * Scale), (int)(Size.Y * Scale)); } }

        public Texture(string path)
            : this(DX.LoadGraph(path)) { }

        public Texture(int handle)
        {
            this.Handle = handle;

            int w, h;
            DX.GetGraphSize(handle, out w, out h);
            Size = new Vector2D(w, h);
        }

        public void InitStatus()
        {
            Degree = 0;
            Scale = 1;
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
            DxDrawer.Instance.DrawTexture(this, pos);
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
            Draw(center - ScaledSize / 2);
        }

        public Texture Rotated(int degree)
        {
            this.Degree += degree;

            return this;
        }

        /// <summary>
        /// 倍率を指定して大きさを変更
        /// </summary>
        /// <param name="scale">倍率</param>
        public Texture Scaled(double scale)
        {
            Scale *= scale;
            
            return this;
        }

        public Texture Scaled(int length, BasedOn based)
        {
            Scale = based switch
            {
                BasedOn.Width => length / (double)Size.X,
                BasedOn.Height => length / (double)Size.Y,
                _ => throw new ArgumentException()
            };

            return this;
        }
    }

    public enum BasedOn
    {
        Width, Height
    };
}
