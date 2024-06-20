using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dtos.Response
{
    public class GetUserDetailsResponse
    {
        public string Name { get; set; }
        public List<string> FavoriteGenres { get; set; }
        public List<int> ReviewIds { get; set; }
        public string Role { get; set; }
    }
}
