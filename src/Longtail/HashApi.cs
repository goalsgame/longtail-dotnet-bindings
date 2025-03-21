﻿using Longtail.Internal;

namespace Longtail;

public sealed unsafe class HashApi : IDisposable
{
    private Longtail_HashAPI* _hashApi;
    private readonly bool _owner;
    internal Longtail_HashAPI* AsPointer() => _hashApi;
    public uint GetIdentifier() => LongtailLibrary.Longtail_Hash_GetIdentifier(_hashApi);
    internal HashApi(Longtail_HashAPI* hashApi, bool owner = true)
    {
        _hashApi = hashApi;
        _owner = owner;
    }
    
    public static HashApi CreateBlake3HashAPI()
    {
        var api = LongtailLibrary.Longtail_CreateBlake3HashAPI();
        return api != null ? new HashApi(api) : throw new InvalidOperationException($"{nameof(LongtailLibrary.Longtail_CreateBlake3HashAPI)} returned a null pointer");
    }

    public HashApiContext BeginContext()
    {
        Longtail_HashAPI_Context* context;
        var err = LongtailLibrary.Longtail_Hash_BeginContext(_hashApi, &context);
        if (err != 0)
        {
            throw new LongtailException(nameof(LongtailLibrary.Longtail_Hash_BeginContext), err);
        }
        return context != null ? new HashApiContext(_hashApi, context) : throw new InvalidOperationException($"{nameof(LongtailLibrary.Longtail_Hash_BeginContext)} returned a null pointer");
    }

    public ulong HashBuffer(ReadOnlySpan<byte> data)
    {
        fixed (byte* pdata = data)
        {
            ulong hash;
            var err = LongtailLibrary.Longtail_Hash_HashBuffer(_hashApi, (uint)data.Length, pdata, &hash);
            if (err != 0)
            {
                throw new LongtailException(nameof(LongtailLibrary.Longtail_Hash_HashBuffer), err);
            }
            return hash;
        }
    }

    public void Dispose()
    {
        if (_hashApi != null && _owner)
        {
            LongtailLibrary.Longtail_DisposeAPI((Longtail_API*)_hashApi);
            _hashApi = null;
        }
    }
}