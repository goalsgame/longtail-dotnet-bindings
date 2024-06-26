﻿using NUnit.Framework;

namespace Longtail.Tests;

internal class ProgressApiTests
{
    [Test]
    public void Create_CreateAndDispose_DontThrowException()
    {
        Assert.DoesNotThrow(() =>
        {
            using var progressApi = ProgressApi.Create(_ => { });
        });
    }

    [TestCase(0u)]
    [TestCase(6u)]
    [TestCase(uint.MaxValue)]
    public void OnProgress_DoneCount_CallbackWithDoneCount(uint doneCount)
    {
        var result = 0u;
        using var progressApi = ProgressApi.Create(tuple => result = tuple.DoneCount);

        progressApi.OnProgress(0, doneCount);

        Assert.That(result, Is.EqualTo(doneCount));
    }

    [TestCase(0u)]
    [TestCase(6u)]
    [TestCase(uint.MaxValue)]
    public void OnProgress_TotalCount_CallbackWithTotalCount(uint totalCount)
    {
        var result = 0u;
        using var progressApi = ProgressApi.Create(tuple => result = tuple.TotalCount);

        progressApi.OnProgress(totalCount, 0);

        Assert.That(result, Is.EqualTo(totalCount));
    }
}