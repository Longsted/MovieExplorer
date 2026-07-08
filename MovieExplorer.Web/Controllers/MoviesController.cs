using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Application.Dtos;
using MovieExplorer.Application.Interfaces;
using MovieExplorer.Domain.Entities;
using MovieExplorer.Infrastructure.Persistence;
using MovieExplorer.Web.ViewModels;

namespace MovieExplorer.Web.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
    private readonly IWishlistService _wishlistService;
    private readonly IReviewService _reviewService;
    private readonly UserManager<ApplicationUser>  _userManager;

    public MoviesController(IMovieService movieService,
        IWishlistService wishlistService,
        IReviewService reviewService,
        UserManager<ApplicationUser> userManager)
    {
        _movieService = movieService;
        _wishlistService = wishlistService;
        _reviewService = reviewService;
        _userManager =  userManager;
    }

    public async Task<IActionResult> ByGenre(int genreId, int page = 1)
    {
        var result = await _movieService.GetMoviesByGenreAsync(genreId, page);

        var viewModel = new GenreViewModel
        {
            GenreId = genreId,
            GenreName = "Movies", // indtil jeg nosser mig sammen til at hente det direkte fra TMDB
            Movies = result.Movies,
            CurrentPage = result.CurrentPage,
            TotalPages = result.TotalPages,
            TotalResults = result.TotalResults
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Details(int movieId)
    {
        var movie = await _movieService.GetMovieByIdAsync(movieId);

        var isAuthenticated = User.Identity?.IsAuthenticated == true;
        var isInWishlist = false;
        string? userId = null;

        if (isAuthenticated)
        {
            userId = _userManager.GetUserId(User);

            if (!string.IsNullOrEmpty(userId))
            {
                isInWishlist = await _wishlistService.ExistsAsync(userId, movieId);
            }
        }

        var reviews = await _reviewService.GetByMovieAsync(movieId);

        ReviewDto? userReview = null;

        if (!string.IsNullOrEmpty(userId))
        {
            userReview = await _reviewService.GetByMovieAndUserAsync(movieId, userId);
        }

        var viewModel = new MovieDetailsViewModel
        {
            MovieId = movie.Id,
            Title = movie.Title,
            ReleaseYear = movie.ReleaseYear,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            Genres = movie.Genres
                .Select(g => g.Name)
                .ToList(),
            BackdropUrl = movie.BackdropUrl,

            IsAuthenticated = isAuthenticated,
            IsInWishlist = isInWishlist,

            Reviews = reviews
                .Select(r => MapReview(r, userId))
                .ToList(),

            UserReview = userReview is null
                ? null
                : MapReview(userReview, userId),

            ReviewCount = reviews.Count,

            AverageRating = reviews.Any()
                ? reviews.Average(r => r.Rating)
                : 0
        };

        return View(viewModel);
    }

    
    public async Task<IActionResult> LoadMore(int genreId, int page)
    {
        var result = await _movieService.GetMoviesByGenreAsync(genreId, page);

        return PartialView("_MovieCards", result.Movies);
    }
    public async Task<IActionResult> LoadMoreSearch(string query, int page) 
    {
        var result = await _movieService.SearchMoviesAsync(query, page);

        return PartialView("_MovieCards", result.Movies);
    }

    
    
    
    public async Task<IActionResult> Search(string query, int page = 1)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return View(new SearchViewModel
            {
                ErrorMessage = "Please enter a search term.",
                Movies = Array.Empty<Movie>()
            });
        }

        var searchResult = await _movieService.SearchMoviesAsync(query, page);

        var viewModel = new SearchViewModel
        {
            Query = query,
            Movies = searchResult.Movies,
            CurrentPage = searchResult.CurrentPage,
            TotalPages = searchResult.TotalPages,
            TotalResults = searchResult.TotalResults
        };

        return View(viewModel);
    }
    
    private static ReviewViewModel MapReview(
        ReviewDto dto,
        string? currentUserId)
    {
        return new ReviewViewModel
        {
            Id = dto.Id,
            MovieId = dto.MovieId,
            Username = dto.UserName,
            Title = dto.Title,
            Content = dto.Content,
            Rating = dto.Rating,
            CreatedAt = dto.CreatedAt,
            IsOwner = dto.UserId == currentUserId
        };
    }
}