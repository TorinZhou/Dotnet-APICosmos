using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data;

public class DataContextEF : DbContext
{
    private IConfiguration _config;
    public DataContextEF(IConfiguration config)
    {
        _config = config;
    }

    public DbSet<Computer>? Computers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.HasDefaultSchema("TutorialAppSchema");

        modelBuilder.Entity<Computer>()
            .ToTable("Computers", "TutorialAppSchema")
            .HasKey(p => p.ComputerId);
        // base.OnModelCreating(modelBuilder);
    }
}