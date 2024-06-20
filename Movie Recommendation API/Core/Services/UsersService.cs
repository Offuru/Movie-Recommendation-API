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
        UsersRepository UsersRepository { get; set; }

        public UsersService(UsersRepository usersRepository) 
        {
            UsersRepository = usersRepository;
        }


        public void Register(RegisterUserRequest payload)
        {
            var user = payload.ToEntity();
            UsersRepository.AddUser(user);
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
