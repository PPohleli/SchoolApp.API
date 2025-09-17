using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.API.Data.Helpers;

namespace SchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Manager)]
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
