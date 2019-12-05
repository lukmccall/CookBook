using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string RecipeId { get; set; }
        
        public ApplicationUser User { get; set; }
        
        public string Body { get; set; }
        
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}