﻿using Erisu.Model;
using System;
using System.Collections.Generic;
namespace Erisu.Service.Network.API;

public class BmclApi : BaseApi
{
    public BmclApi()
    {
        Url = "https://bmclapi2.bangbang93.com";
        VersionManifest = $"{Url}/mc/game/version_manifest.json";
        Assets = $"{Url}/assets";
        Libraries = $"{Url}/maven";
    }

    public override async Task<VersionManifestModel> GetVersionManifest()
    {
        using var res = await HttpHelper.HttpGetAsync(this.VersionManifest);
        var model = Newtonsoft.Json.JsonConvert.DeserializeObject<VersionManifestModel>(await res.Content.ReadAsStringAsync());
        
        var list = model.Versions.ToList();

        for (int i = 0; i < list.Count; i++)
            list[i].Url = list[i].Url.Replace("https://launchermeta.mojang.com", Url);

        model.Versions = list;
        return model;
    }
}

