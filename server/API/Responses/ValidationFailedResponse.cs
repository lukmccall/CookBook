using System.Collections.Generic;

namespace CookBook.API.Responses
{
    public class ValidationFailedResponse
    {
        public bool Status => false;
        public List<FiledErrors> Errors { get; set; }
    }
}