using Database.Entities;

namespace Database.Dtos.Response
{
    public class GetReviewDetailsResponse
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
