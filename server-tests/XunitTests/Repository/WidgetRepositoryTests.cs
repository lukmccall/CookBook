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

namespace server_tests.XunitTests.Repository
{
    public class WidgetRepositoryTests
    {

        private Mock<HttpClientHandler> _handlerMock;

        private ApiOptions _options;

        public WidgetRepositoryTests()
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
        public void IngredientsById()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new WidgetRepository(_options, httpClient);
            var result = subjectUnderTest.IngredientsById(12, null);

            result.Should().NotBeNull(); // this is fluent assertions here...

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("https://serverTest.com/recipes/12/ingredientWidget?123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2), // we expected a single external request
                ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get // we expected a GET request
                        && req.RequestUri == expectedUri // to this uri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public void EquipmentById()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new WidgetRepository(_options, httpClient);
            var result = subjectUnderTest.EquipmentById(12, null);

            result.Should().NotBeNull(); // this is fluent assertions here...

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("https://serverTest.com/recipes/12/equipmentWidget?123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2), // we expected a single external request
                ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get // we expected a GET request
                        && req.RequestUri == expectedUri // to this uri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public void PriceBreakdownById()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new WidgetRepository(_options, httpClient);
            var result = subjectUnderTest.PriceBreakdownById(12, null);

            result.Should().NotBeNull(); // this is fluent assertions here...

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("https://serverTest.com/recipes/12/priceBreakdownWidget?123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2), // we expected a single external request
                ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get // we expected a GET request
                        && req.RequestUri == expectedUri // to this uri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public void NutrionById()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new WidgetRepository(_options, httpClient);
            var result = subjectUnderTest.NutrionById(12, null);

            result.Should().NotBeNull(); // this is fluent assertions here...

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("https://serverTest.com/recipes/12/nutritionWidget?123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2), // we expected a single external request
                ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get // we expected a GET request
                        && req.RequestUri == expectedUri // to this uri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

    }
}
