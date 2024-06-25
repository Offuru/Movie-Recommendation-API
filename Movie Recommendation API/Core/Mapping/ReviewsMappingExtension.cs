using Database.Dtos.Request;
using Database.Dtos.Response;
using Database.Entities;
using Database.Repositories;

namespace Core.Mapping
{
    public static class ReviewsMappingExtension
    {
        public static Review ToEntity(this AddReviewRequest payload)
        {
            if (payload == null)
            {
                return null;
            }

            var review = new Review();

            review.UserId = payload.UserId;
            review.MovieId = payload.MovieId;
            review.Comment = payload.Comment;
            review.Rating = payload.Rating;
            review.DateCreated = DateTime.UtcNow;
            review.DateUpdated = DateTime.UtcNow;

            return review;
        }

        public static GetReviewDetailsResponse ToReviewDto(this Review entity)
        {
            if (entity == null)
            {
                return null;
            }

            var result = new GetReviewDetailsResponse();
            result.UserId = entity.UserId;
            result.MovieId = entity.MovieId;
            result.Comment = entity.Comment;
            result.Rating = entity.Rating;

            return result;
        }
    }
}
