using System.Diagnostics;

namespace Convy.Setup.Utils;

public static class SystemUtils
{
    public static readonly string[] SupportedFormats = ["jpg", "png", "webp", "gif", "bmp", "tiff"];
    public static string GetConvyPath()
    {
        string localAppdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return @$"{localAppdata}\Convy";
    }

    public static void RemoveFiles()
    {
        string convyPath = GetConvyPath();
        if (Path.Exists(convyPath))
        {
            Directory.Delete(GetConvyPath());
        }
        //TODO: Doesn`t work, needs to be redone
    }
}