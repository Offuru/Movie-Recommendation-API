using Database.Context;
using Database.Entities;
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
    }
}
