using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Web.ViewModels;

public class GenreViewModel
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = string.Empty;

    public List<Movie> Movies { get; set; } = [];

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }
}