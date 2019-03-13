using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibUtilities;
using System.Drawing;
using Diagram;
using Rectangle = Diagram.Rectangle;

namespace DiceVsYosanoReMake
{
    class MainScene : SceneBase
    {
        private Rectangle rect;
        private Line line;

        public MainScene()
            : base()
        {
            rect = new Rectangle(point: (10, 5), size: (30, 30));
            line = new Line(0, 0, 30, 100);
        }

        protected override void draw()
        {
            rect.Draw(Color.Gray);
            rect.DrawFrame(Color.Red);

            line.Draw(Color.White);
        }

        public override SceneBase Update()
        {
            rect.MoveBy(x: 1, y: 0);

            line.MoveBy(1, 1);
            line.End += new Vector2D(0, 1);

            return this;
        }
    }
}
