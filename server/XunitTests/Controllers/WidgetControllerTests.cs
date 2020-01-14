using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.API.Responses.WidgetController;
using CookBook.AutoMapperProfiles;
using CookBook.Controllers;
using CookBook.ExternalApi;
using CookBook.Options;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class WidgetControllerTests
{
    private Mapper _mapper;
    private ApiOptions _options;

    public WidgetControllerTests()
    {
        _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new Mappable())).CreateMapper().ConfigurationProvider);
        _options = new ApiOptions();
        _options.Server = "https://api.spoonacular.com";
        _options.ApiKey = "apiKey=0d0a33fa92c74436ac2a6a799c097a49";
    }

    [Fact]
    public async Task RecipeVisualization_okResult()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.RecipeVisualization(12);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(200));
        var model = okResult.Value.Should().BeAssignableTo<WidgetResponse>().Subject;
        Assert.False(model.DefaultCss.Equals(null));
        Assert.True(model.Code.Length > 0);
    }

    [Fact]
    public async Task RecipeVisualization_notFound()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.RecipeVisualization(-1);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<NotFoundResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(404));
    }

    [Fact]
    public async Task EquipmentVisualization_okResult()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.EquipmentVisualization(12);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(200));
        var model = okResult.Value.Should().BeAssignableTo<WidgetResponse>().Subject;
        Assert.False(model.DefaultCss.Equals(null));
        Assert.True(model.Code.Length > 0);
    }

    [Fact]
    public async Task EquipmentVisualization_notFound()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.EquipmentVisualization(-1);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<NotFoundResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(404));
    }

    [Fact]
    public async Task PriceBreakdownVisualization_okResult()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.PriceBreakdownVisualization(12);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(200));
        var model = okResult.Value.Should().BeAssignableTo<WidgetResponse>().Subject;
        Assert.False(model.DefaultCss.Equals(null));
        Assert.True(model.Code.Length > 0);
    }

    [Fact]
    public async Task PriceBreakdownVisualization_notFound()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.PriceBreakdownVisualization(-1);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<NotFoundResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(404));
    }

    [Fact]
    public async Task NutrionVisualization_okResult()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.NutrionVisualization(12);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(200));
        var model = okResult.Value.Should().BeAssignableTo<WidgetResponse>().Subject;
        Assert.False(model.DefaultCss.Equals(null));
        Assert.True(model.Code.Length > 0);
    }

    [Fact]
    public async Task NutrionVisualization_notFound()
    {
        var repository = new WidgetRepository(_options, new HttpClient());
        var controller = new WidgetsController(repository, _mapper);

        var result = await controller.NutrionVisualization(-1);

        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<NotFoundResult>().Subject;
        Assert.True(okResult.StatusCode.Equals(404));
    }


}