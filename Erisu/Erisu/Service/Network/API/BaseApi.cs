using Erisu.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Erisu.Service.Network.API;

public abstract class BaseApi
{
    public string Url { get; set; }

    public string VersionsManifest { get; set; }

    public string Assets { get; set; }

    public string Libraries { get; set; }

    public virtual async Task<VersionManifestModel> GetVersionManifest()
    {
        using var res = await HttpHelper.HttpGetAsync(this.VersionsManifest);

        return JsonConvert.DeserializeObject<VersionManifestModel>(await res.Content.ReadAsStringAsync());
    }
}



