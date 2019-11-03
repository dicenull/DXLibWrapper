using Utilities;
using DxLibDLL;

namespace DxLibUtilities
{
	/// <summary>
	/// DxLibWrapper内Cololrの拡張
	/// </summary>
    public static class ColorExtentions
    {
		/// <summary>
		/// WrapperのColorをDxlibのColorに変換する
		/// </summary>
		/// <param name="color">WrapperのColor</param>
		/// <returns>変換されたDxlibのColor</returns>
        public static uint ToDxColor(this Color color)
        {
            return DX.GetColor(color.R, color.G, color.B);
        }
    }
}
