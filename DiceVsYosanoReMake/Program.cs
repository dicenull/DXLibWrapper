using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DxLibUtilities;
using System.Drawing;
using Diagram;

namespace DiceVsYosanoReMake
{
    class Program
    {
        static void Main(string[] args)
        {
            SceneBase scene = new MainScene();

            while(true)
            {
                try
                {
                    scene = scene.Update();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    DX.DxLib_End();
                }

                scene.Draw();
            }
        }
    }
}
