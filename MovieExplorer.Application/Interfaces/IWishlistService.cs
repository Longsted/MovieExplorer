using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Application.Interfaces;

public interface IWishlistService
{
    public Task AddAsync(int movieId, string title, string posterUrl, int releaseYear);

    public Task<IReadOnlyCollection<WishlistItem>> GetAllAsync();

    public Task RemoveAsync(int id);

    public Task<bool> ExistsAsync(int movieId);

    public Task RemoveByMovieIdAsync(int movieId);



}