using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Domain.Interfaces;

public interface IMovieRepository
{
    Task<IReadOnlyCollection<Movie>> GetMoviesByGenreAsync(int genreId, int page);
    
    Task<Movie> GetMovieByIdAsync(int movieId);

    Task<IReadOnlyCollection<Movie>> SearchMoviesAsync(string query);




}