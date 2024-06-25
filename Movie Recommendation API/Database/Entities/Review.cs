namespace Database.Entities
{
    public class Review : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
