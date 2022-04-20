using Erisu.Service.Network.API;
using System;
using System.Runtime.InteropServices;


namespace Erisu.Service.Local;

public class SystemConfiguration
{   
    //系统架构
    public static string Architecture { get => Environment.Is64BitOperatingSystem ? "64" : "32"; }

    //操作系统
    public static OSPlatform Platform
    {
        get
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return OSPlatform.Windows;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return OSPlatform.Linux;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OSPlatform.OSX;
            return OSPlatform.Create("Unkown")
        }
    }

    public static string PlatformName
    {
        get
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "Windows";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "Linux";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "OSX";
            return "Unkown";
        }
    }

    public static BaseApi Api { get; set; } = new Mcbbs();
}
