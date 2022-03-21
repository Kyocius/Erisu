using Erisu.Model;

namespace Erisu.Interface;

/// <summary>
/// 游戏依赖接口 
/// </summary>
public interface IDependence
{
    /// <summary>
    ///  获取对应游戏依赖的下载请求
    /// </summary>
    /// <param name="root">.minecraft游戏目录</param>
    /// <returns></returns>
    HttpDownloadRequest GetDownloadRequest(string root);

    /// <summary>
    ///  获取游戏以来相对于.minecraft目录的路径
    /// </summary>
    /// <returns></returns>
    string GetRelativePath();
}
