using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Application.Interfaces;

public interface IWishlistService
{
    public Task AddAsync(string userId,int movieId, string title, string posterUrl, int releaseYear);

    public Task<IReadOnlyCollection<WishlistItem>> GetAllAsync(string userId);

    public Task RemoveAsync(string userId,int id);

    public Task<bool> ExistsAsync(string userId,int movieId);

    public Task RemoveByMovieIdAsync(string userId,int movieId);



}