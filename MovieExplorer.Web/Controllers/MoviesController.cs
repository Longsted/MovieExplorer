using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Services;
using MovieExplorer.Web.ViewModels;

namespace MovieExplorer.Web.Controllers;

public class MoviesController : Controller
{
    private readonly MovieService _movieService;
    private readonly WishlistService _wishlistService;

    public MoviesController(MovieService movieService,
        WishlistService wishlistService)
    {
        _movieService = movieService;
        _wishlistService = wishlistService;
    }

    public async Task<IActionResult> ByGenre(int genreId,int page=1)
    {
        var movies = await _movieService.GetMoviesByGenreAsync(genreId,page);

        var viewmodel = new GenreViewModel
        {
            GenreId = genreId,
            GenreName = "Movies", //indtil jeg henter navn fra TMDB
            Movies = movies,
            CurrentPage = page
        };
     
    
        
        return  View(viewmodel);
    }

    public async Task<IActionResult> Details(int movieId)
    {
        var movie = await _movieService.GetMovieByIdAsync(movieId);
        
        
        var viewModel = new MovieDetailsViewModel
        {
            MovieId =  movie.Id,
            Title = movie.Title,
            ReleaseYear = movie.ReleaseYear,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            Genres = movie.Genres
                .Select(g => g.Name)
                .ToList(),
            BackdropUrl = movie.BackdropUrl,
            
            IsInWishlist = await _wishlistService.ExistsAsync(movie.Id)
            
        };
        
        return View(viewModel);
    }

    public async Task<IActionResult> LoadMore(int genreId, int page)
    {
        var movies = await _movieService.GetMoviesByGenreAsync(genreId,page);
      
        return PartialView("_MovieCards", movies);
    }
}