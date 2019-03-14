using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using DxLibUtilities;
using System.Drawing;
using Diagram;
using DXLibWrapper;

public partial class Program
{ 
    static void Main(string[] args)
    {
        new Program().Start();
    }

    public void Run()
    {
        var manager = new SceneManager(new MainScene());

        while (manager.Update()) { }
    }
}