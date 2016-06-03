using System;
using System.Security.Policy;
using System.Web.Mvc;
using System.Web.Routing;
using LeagueOfLegends.BLL.Services;
using LeagueOfLegends.Common;
using LeagueOfLegends.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;

namespace LeagueOfLegends.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [Dependency]
        public IEventService EventService { get; set; }

        public ActionResult Index()
        {
            return View(EventService.Get(1));
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Rules()
        {

            return View();
        }

        public ActionResult Join(long eventId)
        {
            if (User.Identity.IsAuthenticated)
            {
                UserService.AddEvent(User.Identity.GetUserId<long>(), eventId);
                return Json(new OperationResult(true, string.Empty));
            }
            SessionHelper.SetValue(SessionHelper.Event, eventId);
            return Json(new OperationResult {Success = false, Url = Url.Action("Login", "Account")});
        }
    }
}