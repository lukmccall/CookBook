using System;

namespace CookBook.API.Responses.CommentsController
{
    public class CommentsResponse
    {

        public int Id { get; set; }

        public long RecipeId { get; set; }

        public UserNameResponse User { get; set; }

        public string Body { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
