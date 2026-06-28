using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Services;
using MovieExplorer.Domain.Entities;
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(WishlistItemViewModel model)
    {
        
        
        await _wishlistService.AddAsync(model.MovieId, model.Title,model.PosterUrl,model.ReleaseYear);
        return RedirectToAction(
            "Details","Movies",
            new{movieId = model.MovieId});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(int id)
    {
        await _wishlistService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveMovie(int movieId)
    {
        await _wishlistService.RemoveByMovieIdAsync(movieId);

        return RedirectToAction(
            "Details",
            "Movies",
            new { movieId });
    }
}