using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using MovieExplorer.Domain.Entities;
using MovieExplorer.Domain.Interfaces;
using MovieExplorer.Infrastructure.Dtos;

namespace MovieExplorer.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    
        private readonly HttpClient _httpClient;
        private readonly TmdbOptions _options;

        public GenreRepository(
            IHttpClientFactory httpClientFactory,
            IOptions<TmdbOptions> options)
        {
            _httpClient = httpClientFactory.CreateClient();
            _options = options.Value;
        }

      

        public async Task<List<Genre>> GetGenreAsync()
        {
            var url = 
            $"{_options.BaseUrl}/genre/movie/list" + 
            $"?api_key={_options.ApiKey}";

            var response =
                await _httpClient.GetFromJsonAsync<TmdbGenreResponse>(url);

            if (response == null)
            {
                return [];
            }

            return response.Genres.Select(g => new Genre
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }
}
    