using Database.Dtos.Request;
using Database.Entities;
using Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UsersService
    {
        UsersRepository UsersRepository { get; set; }

        public UsersService(UsersRepository usersRepository) 
        {
            UsersRepository = usersRepository;
        }


        public void Register(RegisterUserRequest payload)
        {

            var user = new User();

            //TODO salt and hash password + role
            user.PasswordSalt = "";
            user.Role = "User";
            user.Name = payload.Name;
            user.Email = payload.Email;
            user.Password = payload.Password;
            user.FavoriteGenres = payload.FavoriteGenres;
            user.Reviews = new List<Review>();
            user.DateCreated = DateTime.UtcNow;
            user.DateUpdated = DateTime.UtcNow;

            UsersRepository.AddUser(user);
        }
    }
}
