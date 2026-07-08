using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using MovieExplorer.Domain.Models;
using MovieExplorer.Infrastructure.External.Dtos;

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
    
    public async Task<PagedMovieResults> GetMoviesByGenreAsync(int genreId, int page)
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
            return new PagedMovieResults
            {
                Movies = Array.Empty<Movie>()
            };
        }
        return new PagedMovieResults
        {
            Movies = response.Results
                .Select(MapMovie)
                .ToList(),

            CurrentPage = response.Page,
            TotalPages = response.TotalPages,
            TotalResults = response.TotalResults
        };
        

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

 


    public async Task<PagedMovieResults> SearchMoviesAsync(string query, int page)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return new PagedMovieResults
            {
                Movies = Array.Empty<Movie>()
            };

        }
        query= query.Trim();
        query = Uri.EscapeDataString(query);

        var url =
            $"{_options.BaseUrl}/search/movie?query={query}" +
            $"&api_key={_options.ApiKey}" + 
            $"&page={page}";

        var response =
            await _httpClient.GetFromJsonAsync <TmdbMovieResponse>(url);

        if (response == null)
        {
            return new PagedMovieResults
            {
                Movies = Array.Empty<Movie>()
            };
        }
        return new PagedMovieResults
            {
                Movies = response.
                    Results.Select(MapMovie).ToList(),

                CurrentPage = response.Page,
                TotalPages = response.TotalPages,
                TotalResults = response.TotalResults    
            };
        
    }

  private static Movie MapMovie(TmdbMovieDto dto)
    {
        return new Movie
        {
            Id = dto.Id,
            Title = dto.Title,
            PosterUrl = dto.PosterPath == null
                ? string.Empty
                : $"https://image.tmdb.org/t/p/w500{dto.PosterPath}",
            ReleaseYear = string.IsNullOrWhiteSpace(dto.ReleaseDate)
                ? 0
                : DateTime.Parse(dto.ReleaseDate).Year
        };
    }
}