using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Domain.Interfaces;

public interface IWishlistRepository
{
    Task AddAsync(string userId,WishlistItem item);

    Task<IReadOnlyCollection<WishlistItem>> GetAllAsync(string userId);

    Task RemoveAsync(string userId,int id);
    
    Task<bool> ExistsAsync(string userId,int id);
    
    Task RemoveByMovieAsync(string userId,int movieId);


}