using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram
{
    public struct Color
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public byte A { get; }

        public Color(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        /// <param name="r">赤 [0, 255]</param>
        /// <param name="g">緑 [0, 255]</param>
        /// <param name="b">青 [0, 255]</param>
        /// <param name="a">アルファ [0, 255]</param>
        public Color(int r, int g, int b, int a = 255)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            A = (byte)a;
        }

        public Color((int r, int g, int b) color, int a = 255)
            : this(color.r, color.g, color.b, a) { }

        /// <param name="rgb">グレイスケール [0, 255]</param>
        /// <param name="a">アルファ [0, 255]</param>
        public Color(int rgb, int a = 255)
            : this(rgb, rgb, rgb, a) { }
    }
}
