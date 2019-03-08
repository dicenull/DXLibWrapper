using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace Diagram
{
    /// <summary>
    /// 四角形クラス描画部
    /// </summary>
    public partial class Rectangle
    {
        public void Draw()
        {
            int x = Point.X, y = Point.Y;
            int w = Size.X, h = Size.Y;

            // TODO : 色を指定できるように
            DX.DrawBox(x, y, x + w, y + h, DX.GetColor(255, 255, 255), 1);
        }
    }
}
