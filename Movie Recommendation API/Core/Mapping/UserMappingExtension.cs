using Database.Dtos.Request;
using Database.Dtos.Response;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public static class UserMappingExtension
    {
        public static User ToEntity(this RegisterUserRequest payload)
        {
            if(payload == null)
            {
                return null;
            }

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

            return user;
        }

        public static GetUserDetailsResponse ToUserDto(this User entity)
        {
            if(entity == null) 
            {
                return null;
            }

            var result = new GetUserDetailsResponse();
            result.Name = entity.Name;
            result.FavoriteGenres = entity.FavoriteGenres;
            result.Role = entity.Role;
            result.ReviewIds = entity.Reviews?.Select(r => r.Id).ToList() ?? new List<int>();

            return result;
        }
    }
}
