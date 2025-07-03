namespace Convy.Setup.Utils;

public class ConsoleUtils
{
    public void PrintTextAtMiddle(string text)
    {
        Console.SetCursorPosition((Console.WindowWidth - text.Length)/2, Console.CursorTop);
        Console.WriteLine(text);
    }
}