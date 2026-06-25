using System.Text.Json.Serialization;

namespace MovieExplorer.Infrastructure.Dtos;

public class TmdbGenreDto
{
    [JsonPropertyName("id")] 
    public int Id { get; set; }

    [JsonPropertyName("name")] 
    public string Name { get; set; } = string.Empty;
}