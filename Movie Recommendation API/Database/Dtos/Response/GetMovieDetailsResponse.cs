using Database.Entities;

namespace Database.Dtos.Response
{
    public class GetMovieDetailsResponse
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public List<string> Genres { get; set; }
        public int Rating { get; set; }
        public int UserRating { get; set; }
        public int CriticRating { get; set; }
        public List<int> ReviewsIds { get; set; }
    }
}
