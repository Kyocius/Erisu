﻿using Erisu.Model;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Erisu.Service.Local;

/// <summary>
/// 文件操作帮助类
/// </summary>
public class FileHelper
{
    //用于验证文件的方法
    public static bool FileVerify(FileInfo file, int? size = null, string sha1 = default, string MD5 = default)
    {
        if (!file.Exists)
        {
            throw new FileNotFoundException(file.FullName);
        }

        bool isSizeSame = true, isSha1Same = true, isMD5Same = true;

        if (size.HasValue)
            isSizeSame = file.Length == size;

        if (!string.IsNullOrEmpty(sha1))
            isSha1Same = GetSha1(file).ToLower() == sha1.ToLower();

        if (!string.IsNullOrEmpty(MD5))
            isMD5Same = GetMD5(file).ToLower() == MD5.ToLower();

        return isSizeSame && isSha1Same && isMD5Same;
    }

    /// <summary>
    /// 获取Sha1值
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static string GetSha1(FileInfo file)
    {
        using var fileStream = File.OpenRead(file.FullName);
        using var sha1 = new SHA1CryptoServiceProvider();
        byte[] bytes = sha1.ComputeHash(fileStream);

        return BitConverter.ToString(bytes).Replace("-", "");
    }

    /// <summary>
    /// 获取MD5值
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static string GetMD5(FileInfo file)
    {
        using var fileStream = File.OpenRead(file.FullName);
        using var md5 = new MD5CryptoServiceProvider();
        byte[] bytes = md5.ComputeHash(fileStream);
        
        return BitConverter.ToString(bytes).Replace("-", "");
    }

    public static bool FileVerifyHttpDownload(HttpDownloadRequest request, HttpDownloadResponse response) 
        => FileVerify(response.FileInfo, request.Size, request.Sha1);

    public static string? FindFile(DirectoryInfo directory, string fileName)
    {
        //返回 directory 中所有文件名称
        foreach (var item in directory.GetFiles())
        {
            if (item.Name == fileName)
                return item.FullName;
        }
        //返回 directory 中所有子目录的名称
        foreach (var item in directory.GetDirectories())
            return FindFile(item, fileName);

        return null;
    }

    public static void DeleteAllFiles(DirectoryInfo directory)
    {
        foreach (FileInfo file in directory.GetFiles())
            //删除此文件
            file.Delete();

        directory.GetDirectories().ToList().ForEach(item =>
        {
            DeleteAllFiles(item);
            //删除所有空目录
            item.Delete();
        });
    }
}
