using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        public ManagementController()
        {
                
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Management endpoint is working");
        }
    }
}
