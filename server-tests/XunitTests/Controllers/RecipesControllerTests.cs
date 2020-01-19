using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.API.Requests.RecipesController;
using CookBook.API.Responses.RecipesController;
using CookBook.AutoMapperProfiles;
using CookBook.Controllers;
using CookBook.ExternalApi;
using CookBook.Options;
using CookBook.Services;
using FluentAssertions;
using logger;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace server_tests.XunitTests.Controllers
{
    public class RecipesControllerTests
    {

        private Mapper _mapper;

        private ApiOptions _options;

        private Mock<ICacheService> _cacheServiceMock = new Mock<ICacheService>();

        private ILogger _logger = new LoggerFacade<RawLogger>(new LoggerSettings
        {
            LogLevel = LogLevel.Info
        });

        public RecipesControllerTests()
        {
            _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new Mappable())).CreateMapper()
                .ConfigurationProvider);
            _options = new ApiOptions();
            _options.Server = "https://api.spoonacular.com";
            _options.ApiKey = "apiKey=0d0a33fa92c74436ac2a6a799c097a49";

            _cacheServiceMock
                .Setup(x => x.HasKeyAsync(It.IsAny<string>()))
                .Returns(new Task<bool>(() => false));
            
            _cacheServiceMock
                .Setup(x=>x.PutStringAsync(It.IsAny<string>(), It.IsAny<TimeSpan>(), It.IsAny<string>()))
                .Verifiable();
        }

        [Fact]
        public async Task GetRecipePriceBreakdown_OkResult()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.GetRecipePriceBreakdown(12);

            result.Should().NotBeNull();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            Assert.True(okResult.StatusCode.Equals(200));
            var model = okResult.Value.Should().BeAssignableTo<RecipesPriceBreakdownResponse>().Subject;
            model.TotalCost.Should().Be(new Decimal(700.7));
            model.TotalCostPerServing.Should().Be(new Decimal(58.39));
            model.Ingredients.Should().HaveCount(3);
        }

        [Fact]
        public async Task GetRecipePriceBreakdown_NotFound()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.GetRecipePriceBreakdown(-2);

            result.Should().NotBeNull();
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
            Assert.True(notFoundResult.StatusCode.Equals(404));
        }

        [Fact]
        public async Task GetRecipePriceBreakdown_NotFound2()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.GetRecipePriceBreakdown(0);

            result.Should().NotBeNull();
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
            Assert.True(notFoundResult.StatusCode.Equals(404));
        }

        [Fact]
        public async Task GetRecipeIngredients_OkResult()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.GetRecipeIngredients(12);

            result.Should().NotBeNull();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            Assert.True(okResult.StatusCode.Equals(200));
            var model = okResult.Value.Should().BeAssignableTo<RecipeIngredientsResponse>().Subject;
            model.Ingredients.Should().HaveCount(4);
        }

        [Fact]
        public async Task GetRecipeIngredients_NotFound()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.GetRecipeIngredients(-2);

            result.Should().NotBeNull();
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
            Assert.True(notFoundResult.StatusCode.Equals(404));
        }

        [Fact]
        public async Task GetRecipeIngredients_NotFound2()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.GetRecipeIngredients(0);

            result.Should().NotBeNull();
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
            Assert.True(notFoundResult.StatusCode.Equals(404));
        }

        [Fact]
        public async Task SearchByIngredients_OkResult()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            IngredientsRequest ingredients = new IngredientsRequest()
            {
                Ingredients = new List<string>
                {
                    "eggs", "milk", "sugar"
                }
            };

            var result = await controller.SearchByIngredients(ingredients);

            result.Should().NotBeNull();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            Assert.True(okResult.StatusCode.Equals(200));
        }

        [Fact]
        public async Task RecipeInstructions_OkResult()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.RecipeInstructions(1, false);

            result.Should().NotBeNull();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        }

        [Fact]
        public async Task RecipeInstructions_OkResult2()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient(), _cacheServiceMock.Object);

            var controller = new RecipesController(recipe, _mapper, _logger);
            var result = await controller.RecipeInstructions(0);

            result.Should().NotBeNull();
            var okObject = result.Should().BeOfType<OkObjectResult>().Subject;
            Assert.True(okObject.StatusCode.Equals(200));
        }

    }
}
