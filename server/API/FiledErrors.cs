using System.Collections.Generic;

namespace CookBook.API
{
    public class FiledErrors
    {
        public string Field { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}