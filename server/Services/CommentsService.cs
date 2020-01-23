using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Data;
using CookBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Services
{
    public class CommentsService : ICommentsService
    {

        private readonly DatabaseContext _dbContext;

        public CommentsService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(long id)
        {
            return await _dbContext.Comments.Where(x => x.RecipeId == id).Include(b => b.User).ToListAsync();
        }

        public async Task<bool> AddCommentAsync(long id, ApplicationUser user, string body)
        {
            await _dbContext.Comments.AddAsync(new Comment
            {
                Body = body,
                User = user,
                RecipeId = id
            });

            return await _dbContext.SaveChangesAsync() > 0;
        }

    }
}
