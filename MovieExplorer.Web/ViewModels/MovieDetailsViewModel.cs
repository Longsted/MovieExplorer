namespace MovieExplorer.Web.ViewModels;

public class MovieDetailsViewModel
{
    public int MovieId { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public string Overview { get; set; } = string.Empty;

    public string PosterUrl { get; set; } = string.Empty;

    public IReadOnlyCollection<string> Genres { get; set; } = [];
    
    public string BackdropUrl { get; set; } = string.Empty;
    
    public bool IsInWishlist { get; set; }
    
    public double  AverageRating { get; set; }
    
    public int ReviewCount { get; set; }
    
    public IReadOnlyCollection<ReviewViewModel> Reviews { get; set; } = [];

    public ReviewViewModel? UserReview { get; set; }
    
    public bool IsAuthenticated { get; set; }
}