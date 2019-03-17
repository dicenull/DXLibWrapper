using DxLibDLL;

namespace DxLibUtilities
{
    public enum PlayType
    {
        Normal = DX.DX_PLAYTYPE_NORMAL,
        BackGround = DX.DX_PLAYTYPE_BACK,
        Loop = DX.DX_PLAYTYPE_LOOP
    }

    public class Audio
    {
        int handle;

        public Audio(string path)
        {
            handle = DX.LoadSoundMem(path);
        }

        public void Play(PlayType type = PlayType.Normal)
        {
            DX.PlaySoundMem(handle, (int)type, DX.FALSE);
        }

        public void Stop()
        {
            DX.StopSoundMem(handle);
            DX.SetCurrentPositionSoundMem(0, handle);
        }

        public void Pause()
        {
            DX.StopSoundMem(handle);
        }

        public int Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                DX.ChangeVolumeSoundMem(255 * value / 100, handle);
            }
        }
        private int volume = 100;
    }
}
