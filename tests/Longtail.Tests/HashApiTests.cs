using System.Text;
using NUnit.Framework;

namespace Longtail.Tests;

internal class HashApiTests
{
    private static readonly byte[] AString = Encoding.UTF8.GetBytes("dont change this string");

    private ulong Blake3Hash = 10551986767028710526;

    [Test]
    public void CreateBlake3HashAPI_OnSuccess_ReturnHashApi()
    {
        var hashType = LongtailLibrary.Longtail_GetBlake3HashType();

        using var hashApi = HashApi.CreateBlake3HashAPI();

        Assert.That(hashApi.GetIdentifier(), Is.EqualTo(hashType));
    }

    [Test]
    public void HashBuffer_Blake3_ReturnHash()
    {
        using var hashApi = HashApi.CreateBlake3HashAPI();

        var result = hashApi.HashBuffer(AString);

        Assert.That(result, Is.EqualTo(Blake3Hash));
    }

    [Test]
    public void Hash_Blake3WithContext_ReturnHash()
    {
        using var hashApi = HashApi.CreateBlake3HashAPI();
        using var context = hashApi.BeginContext();
        context.Hash(AString);

        var result = context.EndContext();

        Assert.That(result, Is.EqualTo(Blake3Hash));
    }
}