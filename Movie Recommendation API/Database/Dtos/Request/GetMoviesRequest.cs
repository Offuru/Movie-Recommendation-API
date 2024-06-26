using Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dtos.Request
{
    public class GetMoviesRequest
    {
        public SortingCriterionDto SortingCriterion { get; set; }
        public string? Name { get; set; }
        public string? Rating { get; set; }

    }
}
