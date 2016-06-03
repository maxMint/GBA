using System.Web;
using System.Web.Mvc;
using LeagueOfLegends.Attribute;

namespace LeagueOfLegends
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GeneralExceptionFilterAttribute());
        }
    }
}
