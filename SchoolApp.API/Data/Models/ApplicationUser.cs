using Microsoft.AspNetCore.Identity;

namespace SchoolApp.API.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties can be added here as needed
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Custom { get; set; }
    }
}
