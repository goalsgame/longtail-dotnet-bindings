﻿using System.Runtime.InteropServices;

namespace Longtail;
internal partial class LongtailLibrary
{
    // NOTE(Jens): since the DLL will be pre-built this will only work in a dev setup with the source code. We need a way to decide which dll to load based on a bool
#if DEBUG
    private const string DllNameWindows = "longtail_win32_x64_debug.dll";
    private const string DllNameLinux = "longtail_linux_x64_debug.so";
    private const string DllNameOsx = "longtail_darwin_arm64_debug.so";
#else
    private const string DllNameWindows = "longtail_win32_x64.dll";
    private const string DllNameLinux = "longtail_linux_x64.so";
    private const string DllNameOsx = "longtail_darwin_arm64.so";
#endif

    static LongtailLibrary()
    {
        NativeLibrary.SetDllImportResolver(typeof(LongtailLibrary).Assembly, (name, assembly, path) =>
        {
            if (name != DllName)
            {
                return IntPtr.Zero;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return LoadLibrary(DllNameOsx);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return LoadLibrary(DllNameWindows);
            }

            return LoadLibrary(DllNameLinux);

            nint LoadLibrary(string dllName) => NativeLibrary.Load(dllName, assembly, path);
        });
    }
}