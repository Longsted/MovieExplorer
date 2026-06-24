namespace MovieExplorer.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string Overview { get; set; } = String.Empty;
    
    public string PosterUrl { get; set; } = String.Empty;
    
    public string BackdropUrl { get; set; } = String.Empty;
    
    public int ReleaseYear { get; set; }

    public List<Genre> Genres { get; set; } = [];
    
    public List<string> Actors { get; set; } = [];
    
    public List<string> Directors { get; set; } = [];

}