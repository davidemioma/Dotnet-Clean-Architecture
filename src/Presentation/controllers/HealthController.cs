using Microsoft.AspNetCore.Mvc;

namespace Presentation.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult CheckHealth() {
            return Ok(new {success = true, message = "Api Running!"});
        }
    }
}