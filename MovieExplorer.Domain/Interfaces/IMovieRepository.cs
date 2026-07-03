using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Models;

namespace MovieExplorer.Domain.Interfaces;

public interface IMovieRepository
{
    Task<PagedMovieResults> GetMoviesByGenreAsync(int genreId, int page);
    
    Task<Movie> GetMovieByIdAsync(int movieId);

    Task<PagedMovieResults> SearchMoviesAsync(string query,int page);




}