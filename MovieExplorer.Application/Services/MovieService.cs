using MovieExplorer.Application.Interfaces;
using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;

namespace MovieExplorer.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId,int page)
    {
        return await _movieRepository.GetMoviesByGenreAsync(genreId,page);
    }

    public async Task<Movie> GetMovieByIdAsync(int movieId)
    {
        return await _movieRepository.GetMovieByIdAsync(movieId);
    }

    
    
    
}