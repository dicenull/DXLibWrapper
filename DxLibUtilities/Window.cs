using DxLibDLL;
using Utilities;

namespace DxLibUtilities
{
	/// <summary>
	/// ウィンドウを管理する
	/// </summary>
    public static class Window
    {
		/// <summary>
		/// ウィンドウの大きさ
		/// </summary>
        public static Vector2D Size
        {
            get
            {
				DX.GetScreenState(out int w, out int h, out _);

				return new Vector2D(w, h);
            }

            set
            {
				// ビット震度を変えずにウィンドウの大きさだけ変更する
				DX.GetScreenState(out _, out _, out int bitDepth);
				DX.SetGraphMode(value.X, value.Y, bitDepth);
            }
        }

		/// <summary>
		/// ウィンドウの中央
		/// </summary>
        public static Vector2D Center
        {
            get
            {
                return Size / 2;
            }
        }

		/// <summary>
		/// ウィンドウタイトル
		/// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                DX.SetMainWindowText(value);
                title = value;
            }
        }
        private static string title = "DxLib";

		/// <summary>
		/// フルスクリーンモードかウィンドウモードか
		/// </summary>
        public static bool IsWindowMode
        {
            get
            {
                return DX.GetWindowModeFlag() == DX.TRUE;
            }
            set
            {
                DX.ChangeWindowMode(value ? DX.TRUE : DX.FALSE);
            }
        }
    }
}
