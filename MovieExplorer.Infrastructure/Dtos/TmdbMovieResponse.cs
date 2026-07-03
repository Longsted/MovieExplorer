using System.Text.Json.Serialization;

namespace MovieExplorer.Infrastructure.Dtos;

public class TmdbMovieResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    
    [JsonPropertyName("results")] 
    public IReadOnlyCollection<TmdbMovieDto> Results { get; set; } = [];
    
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
}