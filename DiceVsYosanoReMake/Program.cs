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
            SceneManager manager = new SceneManager(new MainScene());
            
            while(manager.Update())
            { }
        }
    }
}
