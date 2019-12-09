using System.Collections.Generic;

namespace CookBook.ExternalApi.Models
{
    public class StepInstruction
    {
        public IList<Equipment> Equipment { get; set; }
        public IList<Photo> Ingredients { get; set; }
        public long Number { get; set; }      
        public string Step { get; set; }
    }
}