using System;
using CookBook.API.Responses.UserController;

namespace CookBook.API.Responses.CommentsController
{
    public class CommentsResponse
    {

        public long RecipeId { get; set; }

        public UserResponse User { get; set; }

        public string Body { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
