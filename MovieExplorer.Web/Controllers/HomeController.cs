using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Services;
using MovieExplorer.Web.Models;

namespace MovieExplorer.Web.Controllers;

public class HomeController : Controller
{
    private readonly MovieService _movieService;
    
    public HomeController(MovieService movieService)
    {
        _movieService = movieService;
    }
    
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetMoviesByGenreAsync(28);
        return Json(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}