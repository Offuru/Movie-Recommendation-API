﻿using Database.Context;
using Database.Dtos.Request;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(MovieRecommendationDbContext dbContext) : base(dbContext) { }

        public void AddUser(User user)
        {
            dbContext.Add(user);
            SaveChanges();
        }

        public void DeleteUser(User user)
        {
            user.DateDeleted = DateTime.UtcNow;
            SaveChanges();
        }

        public void EditUser(User user, EditUserRequest payload)
        {
            user.Name = payload.Name;
            user.Email = payload.Email;
            user.FavoriteGenres = payload.FavoriteGenres;
            
            if(dbContext.Entry(user).State == EntityState.Modified)
            {
                user.DateUpdated = DateTime.UtcNow;
            }

            SaveChanges();
        }

        public User GetUserById(int id)
        {
            var result = dbContext.Users
                .Where(u => u.Id == id)
                .Where(u => u.DateDeleted == null)
                .FirstOrDefault();

            return result;
        }
    }
}
