using CookBook.API.Responses.WidgetController;
using CookBook.Attributes;

namespace CookBook.ExternalApi
{
    [Mappable(To = typeof(WidgetResponse))]
    public class Widget
    {

        public string Code { get; set; }

        public bool DefaultCss { get; set; }

    }
}
