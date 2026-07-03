
using MovieExplorer.Domain.Entities;

namespace MovieExplorer.Web.ViewModels;

public class SearchViewModel
{
    public string Query { get; set; } = string.Empty;

    public IReadOnlyCollection<Movie> Movies { get; set; } = [];
    
    public string? ErrorMessage { get; set; }
    
    public  int CurrentPage { get; set; } 
    
    public int TotalPages { get; set; }
    
    public int TotalResults { get; set; }
}