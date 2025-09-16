﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
                
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to SchoolApp API");
        }
    }
}
