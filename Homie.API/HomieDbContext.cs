using Homie.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Homie.API
{
    public class HomieDbContext : DbContext
    {
        public HomieDbContext(DbContextOptions<HomieDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set;  }
        public DbSet<Place> Places { get; set; }
        public DbSet<Chore> Chores { get; set;}
    }
}
