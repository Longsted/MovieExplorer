using System.Text.Json.Serialization;

namespace MovieExplorer.Infrastructure.Dtos;

public class TmdbMovieDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }
}