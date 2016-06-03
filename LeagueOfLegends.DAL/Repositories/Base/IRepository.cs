using System;
using System.Collections.Generic;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.Domain;

namespace LeagueOfLegends.DAL.Repositories.Base
{

    /// <summary>
    /// Generic repository base interface. 
    /// Provides basic CRUD (Create, Read, Update, Delete) and a couple more methods.
    /// </summary>
    public interface IRepository<TDisplay, TDetails> where TDetails : EntityBaseDomain
    {
        /// <summary>
        /// Reads a filtered list of items with paging and sorting.
        /// </summary>
        /// <param name="criteria">List criteria.</param>
        /// <param name="filter">Filter object</param>
        /// <returns></returns>
        ListResult<TDisplay> GetList(ListCriteria criteria, Object filter);

        /// <summary>
        /// Reads an individual item.
        /// </summary>
        /// <param name="id">The business object's id.</param>
        /// <returns></returns>
        TDetails Get(long id);

        /// <summary>
        /// Get all items.
        /// </summary>
        /// <returns></returns>
        List<TDisplay> GetAll();

        /// <summary>
        /// Inserts/Update a new item.
        /// </summary>
        /// <param name="t">The business object. </param>
        void Upsert(TDetails t);

        /// <summary>
        /// Deletes an item.
        /// </summary>
        /// <param name="id">The business object's id</param>
        void Delete(long id);
    }
}
