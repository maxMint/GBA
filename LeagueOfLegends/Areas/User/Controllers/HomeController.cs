using System.Web.Mvc;
using AutoMapper;
using LeagueOfLegends.BLL.Services;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.DataTables;
using LeagueOfLegends.Domain.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;

namespace LeagueOfLegends.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        [Dependency]
        public IUserService UserService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUserEvents([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, UserEventFilter filter)
        {
            filter.Userid = User.Identity.GetUserId<long>();
            var result = UserService.GetUserEvents(Mapper.Map<ListCriteria>(requestModel), filter);
            return Json(new DataTablesResponse(requestModel.Draw, result.Data, result.Total, result.Total));
        }

        public ActionResult Account()
        {
            return View(UserService.Get(User.Identity.GetUserId<long>()));
        }
    }
}