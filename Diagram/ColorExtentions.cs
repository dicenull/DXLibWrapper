using Utilities;
using DxLibDLL;

namespace Diagram
{
    public static class ColorExtentions
    {
        public static uint ToDxColor(this Color color)
        {
            return DX.GetColor(color.R, color.G, color.B);
        }
    }
}
