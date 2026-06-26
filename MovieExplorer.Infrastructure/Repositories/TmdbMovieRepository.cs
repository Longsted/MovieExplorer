using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using MovieExplorer.Infrastructure.Dtos;

namespace MovieExplorer.Infrastructure.Repositories;

public class TmdbMovieRepository : IMovieRepository
{
    private readonly HttpClient _httpClient;
    private readonly TmdbOptions _options;

    public TmdbMovieRepository(
        IHttpClientFactory httpClientFactory,
        IOptions<TmdbOptions> options)
    {
        _httpClient = httpClientFactory.CreateClient();
        _options = options.Value;
    }
    
    public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        var url =
            $"{_options.BaseUrl}/discover/movie" +
            $"?api_key={_options.ApiKey}" +
            $"&with_genres={genreId}";

        Console.WriteLine(url);
        var response =
            await _httpClient.GetFromJsonAsync<TmdbMovieResponse>(url);

        if (response == null)
        {
            return [];
        }

        return response.Results.Select(movie => new Movie
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterUrl = movie.PosterPath == null ? string.Empty : $"https://image.tmdb.org/t/p/w500{movie.PosterPath}",
            ReleaseYear = string.IsNullOrWhiteSpace(movie.ReleaseDeate) ? 0 : DateTime.Parse(movie.ReleaseDeate).Year
            
        }).ToList();
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