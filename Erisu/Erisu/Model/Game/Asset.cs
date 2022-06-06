using Erisu.Interface;
using Erisu.Service.Local;

namespace Erisu.Model.Game;

public class Asset : IDependence
{
    public string Hash { get; set; }
    public int Size { get; set; }

    public HttpDownloadRequest GetDownloadRequest(string root)
    {
        return new HttpDownloadRequest()
        {
            Sha1 = Hash,
            Size = Size,
            Url = $"{SystemConfiguration.Api.Assets}/{Hash.Substring(0, 2)}/{this.Hash}",
            Directory = new FileInfo($"{PathHelper.GetAssetsFolder(root)}{PathHelper.slash}{GetRelativePath()}").Directory,
            FileName = Hash
        };
    }
    
    public virtual string GetRelativePath() => 
        $"objects{PathHelper.slash}{this.Hash.Substring(0, 2)}{PathHelper.slash}{this.Hash}";
}