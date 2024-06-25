namespace Database.Dtos.Request
{
    public class EditMovieRequest
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public List<string> Genres { get; set; }
    }
}
