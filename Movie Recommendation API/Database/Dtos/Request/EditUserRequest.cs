using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dtos.Request
{
    public class EditUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> FavoriteGenres { get; set; }
    }
}
