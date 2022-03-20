﻿using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;

namespace Erisu.Service.Local;

public class ZipHelper
{
    public static async Task<string> GetStringFromJsonEntryAsync(ZipArchiveEntry entry)
    {
        using var stream = entry.Open();
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    public static async Task<T> GetObjectFromJsonEntryAsync<T>(ZipArchiveEntry entry) 
        => JsonConvert.DeserializeObject<T>(await GetStringFromJsonEntryAsync(entry));

    public static Task WriteAsync(ZipArchiveEntry entry, string folder, string fileName = default) => Task.Run(delegate
    {
        var file = string.IsNullOrEmpty(fileName)
                ? new FileInfo($"{folder}{PathHelper.slash}{entry.Name}")
                : new FileInfo($"{folder}{PathHelper.slash}{fileName}");

        if (!file.Directory.Exists)
            file.Directory.Create();

        entry.ExtractToFile(file.FullName, true);
    });
}
