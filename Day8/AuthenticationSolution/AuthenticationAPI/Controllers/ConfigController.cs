using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult GetConfig()
        {
            return Ok("Test Success");
        }
    }
}
