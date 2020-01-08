using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class FailRequest : IActionResult
{

    private readonly string _message;

    private readonly Type _type;

    public FailRequest(Type type, string message)
    {
        _type = type;
        _message = message;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent(_type + ": " + _message)
        };
        return Task.FromResult(response);
    }

}
