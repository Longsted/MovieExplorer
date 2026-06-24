using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;

namespace MovieExplorer.Infrastructure.Repositories;

public class TmdbMovieRepository : IMovieRepository
{
    public Task<List<Movie>> GetMoviesByGenreAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Movie> GetMovieByIdAsync(int movieId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetMovieCountByGenreAsync(int genreId)
    {
        throw new NotImplementedException();
    }
}