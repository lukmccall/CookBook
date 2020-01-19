using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CookBook.API.Responses.CommentsController;
using CookBook.Attributes;

namespace CookBook.Domain
{
    [Mappable(To = typeof(CommentsResponse))]
    public class Comment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long RecipeId { get; set; }

        public ApplicationUser User { get; set; }

        public string Body { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

    }
}
