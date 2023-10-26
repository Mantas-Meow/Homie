using Microsoft.EntityFrameworkCore;

public class HomieDbContext : DbContext
{
    public HomieDbContext(DbContextOptions<HomieDbContext> options) : base(options) { }

    public HomieDbContext() { }
}