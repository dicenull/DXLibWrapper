using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public struct Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        /// <summary>
        /// 色を作成します。
        /// </summary>
        /// <param name="_r">
        /// 赤 [0, 255]
        /// </param>
        /// <param name="_g">
        /// 緑 [0, 255]
        /// </param>
        /// <param name="_b">
        /// 青 [0, 255]
        /// </param>
        /// <param name="_a">
        /// アルファ [0, 255]
        /// </param>
        public Color(int r, int g, int b, int a = 255)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            A = (byte)a;
        }

        public Color(int rgb, int a = 255)
            : this(rgb, rgb, rgb, a) { }

        public Color(Color color)
            : this(color.R, color.G, color.B, color.A) { }

        public static bool operator==(Color c1, Color c2)
        {
            return c1.R == c2.R 
                && c1.G == c2.G 
                && c1.B == c2.B 
                && c1.A == c2.A;
        }

        public static bool operator!=(Color c1, Color c2)
        {
            return !(c1 == c2);
        }
    }
}
