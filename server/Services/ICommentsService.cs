using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Domain;

namespace CookBook.Services
{
    public interface ICommentsService
    {

        Task<IEnumerable<Comment>> GetAllCommentsAsync(long id);

        Task<bool> AddCommentAsync(long id, ApplicationUser user, string body);

    }
}
