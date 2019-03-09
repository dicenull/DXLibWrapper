using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibUtilities;
using System.Drawing;
using Rectangle = Diagram.Rectangle;

namespace DiceVsYosanoReMake
{
    class MainScene : SceneBase
    {
        private Rectangle rect;

        public MainScene()
            : base()
        {
            rect = new Rectangle(point: (10, 5), size: (30, 30));
        }

        protected override void draw()
        {
            rect.Draw(Color.Gray);
            rect.DrawFrame(Color.Red);
        }

        public override SceneBase Update()
        {
            rect.MoveBy(x: 1, y: 0);

            return this;
        }
    }
}
