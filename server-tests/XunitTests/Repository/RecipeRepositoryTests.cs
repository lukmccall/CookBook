using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CookBook.ExternalApi;
using CookBook.Options;
using CookBook.Services;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

namespace server_tests.XunitTests.Repository
{
    public class RecipeRepositoryTests
    {

        private Mock<HttpClientHandler> _handlerMock;

        private ApiOptions _options;

        private Mock<ICacheService> _cacheServiceMock = new Mock<ICacheService>();

        public RecipeRepositoryTests()
        {
            _handlerMock = new Mock<HttpClientHandler>();
            _handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                })
                .Verifiable();


            _options = new ApiOptions();
            _options.ApiKey = "123";
            _options.Server = "https://serverTest.com";

            _cacheServiceMock
                .Setup(x => x.HasKeyAsync(It.IsAny<string>()))
                .Returns(new Task<bool>(() => false));

            _cacheServiceMock
                .Setup(x => x.PutStringAsync(It.IsAny<string>(), It.IsAny<TimeSpan>(), It.IsAny<string>()))
                .Verifiable();
        }

        [Fact]
        public void GetRecipePriceBreakdown()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new RecipeRepository(_options, httpClient, _cacheServiceMock.Object);
            var result = subjectUnderTest.GetRecipePriceBreakdown(12);

            result.Should().NotBeNull();

            var expectedUri = new Uri("https://serverTest.com/recipes/12/priceBreakdownWidget.json?123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri == expectedUri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public void GetRecipeIngredientsById()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new RecipeRepository(_options, httpClient, _cacheServiceMock.Object);
            var result = subjectUnderTest.GetRecipeIngredientsById(12);

            result.Should().NotBeNull();

            var expectedUri = new Uri("https://serverTest.com/recipes/12/ingredientWidget.json?123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri == expectedUri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public void FindRecipeByIngredients()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new RecipeRepository(_options, httpClient, _cacheServiceMock.Object);

            IngredientsQuery ingredients = new IngredientsQuery()
            {
                Ingredients = new List<string>
                {
                    "apples", "flour", "sugar"
                }
            };

            var result = subjectUnderTest.FindRecipeByIngredients(ingredients);

            result.Should().NotBeNull();

            var expectedUri =
                new Uri(
                    "https://serverTest.com/recipes/findByIngredients?ingredients=apples,+flour,+sugar&number=25&123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri == expectedUri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public void GetAnalyzedRecipeInstructions()
        {
            var httpClient = new HttpClient(_handlerMock.Object);
            var subjectUnderTest = new RecipeRepository(_options, httpClient, _cacheServiceMock.Object);

            var result = subjectUnderTest.GetAnalyzedRecipeInstructions(12, null);

            result.Should().NotBeNull();

            var expectedUri = new Uri("https://serverTest.com/recipes/12/analyzedInstructions?123");

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri == expectedUri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

    }
}
