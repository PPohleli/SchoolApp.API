using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolApp.API.Data;
using SchoolApp.API.Data.Models;
using SchoolApp.API.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace SchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, 
            AppDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody]RegisterVM registerVM)
        {
            //Check if model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide all required fields!");
            }

            //Check if user already exists
            var userExists = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (userExists != null)
            {
                return BadRequest($"User {registerVM.EmailAddress} already exists.");
            }

            //Create new user - if user doesn't exists and model is valid
            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (result.Succeeded)
                return Ok($"User created successfully!");
            return BadRequest($"User could not be created");
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Login([FromBody]LoginVM loginVM)
        {
            //Check if model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide all required fields!");
            }

            //attempt to find user in db
            var userExist = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            //Check if user exists in db
            if (userExist != null && await _userManager.CheckPasswordAsync(userExist, loginVM.Password))
            {
                return Ok($"User logged in successfully!");
            }
            return Unauthorized();
        }

    }
}
