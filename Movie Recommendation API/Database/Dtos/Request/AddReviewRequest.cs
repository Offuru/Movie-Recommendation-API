namespace Database.Dtos.Request
{
    public class AddReviewRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
