using System;
using DxLibDLL;

namespace DxLibUtilities
{
    public class Mouse : IInput<MouseButton>
    {
        public Mouse()
        {
            Update();
        }

        public bool IsDown(MouseButton button)
        {
            return (mouseState[prev] & button.ToCode()) == 0
                && (mouseState[flip] & button.ToCode()) != 0;
        }

        public bool IsPressed(MouseButton button)
        {
            return (mouseState[flip] & button.ToCode()) != 0;
        }

        public bool IsRelease(MouseButton button)
        {
            return (mouseState[flip] & button.ToCode()) == 0;
        }

        public bool IsUp(MouseButton button)
        {
            return (mouseState[prev] & button.ToCode()) != 0
                && (mouseState[flip] & button.ToCode()) == 0;
        }

        public void Update()
        {
            flip = 1 - flip;

            mouseState[flip] = DX.GetMouseInput();
        }

        private int flip = 0;
        private int prev { get { return 1 - flip; } }
        private int[] mouseState = { 0, 0 };
    }
}
