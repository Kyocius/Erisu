using Erisu.Model;
using Newtonsoft.Json;

namespace Erisu.Service.Network.API;

public class Mcbbs : BaseApi
{
    public Mcbbs()
    {
        Url = "https://download.mcbbs.net";
        VersionManifest = $"{Url}/mc/game/version_manifest.json";
        Assets = $"{Url}/assets";
        Libraries = $"{Url}/maven";
    }

    public override async Task<VersionManifestModel> GetLatestVersion()
    {
        using var res  = await HttpHelper.HttpGetAsync(this.VersionManifest);

        var model = JsonConvert.DeserializeObject<VersionManifestModel>(await res.Content.ReadAsStringAsync());

        var list = model.Versions.ToList();

        for (int i = 0; i < list.Count; i++)
            list[i].Url = list[i].Url.Replace("https://launchermeta.mojang.com", Url);
        
        model.Versions = list;
        return model;
    }
}

