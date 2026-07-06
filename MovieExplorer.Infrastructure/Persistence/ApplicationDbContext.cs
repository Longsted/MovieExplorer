using Microsoft.EntityFrameworkCore;
using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
}