using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Domain.Interfaces;

public interface IWishlistRepository
{
    Task AddAsync(WishlistItem item);

    Task<IReadOnlyCollection<WishlistItem>> GetAllAsync();

    Task RemoveAsync(int id);
    
    Task<bool> ExistsAsync(int id);
    
    Task RemoveByMovieAsync(int movieId);


}