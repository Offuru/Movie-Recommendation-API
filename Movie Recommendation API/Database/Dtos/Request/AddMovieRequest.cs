namespace Database.Dtos.Request
{
    public class AddMovieRequest
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public List<string> Genres { get; set; }
    }
}
