﻿namespace Longtail;

public unsafe class BlockIndex : IDisposable
{
    private Longtail_BlockIndex* _index;
    private readonly bool _owner;
    internal Longtail_BlockIndex* AsPointer() => _index;
    public ulong BlockHash => *_index->m_BlockHash;
    public uint HashIdentifier => *_index->m_HashIdentifier;
    public uint ChunkCount => *_index->m_ChunkCount;
    public uint Tag => *_index->m_Tag;
    public ReadOnlySpan<ulong> ChunkHashes => new(_index->m_ChunkHashes, (int)ChunkCount);
    public ReadOnlySpan<uint> ChunkSizes => new(_index->m_ChunkSizes, (int)ChunkCount);
    internal BlockIndex(Longtail_BlockIndex* index, bool owner = true)
    {
        _index = index;
        _owner = owner;
    }

    public void Dispose()
    {
        if (_index != null && _owner)
        {
            LongtailLibrary.Longtail_Free(_index);
            _index = null;
        }
    }
}