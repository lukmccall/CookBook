
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CookBook.ExternalApi;
using CookBook.Options;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

public class RecipeRepositoryTests
{
    private Mock<HttpClientHandler> _handlerMock;
    private ApiOptions _options;

    public RecipeRepositoryTests()
    {
        _handlerMock = new Mock<HttpClientHandler>();
        _handlerMock
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


        _options = new ApiOptions();
        _options.ApiKey = "123";
        _options.Server = "https://serverTest.com";
    }

    [Fact]
    public void GetRecipePriceBreakdown()
    {
        var httpClient = new HttpClient(_handlerMock.Object);
        var subjectUnderTest = new RecipeRepository(_options, httpClient);
        var result = subjectUnderTest.GetRecipePriceBreakdown(12);

        // ASSERT
        result.Should().NotBeNull(); // this is fluent assertions here...

        // also check the 'http' call was like we expected it
        var expectedUri = new Uri("https://serverTest.com/recipes/12/priceBreakdownWidget.json?123");

        _handlerMock.Protected().Verify(
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