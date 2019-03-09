using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DxLibDLL;
using DxLibUtilities;

namespace Diagram
{
    public partial class Line
    {
        public void Draw(Color color)
        {
            DX.DrawLine(Begin.X, Begin.Y, End.X, End.Y, color.ToDxColor());
        }
    }
}
