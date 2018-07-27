using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DxLibUtilities;
using Diagram;
using System.Numerics;

namespace DiceVsYosanoReMake
{
    class Program
    {
        static void Main(string[] args)
        {
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ChangeWindowMode(DX.TRUE);

            DX.DxLib_Init();
            
            System.Drawing.Point point = new System.Drawing.Point(10);
            
            Rect rect = new Rect(new Vector2(1, 1), )
            
            SceneManager sceneManager = new SceneManager(new MainScene());
            
            while(DX.ProcessMessage() != -1)
            {
                DX.ClearDrawScreen();
                


                DX.ScreenFlip();
            }

            DX.DxLib_End();
        }
    }
}
