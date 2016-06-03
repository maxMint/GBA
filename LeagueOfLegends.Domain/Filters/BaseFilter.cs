using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Domain.Filters
{
    public abstract class BaseFilter
    {
        public string SearchText { get; set; }
    }
}