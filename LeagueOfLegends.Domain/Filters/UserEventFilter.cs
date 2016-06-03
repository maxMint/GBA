using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Domain.Filters
{
    public class UserEventFilter : BaseFilter
    {
        public long Userid { get; set; }
    }
}