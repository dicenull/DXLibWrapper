using DxLibDLL;
using Utilities;

namespace DxLibUtilities
{
    public static class Window
    {
        public static Vector2D Size
        {
            get
            {
                int w, h;
                DX.GetScreenState(out w, out h, out _);

                return new Vector2D(w, h);
            }

            set
            {
                int bitDepth;
                DX.GetScreenState(out _, out _, out bitDepth);
                DX.SetGraphMode(value.X, value.Y, bitDepth);
            }
        }

        public static Vector2D Center
        {
            get
            {
                return Size / 2;
            }
        }

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
