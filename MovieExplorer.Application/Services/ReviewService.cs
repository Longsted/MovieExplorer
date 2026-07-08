using MovieExplorer.Domain.Entities;
using MovieExplorer.Application.Dtos;
using MovieExplorer.Application.Interfaces;
using MovieExplorer.Domain.Interfaces;

namespace MovieExplorer.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserLookupService _userLookupService;

    public ReviewService(IReviewRepository reviewRepository,IUserLookupService userLookupService)
    {
        _reviewRepository = reviewRepository;
        _userLookupService = userLookupService;
    }


    public async Task AddAsync(
        string userId,
        int movieId,
        string title,
        string content,
        int rating)
    {
        ValidateReview(userId, movieId, title, content, rating);

        var existingReview =
            await _reviewRepository.GetByMovieAndUserAsync(movieId, userId);

        if (existingReview is not null)
            throw new InvalidOperationException("A review already exists for this user and movie.");

        var review = new Review
        {
            MovieId = movieId,
            UserId = userId,
            Title = title,
            Content = content,
            Rating = rating,
            CreatedAt = DateTime.UtcNow
        };

        await _reviewRepository.AddAsync(review);
    }

    public async Task UpdateAsync(string userId, int movieId, string title, string content, int rating)
    {
        var existingReview = await _reviewRepository.GetByMovieAndUserAsync(movieId, userId);
        if (existingReview is null)
        {
            throw new InvalidOperationException("Review not found");
        }
        ValidateReview(userId, movieId, title, content, rating);

        
        existingReview.Title = title;
        existingReview.Content = content;
        existingReview.Rating = rating;
        
        
        await _reviewRepository.UpdateAsync(existingReview);
    }

    public async Task RemoveAsync(string userId, int reviewId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException(nameof(userId));

        if (reviewId <= 0)
            throw new ArgumentOutOfRangeException(nameof(reviewId));
        
        
        await _reviewRepository.RemoveAsync(reviewId,userId);
    }

    public async Task<ReviewDto?> GetByMovieAndUserAsync(int movieId, string userId)
    {
      var review =  await _reviewRepository.GetByMovieAndUserAsync(movieId, userId);

      if (review is null)
      {
          return null;
      }

      var dto = MapToDto(review);
      dto.UserName = await _userLookupService.GetUsernameAsync(review.UserId) ?? "Unknown";

      return dto;
    }

    public async Task<IReadOnlyCollection<ReviewDto>> GetByMovieAsync(int movieId)
    {
        var reviews = await _reviewRepository.GetByMovieAsync(movieId);
        
        var result = new List<ReviewDto>();

        foreach (var review in reviews)
        {
            var dto = MapToDto(review);
            dto.UserName = await _userLookupService.GetUsernameAsync(review.UserId) ?? "Unknown";
            result.Add(dto);
        }

        return result;
    }
    
    private static ReviewDto MapToDto(Review review)
    {
        return new ReviewDto
        {
            Id = review.Id,
            MovieId = review.MovieId,
            UserId = review.UserId,
            Title = review.Title,
            Content = review.Content,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        };
    }
    private static void ValidateReview(
        string userId,
        int movieId,
        string title,
        string content,
        int rating)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        if (movieId <= 0)
            throw new ArgumentOutOfRangeException(nameof(movieId));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty.", nameof(content));

        if (rating < 1 || rating > 5)
            throw new ArgumentOutOfRangeException(nameof(rating));
    }
}