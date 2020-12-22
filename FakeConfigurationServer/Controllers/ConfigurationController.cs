using Microsoft.AspNetCore.Mvc;

namespace FakeConfigurationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        [HttpGet("feature")]
        public IActionResult Feature()
        {
            return Ok(new { Enabled = true});
        }       
    }
}
