using Erisu.Model.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erisu.Service.Local;

public class NativesDecompressor
{
    public string Root { get; set; }
    public string Id { get; set; }
    
    public NativesDecompressor(string root, string id)
    {
        Root = root; 
        Id = id;
    }

    public void Decompress(IEnumerable<Native> natives, string nativesFolder = default)
    {
        nativesFolder = string.IsNullOrEmpty(nativesFolder) ? $"{PathHelper.GetVersionsFolder(Root, Id)}{PathHelper.slash}natives" : nativesFolder;
        //TODO(还没写完，鸽一波)
    }
}