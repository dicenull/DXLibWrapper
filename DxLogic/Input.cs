
namespace DxLogic
{
    public static class Input
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
