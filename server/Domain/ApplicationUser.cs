using CookBook.API.Responses.CommentsController;
using CookBook.API.Responses.UserController;
using CookBook.Attributes;
using Microsoft.AspNetCore.Identity;

namespace CookBook.Domain
{
    [Mappable(To = typeof(UserResponse))]
    [Mappable(To = typeof(UserNameResponse))]
    public class ApplicationUser : IdentityUser
    {

        public string UserSurname { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

    }
}
