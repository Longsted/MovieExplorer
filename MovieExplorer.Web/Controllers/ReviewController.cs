using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Interfaces;
using MovieExplorer.Infrastructure.Persistence;
using MovieExplorer.Web.ViewModels;

namespace MovieExplorer.Web.Controllers;

[Authorize]
public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;
    private readonly UserManager<ApplicationUser> _userManager;

    public ReviewController(
        IReviewService reviewService,
        UserManager<ApplicationUser> userManager)
    {
        _reviewService = reviewService;
        _userManager = userManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(ReviewViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(
                "Details",
                "Movies",
                new { movieId = model.MovieId });
        }

        var userId = _userManager.GetUserId(User)!;

        await _reviewService.AddAsync(
            userId,
            model.MovieId,
            model.Title,
            model.Content,
            model.Rating);

        return RedirectToAction(
            "Details",
            "Movies",
            new { movieId = model.MovieId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(ReviewViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(
                "Details",
                "Movies",
                new { movieId = model.MovieId });
        }

        var userId = _userManager.GetUserId(User)!;

        await _reviewService.UpdateAsync(
            userId,
            model.MovieId,
            model.Title,
            model.Content,
            model.Rating);

        return RedirectToAction(
            "Details",
            "Movies",
            new { movieId = model.MovieId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int reviewId, int movieId)
    {
        var userId = _userManager.GetUserId(User)!;

        await _reviewService.RemoveAsync(userId, reviewId);

        return RedirectToAction(
            "Details",
            "Movies",
            new { movieId });
    }
}