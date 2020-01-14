using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.API.Responses.RecipesController;
using CookBook.AutoMapperProfiles;
using CookBook.Controllers;
using CookBook.ExternalApi;
using CookBook.Options;
using FluentAssertions;
using logger;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace server_tests.XunitTests.Controllers
{
    public class RecipesControllerTests
    {

        private Mapper _mapper;

        private ApiOptions _options;

        public RecipesControllerTests()
        {
            _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new Mappable())).CreateMapper()
                .ConfigurationProvider);
            _options = new ApiOptions();
            _options.Server = "https://api.spoonacular.com";
            _options.ApiKey = "apiKey=0d0a33fa92c74436ac2a6a799c097a49";
        }

        [Fact]
        public async Task GetRecipePriceBreakdown_OkResult()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient());
            var logger = new LoggerFacade<RawLogger>(new LoggerSettings
            {
                LogLevel = LogLevel.Debug
            });
            var controller = new RecipesController(recipe, _mapper, logger);
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
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient());
            var logger = new LoggerFacade<RawLogger>(new logger.LoggerSettings
            {
                LogLevel = LogLevel.Debug
            });
            var controller = new RecipesController(recipe, _mapper, logger);
            var result = await controller.GetRecipePriceBreakdown(-2);

            result.Should().NotBeNull();
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
            Assert.True(notFoundResult.StatusCode.Equals(404));
        }

        [Fact]
        public async Task GetRecipePriceBreakdown_NotFound2()
        {
            RecipeRepository recipe = new RecipeRepository(_options, new HttpClient());
            var logger = new LoggerFacade<RawLogger>(new logger.LoggerSettings
            {
                LogLevel = LogLevel.Debug
            });
            var controller = new RecipesController(recipe, _mapper, logger);
            var result = await controller.GetRecipePriceBreakdown(0);

            result.Should().NotBeNull();
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
            Assert.True(notFoundResult.StatusCode.Equals(404));
        }

    }
}
