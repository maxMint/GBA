using System.Web;

namespace LeagueOfLegends.Helpers
{
    public static class SessionHelper
    {
        public const string Event = "eventId";

        public static void SetValue(string key, dynamic value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static dynamic GetValue(string key)
        {
            return HttpContext.Current.Session[key];
        }


        public static void Clear(string key)
        {
            HttpContext.Current.Session[key] = null;
        }
    }
}