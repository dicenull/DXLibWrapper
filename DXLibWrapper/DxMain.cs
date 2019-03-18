using DxLibDLL;
using DxLibUtilities;

namespace DXLibWrapper
{
    public class DxMain
    {
        static void Main(string[] args)
        {
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

            Window.IsWindowMode = true;

            var status = DX.DxLib_Init();
            if(status == -1)
            {
                return;
            }

            new Program().Run();

            DX.DxLib_End();
        }
    }
}
