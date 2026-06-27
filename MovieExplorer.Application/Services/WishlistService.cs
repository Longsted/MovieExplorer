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

    public async Task AddAsync(WishlistItem item)
    {
        if (await _wishlistRepository.ExistsAsync(item.MovieId))
        {
            return;
        }
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
}