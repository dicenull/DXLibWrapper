using DxLibDLL;
using Utilities;

namespace DxLogic
{
    public class Mouse : IInput<MouseButton>
    {
        public Mouse()
        {
            Update();
        }

		/// <summary>
		/// マウスポインタの座標
		/// </summary>
        public Vector2D Point
        {
            get
            {
				DX.GetMousePoint(out int x, out int y);

                return new Vector2D(x, y);
            }

            set
            {
                DX.SetMousePoint(value.X, value.Y);
            }
        }

		/// <summary>
		/// 押され始めたか[F -> T]
		/// </summary>
        public bool IsDown(MouseButton button)
        {
            return (mouseState[prev] & button.ToCode()) == 0
                && (mouseState[flip] & button.ToCode()) != 0;
        }

		/// <summary>
		/// 前の状態によらず、今押されているか[x -> T]
		/// </summary>
        public bool IsPressed(MouseButton button)
        {
            return (mouseState[flip] & button.ToCode()) != 0;
        }

		/// <summary>
		/// 前の状態によらず、今離されているか[x -> F]
		/// </summary>
		public bool IsRelease(MouseButton button)
        {
            return (mouseState[flip] & button.ToCode()) == 0;
        }

		/// <summary>
		/// 押されていて、今離されたか[T -> F]
		/// </summary>
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
        private readonly int[] mouseState = { 0, 0 };
    }
}
