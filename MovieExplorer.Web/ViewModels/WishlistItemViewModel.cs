namespace MovieExplorer.Web.ViewModels;

public class WishlistItemViewModel
{
    public int Id { get; set; }
    
    public int MovieId{get;set;}

    public string Title { get; set; } = string.Empty;
    
    public string PosterUrl  { get; set; } = string.Empty;
    
    public int ReleaseYear { get; set; }

    
}