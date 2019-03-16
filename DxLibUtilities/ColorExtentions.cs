using Utilities;
using DxLibDLL;

namespace DxLibUtilities
{
    public static class ColorExtentions
    {
        public static uint ToDxColor(this Color color)
        {
            return DX.GetColor(color.R, color.G, color.B);
        }
    }
}
