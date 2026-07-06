using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Interfaces;
using MovieExplorer.Web.ViewModels;

//Identity
using Microsoft.AspNetCore.Identity;
using MovieExplorer.Infrastructure.Persistence;

namespace MovieExplorer.Web.Controllers;

[Authorize]
public class WishlistController :  Controller
{
    private readonly IWishlistService _wishlistService;
    private readonly UserManager<ApplicationUser> _userManager;
    private string CurrentUserId => _userManager.GetUserId(User)!;

    public WishlistController(IWishlistService wishlistService,
        UserManager<ApplicationUser> userManager)
    {
        _wishlistService = wishlistService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
       
        var wishlist = await _wishlistService.GetAllAsync(CurrentUserId);

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
        
        await _wishlistService.AddAsync(CurrentUserId,model.MovieId, model.Title,model.PosterUrl,model.ReleaseYear);
        return RedirectToAction(
            "Details","Movies",
            new{movieId = model.MovieId});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(int id)
    {
        
        await _wishlistService.RemoveAsync(CurrentUserId,id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveMovie(int movieId)
    {
        await _wishlistService.RemoveByMovieIdAsync(CurrentUserId,movieId);

        return RedirectToAction(
            "Details",
            "Movies",
            new { movieId });
    }
}