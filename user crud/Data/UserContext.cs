using Microsoft.EntityFrameworkCore;
using user_crud.Models;

namespace user_crud.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
