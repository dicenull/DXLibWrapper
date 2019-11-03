
namespace DxLogic
{
	/// <summary>
	/// 入力機器の入力をまとめたクラス
	/// </summary>
    public static class DeviceInput
    {
        public static Key Key { get; } = new Key();

        public static Mouse Mouse { get; } = new Mouse();

        public static void Update()
        {
            Key.Update();
            Mouse.Update();
        }
    }
}
