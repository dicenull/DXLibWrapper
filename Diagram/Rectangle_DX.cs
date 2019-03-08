using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DxLibDLL;

namespace Diagram
{
    /// <summary>
    /// 四角形クラス描画部
    /// </summary>
    public partial class Rectangle
    {
        public void Draw(Color color)
        {
            int x = Point.X, y = Point.Y;
            int w = Size.w, h = Size.h;
            var dxColor = DX.GetColor(color.R, color.G, color.B);
            
            DX.DrawBox(x, y, x + w, y + h, dxColor, 1);
        }
    }
}
