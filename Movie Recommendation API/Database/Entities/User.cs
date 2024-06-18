﻿namespace Database.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public List<string> FavoritesGenres { get; set; }
        public List<Review> Reviews { get; set; }
        public List<string> Role { get; set; }
    }
}
