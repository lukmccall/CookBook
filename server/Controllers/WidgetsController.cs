using System.Threading.Tasks;
using CookBook.ExternalApi;
using Microsoft.AspNetCore.Mvc;
using CookBook.API;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace CookBook.Controllers
{
    [ApiController]
    public class WidgetsController : Controller
    {
        private readonly IWidgetRepository _widgetRepo;

        public WidgetsController(IWidgetRepository widgetRepo)
        {
            _widgetRepo = widgetRepo;
        }

        [HttpGet]
        [Route(Urls.Widget.RecipeVisualization)]
        public async Task<IActionResult> RecipeVisualization(long id, bool? defaultCss = null)
        {
          try {
                var model = await _widgetRepo.IngredientsById(id, defaultCss);
                return Ok(model);
            } catch (Exception e) {
                return new FailRequest(e.GetType(), e.Message);
            }
        }

        [HttpGet]
        [Route(Urls.Widget.EquipmentVisualization)]
        public async Task<IActionResult> EquipmentVisualization(long id, bool? defaultCss = null)
        {
            try {
                var model = await _widgetRepo.EquipmentbyId(id, defaultCss);
                return Ok(model);
            } catch (Exception e) {
                return new FailRequest(e.GetType(), e.Message);
            }
        }

        [HttpGet]
        [Route(Urls.Widget.PriceBreakDownVisualization)]
        public async Task<IActionResult> PriceBrakdownVisualization(long id, bool? defaultCss = null)
        {
            try {
                var model = await _widgetRepo.PriceBreakdownbyId(id, defaultCss);
                return Ok(model);
            } catch (Exception e) {
                return new FailRequest(e.GetType(), e.Message);
            }
        }

        [HttpGet]
        [Route(Urls.Widget.NutrionVisualization)]
        public async Task<IActionResult> NutrionVisualization(long id, bool? defaultCss = null)
        {
            try {
                var model = await _widgetRepo.NutrionbyId(id, defaultCss);
                return Ok(model);
            } catch (Exception e) {
                return new FailRequest(e.GetType(), e.Message);
            }
        }
    }
}