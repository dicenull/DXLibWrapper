using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DxLibUtilities;

namespace DiceVsYosanoReMake
{
    class Program
    {
        static void Main(string[] args)
        {
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

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
