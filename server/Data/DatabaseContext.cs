using CookBook.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Data
{
    public class DatabaseContext : IdentityDbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<JwtRefreshToken> RefreshTokens { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
