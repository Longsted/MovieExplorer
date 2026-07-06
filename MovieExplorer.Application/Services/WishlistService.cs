using MovieExplorer.Application.Interfaces;
using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;

namespace MovieExplorer.Application.Services;

public class WishlistService : IWishlistService
{
    private readonly IWishlistRepository  _wishlistRepository;

    public WishlistService(IWishlistRepository wishlistRepository)
    {
        _wishlistRepository = wishlistRepository;
    }

    public async Task AddAsync(string userId,int movieId, string title, string posterUrl, int releaseYear)
    {
        if (await _wishlistRepository.ExistsAsync(userId,movieId))
        {
            return;
        }

        var item = new WishlistItem
        {
            MovieId = movieId,
            Title = title,
            PosterUrl = posterUrl,
            ReleaseYear = releaseYear,
           UserId = userId
        };
        
        await _wishlistRepository.AddAsync(userId,item);
    }

    public async Task<IReadOnlyCollection<WishlistItem>> GetAllAsync(string userId)
    {
        return await _wishlistRepository.GetAllAsync(userId);
    }

    public async Task RemoveAsync(string userId,int id)
    {
        await _wishlistRepository.RemoveAsync(userId,id);
    }
    public async Task<bool> ExistsAsync(string userId,int movieId)
    {
        return await _wishlistRepository.ExistsAsync(userId,movieId);
    }

    public async Task RemoveByMovieIdAsync(string userId,int movieId)
    {
        await _wishlistRepository.RemoveByMovieAsync(userId,movieId);
    }
}