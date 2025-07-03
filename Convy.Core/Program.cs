using SixLabors.ImageSharp;

namespace Convy.Core;

class Program
{
    static void Main(string[] args)
    {
        var img = Image.Load(args[0]);
        var fileName = $"{Path.GetFileNameWithoutExtension(args[0])}.{args[1]}";
        switch (args[1])
        {   
            case "jpg":
                img.SaveAsJpeg(fileName);
                break;
            case "png":
                img.SaveAsPng(fileName);
                break;
            case "webp":
                img.SaveAsWebp(fileName);
                break;
            case "gif":
                img.SaveAsGif(fileName);
                break;
            case "bmp":
                img.SaveAsBmp(fileName);
                break;
            case "tiff":
                img.SaveAsTiff(fileName);
                break;
        }
    }
}