using System.Drawing;
using DxLibDLL;
using DxLibUtilities;

namespace Diagram
{
    public partial class Circle
    {
        public void Draw(Color color)
        {
            DX.DrawCircle(Origin.X, Origin.Y, Radius, color.ToDxColor());
        }
    }
}
