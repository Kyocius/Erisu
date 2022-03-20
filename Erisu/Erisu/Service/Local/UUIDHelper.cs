using System;
using System.Text;
using System.Security.Cryptography;

namespace Erisu.Service.Local;

public class UUIDHelper
{
    public static Guid FromString(string input)
    {
        using var md5 = MD5.Create();
        return new Guid(md5.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }
}

