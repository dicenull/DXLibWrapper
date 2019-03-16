using Utilities;
using DxLibDLL;
using DxLibUtilities;

namespace Diagram
{
    public partial class Triangle
    {
        private void draw(Color color, bool isFill)
        {
            int flag = isFill ? 1 : 0;

            DX.DrawTriangle(Pos0.X, Pos0.Y, Pos1.X, Pos1.Y, Pos2.X, Pos2.Y, color.ToDxColor(), flag);
        }

        public void Draw(Color color)
        {
            draw(color, true);
        }

        public void DrawFrame(Color color)
        {
            draw(color, false);
        }
    }
}
