using System.Threading.Tasks;
using AutoMapper;
using CookBook.API;
using CookBook.API.Responses.WidgetController;
using CookBook.ExternalApi;
using logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    [ProducesResponseType(typeof(WidgetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class WidgetsController : BaseExternalApiController
    {

        private readonly IWidgetRepository _widgetRepo;

        public WidgetsController(IWidgetRepository widgetRepo, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _widgetRepo = widgetRepo;
        }

        [HttpGet(Urls.Widget.RecipeVisualization)]
        public async Task<IActionResult> RecipeVisualization(long id, bool? defaultCss = null)
        {
            return await WrapExternalRepositoryCall<Widget, WidgetResponse>(() =>
                _widgetRepo.IngredientsById(id, defaultCss));
        }

        [HttpGet(Urls.Widget.EquipmentVisualization)]
        public async Task<IActionResult> EquipmentVisualization(long id, bool? defaultCss = null)
        {
            return await WrapExternalRepositoryCall<Widget, WidgetResponse>(() =>
                _widgetRepo.EquipmentById(id, defaultCss));
        }

        [HttpGet(Urls.Widget.PriceBreakDownVisualization)]
        public async Task<IActionResult> PriceBreakdownVisualization(long id, bool? defaultCss = null)
        {
            return await WrapExternalRepositoryCall<Widget, WidgetResponse>(() =>
                _widgetRepo.PriceBreakdownById(id, defaultCss));
        }

        [HttpGet(Urls.Widget.NutrionVisualization)]
        public async Task<IActionResult> NutrionVisualization(long id, bool? defaultCss = null)
        {
            return await WrapExternalRepositoryCall<Widget, WidgetResponse>(() =>
                _widgetRepo.NutrionById(id, defaultCss));
        }

    }
}
