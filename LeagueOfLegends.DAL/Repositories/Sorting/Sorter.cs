using System;
using System.Collections.Generic;
using LeagueOfLegends.Common.List;

namespace LeagueOfLegends.DAL.Repositories.Sorting
{
    public abstract class Sorter<T>
    {
        protected abstract Dictionary<String, IEntitySorter<T>> Sorters { get; }
        protected abstract IEntitySorter<T> DefaultSorter { get; }

        public IEntitySorter<T> GetSorter(SortExpression expression)
        {
            return Sorters.ContainsKey(expression.Key) ? Sorters[expression.Key] : DefaultSorter;
        }
    }
}