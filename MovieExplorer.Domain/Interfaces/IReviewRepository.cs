using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Domain.Interfaces;

public interface IReviewRepository
{
    Task AddAsync(Review review);
    
    Task UpdateAsync(Review review);
    
    Task RemoveAsync(int reviewId, string userId);
    
    Task<Review?> GetByMovieAndUserAsync(int movieId, string userId);
    
    Task<IReadOnlyCollection<Review>>GetByMovieAsync(int movieId);
    
}