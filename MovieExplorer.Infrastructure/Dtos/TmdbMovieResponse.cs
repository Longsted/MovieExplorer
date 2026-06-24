using System.Text.Json.Serialization;

namespace MovieExplorer.Infrastructure.Dtos;

public class TmdbMovieResponse
{
    [JsonPropertyName("results")] 
    public List<TmdbMovieDto> Results { get; set; } = [];
}