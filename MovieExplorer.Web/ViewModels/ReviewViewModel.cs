using System.ComponentModel.DataAnnotations;

namespace MovieExplorer.Web.ViewModels;

public class ReviewViewModel
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public string Username { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string Content { get; set; } = string.Empty;

    [Range(1,5)]
    public int Rating { get; set; }

    public bool IsOwner { get; set; }
}