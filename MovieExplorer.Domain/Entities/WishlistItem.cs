namespace MovieExplorer.Domain.Entities;

public class WishlistItem
{
    public int MovieId { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string PosterUrl { get; set; } = String.Empty;
}