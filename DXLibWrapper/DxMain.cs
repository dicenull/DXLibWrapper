using DxLibDLL;

namespace DXLibWrapper
{
    public class DxMain
    {
        static void Main(string[] args)
        {
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ChangeWindowMode(DX.TRUE);

            DX.DxLib_Init();

            new Program().Run();

            DX.DxLib_End();
        }
    }
}
