using MovieExplorer.Application.Dtos;

namespace MovieExplorer.Application.Interfaces;

public interface IReviewService
{
    Task AddAsync(string userId, int movieId, string title, string content, int rating);
    
    Task UpdateAsync(string userId, int movieId, string title, string content, int rating);
    
    Task RemoveAsync(string userId,int reviewId);

    Task<ReviewDto?> GetByMovieAndUserAsync(int movieId, string userId);
    
    Task<IReadOnlyCollection<ReviewDto>> GetByMovieAsync(int movieId);
}