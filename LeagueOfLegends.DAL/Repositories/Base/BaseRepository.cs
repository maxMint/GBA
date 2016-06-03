using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.DAL.Model;
using LeagueOfLegends.DAL.Repositories.Sorting;
using LeagueOfLegends.Domain;

namespace LeagueOfLegends.DAL.Repositories.Base
{
    public abstract class BaseRepository<T, TDisplay, TDetails> : IRepository<TDisplay, TDetails> where T : class, new() where TDetails : EntityBaseDomain
    {
        protected ApplicationDbContext DbContext { get; set; }

        protected BaseRepository(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public virtual ListResult<TDisplay> GetList(ListCriteria criteria, Object filter)
        {
            var query = DbContext.Set<T>().AsQueryable();
            query = ApplyFilter(query, filter);
            return query.ApplyListCriteria<T, TDisplay>(criteria, Sorter);
        }

        public virtual TDetails Get(long id)
        {
            return Mapper.Map<TDetails>(DbContext.Set<T>().Find(id));
        }

        public virtual List<TDisplay> GetAll()
        {
            return Mapper.Map<List<TDisplay>>(DbContext.Set<T>().ToList());
        }

        public virtual void Upsert(TDetails obj)
        {
            var dbObj = !obj.IsNew ? DbContext.Set<T>().Find(obj.Id) : new T();
            Mapper.Map(obj, dbObj);
            if (obj.IsNew)
            {
                DbContext.Set<T>().Add(dbObj);
            }
            DbContext.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            throw new NotImplementedException();
        }

        protected virtual Sorter<T> Sorter
        {
            get { return null; }
        }

        protected virtual IQueryable<T> ApplyFilter(IQueryable<T> query, object filterObj)
        {
            return query;
        }

    }
}