using DxLibUtilities;
using DxLibDLL;
using DxLogic;
using Graphics;
using Utilities;

public class Program
{ 
    public void Run()
    {
        while (DxSystem.Update())
        {
            new Circle(DeviceInput.Mouse.Point, 10).Draw(Palette.Blue);
        }
    }
}