using System;
using DxLibUtilities;
using Utilities;
using Diagram;
using Rectangle = Diagram.Rectangle;

namespace DXLibWrapper
{
    class MainScene : SceneBase
    {
        private Rectangle rect;
        private Line line;
        private Color color = Palette.Pink;

        public MainScene()
            : base()
        {
            rect = new Rectangle(point: (10, 5), size: (30, 30));
            line = new Line(0, 0, 30, 100);
        }

        protected override void draw()
        {
            rect.Draw(color);
            rect.DrawFrame(Palette.Red);

            line.Draw(Palette.White);
        }

        public override SceneBase Update()
        {
            line.MoveBy(1, 1);
            line.End += new Vector2D(0, 1);

            if(Input.Key.IsDown(ConsoleKey.B))
            {
                color = Palette.Blue;
            }
            else if (Input.Key.IsPressed(ConsoleKey.B))
            {
                color = Palette.Purple;
            }

            if (Input.Mouse.IsPressed(MouseButton.Right))
            {
                color = Palette.Red;
            }


            return this;
        }
    }
}
