using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Domain.Interfaces;

public interface IMovieRepository
{
    Task<List<Movie>> GetMoviesByGenreAsync();
    
    Task<Movie> GetMovieByIdAsync(int movieId);

    Task<int> GetMovieCountByGenreAsync(int genreId);
}