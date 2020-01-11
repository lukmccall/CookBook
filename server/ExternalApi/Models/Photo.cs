using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(PhotoResponse))]
    public class Photo
    {

        public long Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

    }
}
