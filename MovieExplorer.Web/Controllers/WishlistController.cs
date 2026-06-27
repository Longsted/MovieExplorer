using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Services;
using MovieExplorer.Web.ViewModels;

namespace MovieExplorer.Web.Controllers;

public class WishlistController :  Controller
{
    private readonly WishlistService _wishlistService;

    public WishlistController(WishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    public async Task<IActionResult> Index()
    {
        var wishlist = await _wishlistService.GetAllAsync();

        var viewModel = new WishlistViewModel
        {
            Movies = wishlist.Select(movie => new WishlistItemViewModel
            {
                Id = movie.Id,
                MovieId = movie.MovieId,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                ReleaseYear = movie.ReleaseYear
            }).ToList()
        };
        
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddWishlistItem(WishlistItemViewModel model)
    {
        
    }
}