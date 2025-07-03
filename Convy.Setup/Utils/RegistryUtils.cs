using Microsoft.Win32;

#pragma warning disable CA1416

namespace Convy.Setup.Utils;

public static class RegistryUtils
{
    private const string Path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell";
    public static void CreatePathsForImages()
    {
        foreach (var format in SystemUtils.SupportedFormats)
        {
            Registry.LocalMachine.CreateSubKey(@$"{Path}\Convy.{format}")
                .SetValue("", format.ToUpper());
            Registry.LocalMachine.CreateSubKey(@$"{Path}\Convy.{format}\command")
                .SetValue("", SystemUtils.GetConvyPath() + "\\Convy.Core.exe" + " \"%1\"" + $" {format}");;
        }

        foreach (var format in SystemUtils.SupportedFormats)
        {
            var subKey = Registry.ClassesRoot.CreateSubKey($@"SystemFileAssociations\.{format}\Shell\Convy");
            subKey.SetValue("MUIVerb", "Конвертация в...");
            string temporary = "";
            foreach (var extension in SystemUtils.SupportedFormats)
            {
                temporary += $"Convy.{extension};";
            }
            subKey.SetValue("SubCommands", temporary);
        }
    }

    public static void RemoveAllPaths()
    {
        foreach (var format in SystemUtils.SupportedFormats)
        {
            Registry.LocalMachine.DeleteSubKey(@$"{Path}\Convy.{format}\command", false);
            Registry.LocalMachine.DeleteSubKey(@$"{Path}\Convy.{format}", false);
            Registry.ClassesRoot.DeleteSubKey($@"SystemFileAssociations\.{format}\Shell\Convy", false);
        }
    }
}