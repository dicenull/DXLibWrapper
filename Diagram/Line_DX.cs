using Utilities;
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
