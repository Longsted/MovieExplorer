using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Services;

namespace MovieExplorer.Web.Controllers;

public class MoviesController : Controller
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<IActionResult> ByGenre(int genreId)
    {
        var movies = await _movieService.GetMoviesByGenreAsync(genreId);
        
        return  View(movies);
    }
}