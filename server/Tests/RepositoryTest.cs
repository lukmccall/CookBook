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
using CookBook.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CookBook.API.Responses.RecipesController;
using Microsoft.Extensions.Configuration;
using CookBook.AutoMapperProfiles;


//TODO caly folder Tests do wywalenia

public class RepositoryTest
{
    [Fact]
    public async Task GetSh()
    {
        var configurationProvider = new MapperConfiguration(mc => mc.AddProfile(new Mappable())).CreateMapper().ConfigurationProvider;

        // var configurationProvider = new Mock<IConfigurationProvider>();
        // var myProfile = new Mappable();
        // var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        // IMapper mapper = new Mapper(configuration);

        var options = new ApiOptions();
        options.Server = "https://api.spoonacular.com";
        options.ApiKey = "apiKey=0d0a33fa92c74436ac2a6a799c097a49";

        RecipeRepository recipe = new RecipeRepository(options, new HttpClient());

        var controller = new RecipesController(recipe, new Mapper(configurationProvider));
        var result = await controller.GetRecipePriceBreakdown(12);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        // result.As<OkObjectResult>().Value.Should().BeAssignableTo<RecipesPriceBreakdownResponse>();
        Assert.True(okResult.StatusCode.Equals(200));
        var x = okResult.Value.Should().BeAssignableTo<RecipesPriceBreakdownResponse>().Subject;
        x.TotalCost.Should().Be(new Decimal(700.7));
        x.TotalCostPerServing.Should().Be(new Decimal(58.39));
        x.Ingredients.Should().HaveCount(3);
    }

    private string _recipeBreakDown = "dupa";

}