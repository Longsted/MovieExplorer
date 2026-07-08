using Microsoft.EntityFrameworkCore;
using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Infrastructure.External.Dtos;
using MovieExplorer.Infrastructure.Persistence;

namespace MovieExplorer.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ReviewRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Review review)
    {
        await _dbContext.Reviews.AddAsync(review);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
       
        _dbContext.Reviews.Update(review);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int reviewId, string userId)
    { 
        var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId && r.UserId == userId);
        if (review is null)
        {
            return;
        }
        _dbContext.Reviews.Remove(review);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Review?> GetByMovieAndUserAsync(int movieId, string userId)
    {
        
        return await _dbContext.Reviews.FirstOrDefaultAsync(r => r.MovieId == movieId && r.UserId == userId);
    }

    public async Task<IReadOnlyCollection<Review>> GetByMovieAsync(int movieId)
    {
        return await _dbContext.Reviews.Where(r => r.MovieId == movieId).ToListAsync();
    }
    
   
}