using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.DAL.Repositories.Sorting;

namespace LeagueOfLegends.DAL.Repositories.Base
{
    /// <summary>
    /// Class provides extension methods for LINQ objects
    /// </summary>
    public static class QuerableExtensions
    {
        /// <summary>
        /// Extension method to apply sorting to the query
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <typeparam name="TDomain">Domain Object Type</typeparam>
        /// <param name="query">Query object</param>
        /// <param name="criteria">Skip and take parameters</param>
        /// <param name="sorter">Sorter</param>
        /// <returns>List of objects</returns>
        public static ListResult<TDomain> ApplyListCriteria<T, TDomain>(this IQueryable<T> query, ListCriteria criteria, Sorter<T> sorter = null)
        {
            if (sorter != null)
            {
                query = criteria.Sorts.Aggregate(query, (current, sort) => sorter.GetSorter(sort).Sort(current));
            }
            return new ListResult<TDomain>
            {
                Total = query.Count(),
                Data = Mapper.Map<List<TDomain>>(criteria.IsValidForPaging ? query.Skip(criteria.Skip).Take(criteria.Take).ToList() : query.ToList()),
            };
        }

    }
}
