using System.Text.Json.Serialization;

namespace MovieExplorer.Infrastructure.Dtos;

public class TmdbMovieDetailsDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("overview")]
    public string Overview { get; set; } = string.Empty;

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;

    [JsonPropertyName("genres")]
    public List<TmdbGenreDto> Genres { get; set; } = [];
}