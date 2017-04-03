using AliMine.Models;
using Microsoft.EntityFrameworkCore;

namespace AliMine.Models
{
    public class AliMineContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }



        public AliMineContext(DbContextOptions<AliMineContext> options)
        : base(options)
        {
        }
    }
}