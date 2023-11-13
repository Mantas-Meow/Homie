using Homie.API.Models;
using Homie.Data.Migrations;
using Microsoft.EntityFrameworkCore;

public class HomieDbContext : DbContext
{
    public HomieDbContext(DbContextOptions<HomieDbContext> options) : base(options) { }

    public HomieDbContext() { }

    public DbSet<Chore> Chores { get; set;}
}