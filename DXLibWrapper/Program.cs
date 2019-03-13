using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DxLibUtilities;
using System.Drawing;
using Diagram;

namespace DXLibWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new SceneManager(new MainScene());
            
            while(manager.Update())
            { }
        }
    }
}
