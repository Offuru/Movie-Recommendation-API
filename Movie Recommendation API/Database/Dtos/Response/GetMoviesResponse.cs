using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Dtos.Common;
using Database.Entities;

namespace Database.Dtos.Response
{
    public class GetMoviesResponse
    {
        public List<GetMovieDetailsResponse> Movies {  get; set; }
        public int Count { get; set; }
    }
}
