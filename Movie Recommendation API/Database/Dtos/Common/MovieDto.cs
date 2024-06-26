using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dtos.Common
{
    public class MovieDto
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public List<string> Genres { get; set; }
        public int Rating { get; set; }
    }
}
