namespace Database.Entities
{
    public class Movie : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public List<string> Genres { get; set; }
        public int Rating { get; set; }
        public int UserRating { get; set; }
        public int CriticRating { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
