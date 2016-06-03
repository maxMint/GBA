using System;
using System.Collections.Generic;
using LeagueOfLegends.DAL.Model;

namespace LeagueOfLegends.DAL.Repositories.Sorting
{
    public class EventSorter : Sorter<Event>
    {
        private readonly Dictionary<String, IEntitySorter<Event>> _sorters = new Dictionary<string, IEntitySorter<Event>>
            {
                { "Id_ASC", EntitySorter<Event>.OrderBy(item => item.Id) },
                { "Id_DESC", EntitySorter<Event>.OrderByDescending(item => item.Id) },
                { "Name_ASC", EntitySorter<Event>.OrderBy(item => item.Name)},
                { "Name_DESC", EntitySorter<Event>.OrderByDescending(item => item.Name)},
                { "Date_ASC", EntitySorter<Event>.OrderBy(item => item.Date) },
                { "Date_DESC", EntitySorter<Event>.OrderByDescending(item => item.Date) },
                { "Address_ASC", EntitySorter<Event>.OrderBy(item => item.Address) },
                { "Address_DESC", EntitySorter<Event>.OrderByDescending(item => item.Address) },
                { "Cityr_ASC", EntitySorter<Event>.OrderBy(item => item.City) },
                { "City_DESC", EntitySorter<Event>.OrderByDescending(item => item.City) },
                { "State_ASC", EntitySorter<Event>.OrderBy(item => item.State) },
                { "State_DESC", EntitySorter<Event>.OrderByDescending(item => item.State) }

            };

        protected override Dictionary<string, IEntitySorter<Event>> Sorters
        {
            get { return _sorters; }
        }

        protected override IEntitySorter<Event> DefaultSorter
        {
            get { return EntitySorter<Event>.OrderBy(item => item.Id); }
        }
    }
}