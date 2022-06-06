using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erisu.Interface;
using Erisu.Service.Local;
using Erisu.Service.Network.API;
using Newtonsoft.Json;

namespace Erisu.Model.Game;

/// <summary>
/// 游戏Library依赖
/// </summary>
public class Library : IDependence
{
    [JsonProperty("downloads")]
    public Downloads Downloads { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    // 为旧式Forge Library提供
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("natives")]
    public Dictionary<string, string> Natives { get; set; }

    [JsonProperty("rules")]
    public IEnumerable<RuleModel> Rules { get; set; }

    // 为旧式Forge Library提供
    [JsonProperty("checksums")]
    public List<string> CheckSums { get; set; }

    // 为旧式Forge Library提供
    [JsonProperty("serverreq")]
    public bool? ServerReq { get; set; }

    // 为旧式Forge Library提供
    [JsonProperty("clientreq")]
    public bool? ClientReq { get; set; }

    /// <summary>
    /// 获取游戏依赖相对于.minecraft/libraries的路径
    /// </summary>
    /// <returns></returns>
    public virtual string GetRelativePath()
    {
        if (this.Name.Contains("@"))
        {
            string[] values = this.Name.Split("@");
            string[] temps = values[0].Split(':');

            return $"{temps[0].Replace(".", PathHelper.slash)}{PathHelper.slash}{temps[1]}{PathHelper.slash}{temps[2]}{PathHelper.slash}{temps[1]}-{temps[2]}.{values[1]}";
        }

        string[] temp = Name.Split(':');

        if (temp.Length == 4)
            return $"{temp[0].Replace(".", PathHelper.slash)}{PathHelper.slash}{temp[1]}{PathHelper.slash}{temp[2]}{PathHelper.slash}{temp[1]}-{temp[2]}-{temp[3]}.jar";

        return $"{temp[0].Replace(".", PathHelper.slash)}{PathHelper.slash}{temp[1]}{PathHelper.slash}{temp[2]}{PathHelper.slash}{temp[1]}-{temp[2]}.jar";
    }

    public virtual HttpDownloadRequest GetDownloadRequest(string root, bool useOriginalUrl)
    {
        string url;

        if (useOriginalUrl && !string.IsNullOrEmpty(this.Downloads?.Artifact.Url))
            url = this.Downloads.Artifact.Url;
        else url = SystemConfiguration.Api != new Mojang() ? $"{SystemConfiguration.Api.Libraries}/{this.GetRelativePath().Replace("\\", "/")}" : this.Url;

        if (useOriginalUrl)
            return new HttpDownloadRequest
            {
                Sha1 = this.Downloads?.Artifact.Sha1,
                Size = this.Downloads?.Artifact.Size,
                Url = url,
                Directory = new FileInfo($"{PathHelper.GetLibrariesFolder(root)}{PathHelper.slash}{this.GetRelativePath()}").Directory,
                FileName = Path.GetFileName(this.GetRelativePath())
            };

        return new HttpDownloadRequest
        {
            Sha1 = this.Downloads?.Artifact.Sha1,
            Size = this.Downloads?.Artifact.Size,
            Url = SystemConfiguration.Api != new Mojang() ? $"{SystemConfiguration.Api.Libraries}/{this.GetRelativePath().Replace("\\", "/")}" : this.Url,
            Directory = new FileInfo($"{PathHelper.GetLibrariesFolder(root)}{PathHelper.slash}{this.GetRelativePath()}").Directory,
            FileName = Path.GetFileName(this.GetRelativePath())
        };
    }

    public virtual HttpDownloadRequest GetDownloadRequest(string root)
    {
        return new HttpDownloadRequest
        {
            Sha1 = this.Downloads?.Artifact.Sha1,
            Size = this.Downloads?.Artifact.Size,
            Url =
            SystemConfiguration.Api != new Mojang()
            ? $"{SystemConfiguration.Api.Libraries}/{this.GetRelativePath().Replace("\\", "/")}"
            : this.Url,
            Directory = new FileInfo($"{PathHelper.GetLibrariesFolder(root)}{PathHelper.slash}{this.GetRelativePath()}").Directory,
            FileName= Path.GetFileName(this.GetRelativePath())
        };
    }
}
