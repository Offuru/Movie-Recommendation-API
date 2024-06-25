using Core.Mapping;
using Database.Dtos.Request;
using Database.Dtos.Response;
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
        public UsersRepository UsersRepository { get; set; }
        public AuthService AuthService { get; set; }

        public UsersService(AuthService authService, UsersRepository usersRepository) 
        {
            UsersRepository = usersRepository;
            AuthService = authService;
        }


        public void Register(RegisterUserRequest payload)
        {
            if (payload == null)
            {
                return;
            }

            var user = payload.ToEntity();

            var salt = AuthService.GenerateSalt();
            user.Password = AuthService.HashPassword(user.Password, salt);
            user.PasswordSalt = Convert.ToBase64String(salt);

            UsersRepository.AddUser(user);
        }

        public string Login(LoginRequest payload)
        {
            var user = UsersRepository.GetUserByEmail(payload.Email);

            if(AuthService.HashPassword(payload.Password, Convert.FromBase64String(user.PasswordSalt)) == user.Password)
            {

                return AuthService.GetToken(user, user.Role);
            }
            else
            {
                return null;
            }
        }

        public GetUserDetailsResponse GetUserDetailsById(int userId)
        {
            var user = UsersRepository.GetUserById(userId);
            var result = user.ToUserDto();

            return result;
        }

        public void EditUser(int userId, EditUserRequest payload)
        {
            var user = UsersRepository.GetUserById(userId);

            UsersRepository.EditUser(user, payload);
        }

        public void DeleteUser(int userId)
        {
            var user = UsersRepository.GetUserById(userId);

            UsersRepository.DeleteUser(user);
        }
    }
}
