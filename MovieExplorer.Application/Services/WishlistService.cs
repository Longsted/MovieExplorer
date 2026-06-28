using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;

namespace MovieExplorer.Application.Services;

public class WishlistService
{
    private readonly IWishlistRepository  _wishlistRepository;

    public WishlistService(IWishlistRepository wishlistRepository)
    {
        _wishlistRepository = wishlistRepository;
    }

    public async Task AddAsync(int movieId, string title, string posterUrl, int releaseYear)
    {
        if (await _wishlistRepository.ExistsAsync(movieId))
        {
            return;
        }

        var item = new WishlistItem
        {
            MovieId = movieId,
            Title = title,
            PosterUrl = posterUrl,
            ReleaseYear = releaseYear
        };
        
        await _wishlistRepository.AddAsync(item);
    }

    public async Task<List<WishlistItem>> GetAllAsync()
    {
        return await _wishlistRepository.GetAllAsync();
    }

    public async Task RemoveAsync(int id)
    {
        await _wishlistRepository.RemoveAsync(id);
    }
    public async Task<bool> ExistsAsync(int movieId)
    {
        return await _wishlistRepository.ExistsAsync(movieId);
    }

    public async Task RemoveByMovieIdAsync(int movieId)
    {
        await _wishlistRepository.RemoveByMovieAsync(movieId);
    }
}