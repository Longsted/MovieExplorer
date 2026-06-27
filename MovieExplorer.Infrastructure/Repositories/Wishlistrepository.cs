using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MovieExplorer.Infrastructure.Data;

namespace MovieExplorer.Infrastructure.Repositories;

public class Wishlistrepository : IWishlistRepository
{
    private readonly AppDbContext _dbContext;
    
    public Wishlistrepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(WishlistItem item)
    {
       await _dbContext.WishlistItems.AddAsync(item);
       await _dbContext.SaveChangesAsync();
    }

    public Task<List<WishlistItem>> GetAllAsync()
    {
        var  items = _dbContext.WishlistItems.ToList();
        return Task.FromResult(items);
    }

    public async Task RemoveAsync(int id)
    {
        var item = _dbContext.WishlistItems.Find(id);
        if (item == null)
        {
            return;
        }
        
        _dbContext.WishlistItems.Remove(item);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int movieId)
    {
        return await _dbContext.WishlistItems.AnyAsync(item => item.MovieId == movieId);
    }
}