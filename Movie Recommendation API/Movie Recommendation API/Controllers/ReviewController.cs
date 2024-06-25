using API.Controllers;
using Core.Services;
using Database.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Movie_Recommendation_API.Controllers
{
    [Route("api/reviews")]
    public class ReviewController : BaseController
    {
        private ReviewService ReviewService { get; set; }

        public ReviewController(ReviewService reviewService)
        {
            ReviewService = reviewService;
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddReview([FromBody] AddReviewRequest payload)
        {
            ReviewService.AddReview(payload);
            return Ok("Review has been added succesfully");
        }

        [HttpGet]
        [Route("{reviewId}/get-details")]
        public IActionResult GetReviewDetails([FromRoute] int reviewId)
        {
            var result = ReviewService.GetReviewDetailsById(reviewId);
            return Ok(result);
        }

        [HttpPut]
        [Route("{reviewId}/edit")]
        public IActionResult EditReviewDetails([FromRoute] int reviewId, [FromBody] EditReviewRequest payload)
        {
            ReviewService.EditReview(reviewId, payload);
            return Ok("Review has been succesfully edited");
        }

        [HttpDelete]
        [Route("delete-review")]
        public IActionResult DeleteReview([FromQuery] int reviewId)
        {
            ReviewService.DeleteReview(reviewId);
            return Ok("Review has been deleted succesfully");
        }
    }
}
