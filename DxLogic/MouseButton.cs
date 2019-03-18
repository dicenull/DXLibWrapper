using System;
using DxLibDLL;

namespace DxLogic
{
    public enum MouseButton
    {
        Left,
        Right,
        Middle,
        Button4,
        Button5,
        Button6,
        Button7,
        Button8
    }

    public static class MouseButtonExtentions
    {
        public static int ToCode(this MouseButton button)
        {
            return button switch
            {
                MouseButton.Left => DX.MOUSE_INPUT_LEFT,
                MouseButton.Right => DX.MOUSE_INPUT_RIGHT,
                MouseButton.Middle => DX.MOUSE_INPUT_MIDDLE,
                MouseButton.Button4 => DX.MOUSE_INPUT_4,
                MouseButton.Button5 => DX.MOUSE_INPUT_5,
                MouseButton.Button6 => DX.MOUSE_INPUT_6,
                MouseButton.Button7 => DX.MOUSE_INPUT_7,
                MouseButton.Button8 => DX.MOUSE_INPUT_8,
                _ => throw new ArgumentException()
            };
        }
    }
}
