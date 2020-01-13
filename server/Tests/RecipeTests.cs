using Xunit;
using CookBook.Options;
using Moq;
using CookBook.ExternalApi;
using System.Net.Http;
using Moq.Protected;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using FluentAssertions;
using System;
using CookBook.ExternalApi.Models;

//TODO caly folder Tests do wywalenia
public class RecipeTests
{
    [Fact]
    public void GetSth()
    {
        var options = new ApiOptions();
        options.Server = "https://serverTest.com";
        options.ApiKey = "123";
        // var response = new RecipeRepository(options);

        // var mockHttp = new Mock<HttpMessageHandler>();

        // // // // Setup a respond for the user api (including a wildcard in the URL)
        // // mockHttp.When("https://api.spoonacular.com/recipes/*")
        // //         .Respond("application/json", "{'name' : 'Test McGee'}");

        // var recipe = response.GetRecipePriceBreakdown(12);

        // mockHttp.Verify( x => x.)

        // mockHttp.Verify()

        var handlerMock = new Mock<HttpClientHandler>();
        handlerMock
           .Protected()
           // Setup the PROTECTED method to mock
           .Setup<Task<HttpResponseMessage>>(
              "SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>()
           )
           // prepare the expected response of the mocked http call
           .ReturnsAsync(new HttpResponseMessage()
           {
               StatusCode = HttpStatusCode.OK
           })
           .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object);

        var subjectUnderTest = new RecipeRepository(options, httpClient);

        // ACT
        var result = subjectUnderTest.GetRecipePriceBreakdown(12);

        // ASSERT
        result.Should().NotBeNull(); // this is fluent assertions here...

        // also check the 'http' call was like we expected it
        var expectedUri = new Uri("https://serverTest.com/recipes/12/priceBreakdownWidget.json?123");

        handlerMock.Protected().Verify(
           "SendAsync",
           Times.Exactly(2), // we expected a single external request
           ItExpr.Is<HttpRequestMessage>(req =>
              req.Method == HttpMethod.Get  // we expected a GET request
              && req.RequestUri == expectedUri // to this uri
           ),
           ItExpr.IsAny<CancellationToken>()
        );


    }
}