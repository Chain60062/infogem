using InfoGem.Models;

namespace InfoGem.Repositories;
public interface IReviewRepository
{
    public Task<IQueryable<Review>?> GetProductReviews(long productId);
    public Task<Review?> GetReviewById(long reviewId);
    public Task<Review?> CreateNewReview(Review review, AppUser user);
    public Task<bool> RemoveReviewById(long reviewId, Guid userId);
    public Task<Review?> UpdateReviewById(long reviewToBeUpdatedId, Guid userId, Review review);
}
