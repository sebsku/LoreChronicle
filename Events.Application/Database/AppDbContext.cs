using Events.Application.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        ;
    }

    // Define your tables here, even if you're not using migrations:
    public DbSet<Event> Events { get; set; }
}