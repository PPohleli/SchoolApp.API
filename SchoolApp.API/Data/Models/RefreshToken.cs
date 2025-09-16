using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.API.Data.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateExpire { get; set; }

        // Foreign Key
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]// not strictly necessary but good practice
        public ApplicationUser User { get; set; }
    }
}
