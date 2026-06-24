using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;

namespace MovieExplorer.Application.Services;

public class MovieService
{
    private readonly IMovieRepository _movieRepository;
    
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        return await _movieRepository.GetMoviesByGenreAsync();
    }

    public async Task<Movie?> GetMovieByIdAync(int movieId)
    {
        return await _movieRepository.GetMovieByIdAsync(movieId);
    }

    public async Task<int> GetMovieCountByGenreAsync(int genreId)
    {
        return await _movieRepository.GetMovieCountByGenreAsync(genreId);
    }
    
    
}