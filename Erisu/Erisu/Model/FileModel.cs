using Newtonsoft.Json;

namespace Erisu.Model;

/// <summary>
/// 文件信息模型
/// </summary>
public record class FileModel
{
    [JsonProperty("path")]
    public string Path { get; set; }

    [JsonProperty("sha1")]
    public string Sha1 { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    //for client-x.xx.xml
    [JsonProperty("id")]
    public string Id { get; set; }
}


