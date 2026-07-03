using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Models;

namespace MovieExplorer.Application.Interfaces;

public interface IMovieService
{
    public Task<PagedMovieResults> GetMoviesByGenreAsync(int genreId, int page);
    
    public Task<Movie> GetMovieByIdAsync(int movieId);

    public Task<PagedMovieResults> SearchMoviesAsync(string query, int page = 1);
}