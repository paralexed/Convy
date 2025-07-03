using Convy.Setup.Utils;

namespace Convy.Setup;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        var consoleUtils = new ConsoleUtils();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        consoleUtils.PrintTextAtMiddle("1. Install");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        consoleUtils.PrintTextAtMiddle("2. Remove");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        consoleUtils.PrintTextAtMiddle("0. Info");
        
        var pressedKey = Console.ReadKey().Key;
        
        Console.Clear();
        
        switch (pressedKey)
        {
            case ConsoleKey.D1:
                RegistryUtils.CreatePathsForImages();
                break;
            case ConsoleKey.D2:
                RegistryUtils.RemoveAllPaths();
                //SystemUtils.RemoveFiles();
                break;
            case ConsoleKey.D0:
                consoleUtils.PrintTextAtMiddle("github.com/paralexed");
                Console.ReadKey();
                break;
        }
    }
}