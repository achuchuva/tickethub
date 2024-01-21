using Microsoft.EntityFrameworkCore;
using tickethub.Models;

public class TickethubContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Order> Orders { get; set; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=tickethub.db");
}