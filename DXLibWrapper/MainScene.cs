﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibUtilities;
using System.Drawing;
using Diagram;
using Rectangle = Diagram.Rectangle;

namespace DXLibWrapper
{
    class MainScene : SceneBase
    {
        private Rectangle rect;
        private Line line;
        private Color color = Color.Pink;

        public MainScene()
            : base()
        {
            rect = new Rectangle(point: (10, 5), size: (30, 30));
            line = new Line(0, 0, 30, 100);
        }

        protected override void draw()
        {
            rect.Draw(color);
            rect.DrawFrame(Color.Red);

            line.Draw(Color.White);
        }

        public override SceneBase Update()
        {
            line.MoveBy(1, 1);
            line.End += new Vector2D(0, 1);

            if(InputManager.Key.IsDown(ConsoleKey.B))
            {
                color = Color.Blue;
            }
            else if (InputManager.Key.IsPressed(ConsoleKey.B))
            {
                color = Color.Purple;
            }

            if (InputManager.Mouse.IsPressed(MouseButton.Right))
            {
                color = Color.Red;
            }


            return this;
        }
    }
}
