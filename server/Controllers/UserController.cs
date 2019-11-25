using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    [Authorize(Policy = "JWTToken")]
    public class UserController : Controller
    {
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(HttpContext.User.Claims.Single(x => x.Type == "id").Value);
        }
    }
}