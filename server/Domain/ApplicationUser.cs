using Microsoft.AspNetCore.Identity;

namespace CookBook.Domain
{
    public class ApplicationUser : IdentityUser
    {

        public string UserSurname { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

    }
}
