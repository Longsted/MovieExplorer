using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Services;
using MovieExplorer.Web.ViewModels;

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
        
        //midlertidig løsning. henter senere fra genre

        ViewBag.GenreName = "Movies";
        
        return  View(movies);
    }

    public async Task<IActionResult> Details(int movieId)
    {
        var movie = await _movieService.GetMovieByIdAync(movieId);
        
        var viewModel = new MovieDetailsViewModel
        {
            Title = movie.Title,
            ReleaseYear = movie.ReleaseYear,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            Genres = movie.Genres
                .Select(g => g.Name)
                .ToList(),
            BackdropUrl = movie.BackdropUrl
            
        };
        
        return View(viewModel);
    }
}