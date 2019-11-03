using DxLibDLL;

namespace DxLibUtilities
{
    public enum PlayType
    {
        Normal = DX.DX_PLAYTYPE_NORMAL,
        BackGround = DX.DX_PLAYTYPE_BACK,
        Loop = DX.DX_PLAYTYPE_LOOP
    }

	/// <summary>
	/// 音の再生を管理する
	/// </summary>
    public class Audio
    {
        readonly int handle;

		/// <param name="path">音声ファイルのパス</param>
        public Audio(string path)
        {
            handle = DX.LoadSoundMem(path);
        }

		/// <summary>
		/// 登録した音声を再生する
		/// </summary>
		/// <param name="type">再生方法</param>
        public void Play(PlayType type = PlayType.Normal)
        {
            DX.PlaySoundMem(handle, (int)type, DX.FALSE);
        }

		/// <summary>
		/// 音声を停止する ■
		/// </summary>
        public void Stop()
        {
            DX.StopSoundMem(handle);
            DX.SetCurrentPositionSoundMem(0, handle);
        }

		/// <summary>
		/// 音声を一時停止する ||
		/// </summary>
        public void Pause()
        {
            DX.StopSoundMem(handle);
        }

		/// <summary>
		/// 音量[0 - 100]
		/// </summary>
        public int Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                DX.ChangeVolumeSoundMem((int)(255 * (double)value / 100), handle);
            }
        }
        private int volume = 100;
    }
}
