using btw_api.Models;
using Microsoft.EntityFrameworkCore;

namespace btw_api.Database
{
    public class BtwApiContext : DbContext
    {
        public BtwApiContext(DbContextOptions<BtwApiContext> options)
            : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
