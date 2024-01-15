using InfoGem.Data;
using InfoGem.Exceptions;
using InfoGem.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoGem.Repositories;

public class EFReviewRepository : IReviewRepository
{
    private readonly AppDbContext _db;

    public EFReviewRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Review?> CreateNewReview(Review review, AppUser user)
    {
        review.User = user;

        await _db.Reviews.AddAsync(review);

        await _db.SaveChangesAsync();

        return review;
    }

    public async Task<IQueryable<Review>?> GetProductReviews(long productId)
    {
        var product = await _db.Products.FindAsync(productId);

        if (product is null) return null;

        return product.Reviews.AsQueryable();
    }

    public async Task<Review?> GetReviewById(long reviewId) => await _db.Reviews.FindAsync(reviewId);

    public async Task<bool> RemoveReviewById(long reviewId, Guid userId)
    {
        try
        {
            var review = await _db.Reviews.FindAsync(reviewId);

            if (review is null) return false;

            if (review.UserId != userId) throw new("Ação proibída para este usuário.");

            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();

            return true;
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task<Review?> UpdateReviewById(long reviewToBeUpdatedId, Guid userId, Review review)
    {
        if (review.UserId != userId) throw new ForbiddenOperationException("Ação proibída para este usuário.");

        var updatedReview = await _db.Reviews.FindAsync(reviewToBeUpdatedId);

        if (updatedReview is not null)
        {
            updatedReview.Title = review.Title;
            updatedReview.Text = review.Text;

            _db.Update(updatedReview);
            await _db.SaveChangesAsync();
        }

        return updatedReview;
    }
}