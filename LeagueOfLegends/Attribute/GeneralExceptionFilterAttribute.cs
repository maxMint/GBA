using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using LeagueOfLegends.BLL.Helpers;

namespace LeagueOfLegends.Attribute
{
    public class GeneralExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ExceptionHelper.Instance.LogError(filterContext.Exception);
        }
    }
}