namespace MovieExplorer.Application.Dtos;

public class ReviewDto
{
    public int Id { get; set; }
    
    public int MovieId { get; set; }

    public string UserName { get; set; } = string.Empty;
    
    public string UserId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; }
}