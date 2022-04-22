using System;
using System.Runtime.InteropServices;

namespace Erisu.Service.Local;

public class PathHelper
{
    public static readonly string slash = SystemConfiguration.Platform == OSPlatform.Windows ? "\\" : "/";

    public static string GetVersionsFolder(string root) => $"{root}{slash}versions";
    
    public static string GetVersionFolder(string root, string id) => $"{root}{slash}verisons{slash}{id}";
    
    public static string GetLibrariesFolder(string root) => $"{root}{slash}libraries";
    
    public static string GetAssetsFolder(string root) => $"{root}{slash}assets";
    
    public static string GetAssetIndexFolder(string root) => $"{root}{slash}assets{slash}indexes";
    
    public static string GetLogConfigsFolder(string root) => $"{GetAssetsFolder(root)}{slash}log_configs";
}
