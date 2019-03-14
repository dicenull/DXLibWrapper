using DxLibDLL;

// TODO : 別プロジェクトへ分離
public partial class Program
{
    public void Start()
    {
        DX.SetDrawScreen(DX.DX_SCREEN_BACK);
        DX.ChangeWindowMode(DX.TRUE);

        DX.DxLib_Init();

        new Program().Run();

        DX.DxLib_End();
    }

}