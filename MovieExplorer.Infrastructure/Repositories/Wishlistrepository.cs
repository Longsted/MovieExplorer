using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MovieExplorer.Infrastructure.Persistence;

namespace MovieExplorer.Infrastructure.Repositories;

public class Wishlistrepository : IWishlistRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public Wishlistrepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(string userId,WishlistItem item)
    {
        item.UserId = userId;
        
       await _dbContext.WishlistItems.AddAsync(item);
       await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<WishlistItem>> GetAllAsync(string userId)
    {
        
        var  items = await _dbContext.WishlistItems.Where(item => item.UserId == userId).ToListAsync();
        return items;
    }

    public async Task RemoveAsync(string userId,int id)
    {
        var item = await _dbContext.WishlistItems.FirstOrDefaultAsync(x => x.Id == id &&  x.UserId == userId);
        if (item is null)
        {
            return;
        }
        
        _dbContext.WishlistItems.Remove(item);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string userId,int movieId)
    {
        return await _dbContext.WishlistItems.AnyAsync(item => item.MovieId == movieId && item.UserId == userId);
    }

    public async Task RemoveByMovieAsync(string userId,int movieId)
    {
        var item = await _dbContext.WishlistItems.FirstOrDefaultAsync(item => item.MovieId == movieId && item.UserId == userId);
        if (item is null)
            return;
        
        _dbContext.WishlistItems.Remove(item);
        await _dbContext.SaveChangesAsync();
    }
}