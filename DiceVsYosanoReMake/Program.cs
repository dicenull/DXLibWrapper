using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DxLibUtilities;
using System.Drawing;
using Diagram;

using Rectangle = Diagram.Rectangle;

namespace DiceVsYosanoReMake
{
    class Program
    {
        static void Main(string[] args)
        {
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ChangeWindowMode(DX.TRUE);

            DX.DxLib_Init();

            var rect = new Rectangle(point: (10, 5), size: (30, 30));
            
            while(DX.ProcessMessage() != -1)
            {
                DX.ClearDrawScreen();

                rect.Draw(Color.Gray);
                rect.DrawFrame(Color.Red);
                rect.MoveBy(x: 1, y: 0);

                DX.ScreenFlip();
            }

            DX.DxLib_End();
        }
    }
}
