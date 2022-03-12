namespace Erisu.Service.Network.API;

public class Mojang : BaseApi
{
    public Mojang()
    {
        Url = "https://launcher.mojang.com";
        VersionManifest = "http://launchermeta.mojang.com/mc/game/version_manifest.json";
        Assets = "http://resources.download.minecraft.net";
        Libraries = "https://libraries.minecraft.net";
    }
}