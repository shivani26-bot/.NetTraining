using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Contexts
{
    public class AuthenticationContext:DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
            
        }
        public DbSet<Models.User> Users {  get; set; }
    }
}
