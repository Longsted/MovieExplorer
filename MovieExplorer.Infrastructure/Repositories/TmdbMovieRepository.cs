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
    
    public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId,int page)
    {
        var url =
            $"{_options.BaseUrl}/discover/movie" +
            $"?api_key={_options.ApiKey}" +
            $"&with_genres={genreId}" +
            $"&page={page}";

       
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

    public async Task<Movie> GetMovieByIdAsync(int movieId)
    {
        var url =
            $"{_options.BaseUrl}/movie/{movieId}"+
            $"?api_key={_options.ApiKey}";
        
        var response =
           await _httpClient.GetFromJsonAsync<TmdbMovieDetailsDto>(url);

        if (response == null)
            throw new Exception("movie not found");

        return new Movie
        {
            Id = response.Id,
            Title = response.Title,
            Overview = response.Overview,
            PosterUrl = response.PosterPath == null
                ? string.Empty
                : $"https://image.tmdb.org/t/p/w500{response.PosterPath}",

            BackdropUrl = response.BackdropPath == null
                ? string.Empty
                : $"https://image.tmdb.org/t/p/w500{response.BackdropPath}",

            ReleaseYear = string.IsNullOrWhiteSpace(response.ReleaseDate)
                ? 0
                : DateTime.Parse(response.ReleaseDate).Year,

            Genres = response.Genres.Select(g => new Genre
            {
                Id = g.Id,
                Name = g.Name
            }).ToList()
        };
    }

    public Task<int> GetMovieCountByGenreAsync(int genreId)
    {
        throw new NotImplementedException();
    }
}