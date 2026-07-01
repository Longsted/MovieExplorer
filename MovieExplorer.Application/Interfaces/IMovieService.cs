using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Application.Interfaces;

public interface IMovieService
{
    public Task<IReadOnlyCollection<Movie>> GetMoviesByGenreAsync(int genreId, int page);
    
    public Task<Movie> GetMovieByIdAsync(int movieId);

}