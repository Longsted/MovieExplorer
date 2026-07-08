using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Review>().HasIndex(r => new{r.MovieId, r.UserId}).IsUnique();
    }

    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
    public DbSet<Review>? Reviews => Set<Review>();

}