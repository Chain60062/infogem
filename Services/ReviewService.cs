using InfoGem.Dto;
using InfoGem.Models;
using InfoGem.Repositories;
using Microsoft.AspNetCore.Identity;

namespace InfoGem.Services;

public class ReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly UserManager<AppUser> _userManager;
    private static readonly Random random = new Random();
    public ReviewService(IReviewRepository reviewRepository, UserManager<AppUser> userManager)
    {
        _reviewRepository = reviewRepository;
        _userManager = userManager;
    }

    public async Task<IQueryable<Review>?> GetProductReviews(long productId)
    {
        return await _reviewRepository.GetProductReviews(productId);
    }
    public async Task<Review?> GetReviewById(long reviewId)
    {
        return await _reviewRepository.GetReviewById(reviewId);
    }
    public async Task<Review?> CreateReview(ReviewDto reviewDto, string userId)
    {
        var review = InstantiateReview(reviewDto);

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null) return null;

        return await _reviewRepository.CreateNewReview(review, user);
    }
    public async Task<bool> RemoveReviewById(long reviewId, string userId)
    {
        if (string.IsNullOrEmpty(userId)) return false;

        var userGuid = new Guid(userId);

        return await _reviewRepository.RemoveReviewById(reviewId, userGuid);
    }
    public async Task<Review?> UpdateReview(long reviewToUpdateId, string userId, ReviewDto reviewDto)
    {
        var review = InstantiateReview(reviewDto);

        var userGuid = new Guid(userId);

        return await _reviewRepository.UpdateReviewById(reviewToUpdateId, userGuid, review);
    }

    private Review InstantiateReview(ReviewDto reviewDto)
    {
        return new Review()
        {
            Title = reviewDto.Title,
            Text = reviewDto.Text,
        };
    }
}