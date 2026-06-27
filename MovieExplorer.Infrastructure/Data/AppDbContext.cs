using Microsoft.EntityFrameworkCore;
using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
}