using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CookBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserSurname { get; set; }
        
        public int Age { get; set; }
        
        public string Description { get; set; }
    }
}