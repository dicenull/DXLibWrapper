using DxLibDLL;

namespace DXLibWrapper
{
    public class DxMain
    {
        static void Main(string[] args)
        {
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ChangeWindowMode(DX.TRUE);

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
