using Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class BaseRepository
    {
        protected MovieRecommendationDbContext dbContext { get; set; }

        public BaseRepository(MovieRecommendationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
