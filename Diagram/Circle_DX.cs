using Utilities;
using DxLibDLL;
using DxLibUtilities;

namespace Diagram
{
    public partial class Circle
    {
        public void Draw(Color color)
        {
            DX.DrawCircle(Center.X, Center.Y, Radius, color.ToDxColor());
        }

        public void DrawFrame(Color color)
        {
            DX.DrawCircle(Center.X, Center.Y, Radius, color.ToDxColor(), 0);
        }
    }
}
