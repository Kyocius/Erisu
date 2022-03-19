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

    public void Decompress()
    {
        //TODO(待实现 Native Model)
    }
}