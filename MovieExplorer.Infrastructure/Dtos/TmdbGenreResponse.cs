using System.Text.Json.Serialization;

namespace MovieExplorer.Infrastructure.Dtos;

public class TmdbGenreResponse
{
    [JsonPropertyName("genres")] 
    public List<TmdbGenreDto> Genres { get; set; } = [];
}