using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Student endpoint is working");
        }
    }
}
