using MovieExplorer.Application.Interfaces;
using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Domain.Models;

namespace MovieExplorer.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<PagedMovieResults> GetMoviesByGenreAsync(int genreId,int page)
    {
        return await _movieRepository.GetMoviesByGenreAsync(genreId,page);
    }

    public async Task<Movie> GetMovieByIdAsync(int movieId)
    {
        return await _movieRepository.GetMovieByIdAsync(movieId);
    }

    public async Task<PagedMovieResults> SearchMoviesAsync(string query, int page)
    {
        return await _movieRepository.SearchMoviesAsync(query, page);
    }
}