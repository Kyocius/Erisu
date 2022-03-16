using Newtonsoft.Json;
using System.Collections.Generic;

namespace Erisu.Model;

public class VersionManifestModel
{
    [JsonProperty("latest")]
    public Dictionary<string, string> Latest { get; set; }

    [JsonProperty("version")]
    public IEnumerable<VersionManifestItem> Versions { get; set; }
}

