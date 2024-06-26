using Database.Dtos.Common;
using Database.Dtos.Request;
using Database.Dtos.Response;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.QueryExtensions
{
    public static class MovieQueryExtensions
    {
        public static IQueryable<Movie> WhereName(this IQueryable<Movie> query, GetMoviesRequest payload)
        {
            if (payload.Name == null)
                return query;

            query = query.Where(m => m.Name == payload.Name);

            return query;
        }

        public static IQueryable<Movie> WhereRating(this IQueryable<Movie> query, GetMoviesRequest payload)
        {
            if(payload.Rating == null)
                return query;

            query = query.Where(m => m.Rating == Int32.Parse(payload.Rating));

            return query;
        }

        public static IQueryable<Movie> Sort(this IQueryable<Movie> query, SortingCriterionDto sortingCriterion)
        {
            if (sortingCriterion == null)
                return query;

            switch(sortingCriterion.SortingCriterion)
            {
                case Enums.SortingCriterion.ByName:
                    {
                        if (sortingCriterion.SortingOrder == Enums.SortingOrder.Ascending)
                            return query.OrderBy(e => e.Name);
                        else
                            return query.OrderByDescending(e => e.Name);
                    }
                case Enums.SortingCriterion.ByRating:
                    {
                        if (sortingCriterion.SortingOrder == Enums.SortingOrder.Ascending)
                            return query.OrderBy(e => e.Rating);
                        else
                            return query.OrderByDescending(e => e.Rating);
                    }

                default: return query;
            }
        }
    }
}
