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
        public DbSet<ToDoListItem> ToDoListItems { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
