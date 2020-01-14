using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class FailRequestsTests
{
    [Fact]
    public void ExecuteResultAsync()
    {
        Type myType = typeof(String);
        var failReq = new FailRequest(myType, "message");

        var result = failReq.ExecuteResultAsync(new ActionContext());
        result.Should().NotBeNull();
    }
}