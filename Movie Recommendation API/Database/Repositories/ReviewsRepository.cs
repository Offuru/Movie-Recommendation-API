using Database.Context;
using Database.Dtos.Request;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ReviewsRepository : BaseRepository
    {
        public ReviewsRepository(MovieRecommendationDbContext dbContext) : base(dbContext) { }

        public void AddReview(Review review)
        {
            dbContext.Add(review);
            SaveChanges();
        }

        public void DeleteReview(Review review)
        {
            review.DateDeleted = DateTime.UtcNow;
            SaveChanges();
        }

        public Review GetReviewById(int id)
        {
            var result = dbContext.Reviews
                .Where(r => r.Id == id)
                .Where(r => r.DateDeleted == null)
                .FirstOrDefault();

            return result;
        }
        public void EditReview(Review review, EditReviewRequest payload)
        {
            review.Comment = payload.Comment;
            review.Rating = payload.Rating;

            if (dbContext.Entry(review).State == EntityState.Modified)
            {
                review.DateUpdated = DateTime.UtcNow;
            }

            SaveChanges();
        }
    }
}
