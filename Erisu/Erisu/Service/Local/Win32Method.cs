using System;
using System.Runtime.InteropServices;

namespace Erisu.Service.Local;

public static class Win32Method
{

    /// <summary>
    /// 改标题栏的 Win32 方法，但是我不太理解...
    /// </summary>
    /// <param name="hWnd">将改变的窗口句柄</param>
    /// <param name="newText">新的标题</param>
    /// <returns></returns>
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowText(IntPtr hWnd, string newText);
}

