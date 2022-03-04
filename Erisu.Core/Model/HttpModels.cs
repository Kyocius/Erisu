using System.IO;
using System.Net;

namespace Erisu.Model;

/// <summary>
/// 下载请求 Model
/// </summary>
public record class HttpDownloadRequest
{
    /// <summary>
    /// 下载文件存放目录
    /// </summary>
    public DirectoryInfo Directory { get; set; }  
    
    /// <summary>
    /// 下载文件Url
    /// </summary>
    public string Url { get; set; }
    
    /// <summary>
    /// 目标文件大小(仅供验证文件)
    /// </summary>
    public int? Size { get; set; }
    
    public string Sha1 { get; set; }
    
    /// <summary>
    /// 目标文件名(不可指定)
    /// </summary>
    public string FileName { get; set; }
}

/// <summary>
/// 下载返回 Model
/// </summary>
public record class HttpDownloadResponse
{
    /// <summary>
    /// Http返回
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Http状态码
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }
    
    /// <summary>
    /// 下载实际文件
    /// </summary>
    public FileInfo FileInfo { get; set; }
}