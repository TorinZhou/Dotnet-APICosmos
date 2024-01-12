using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data;

public class DataContextEF : DbContext
{
    public DbSet<Computer>? Computers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;Trusted_Connection=true;TrustServerCertificate=true", options => options.EnableRetryOnFailure());
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