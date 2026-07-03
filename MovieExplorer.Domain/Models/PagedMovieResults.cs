using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Domain.Models;

public class PagedMovieResults
{
    public IReadOnlyCollection<Movie> Movies { get; init; } = [];

    public int CurrentPage { get; init; }

    public int TotalPages { get; init; }

    public int TotalResults { get; init; }
}