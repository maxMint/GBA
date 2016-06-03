using System.Web.Mvc;
using AutoMapper;
using LeagueOfLegends.BLL.Services;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.DataTables;
using LeagueOfLegends.Domain.Filters;
using Microsoft.Practices.Unity;
using LeagueOfLegends.Models;
using Microsoft.AspNet.Identity;

namespace LeagueOfLegends.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [Dependency]
        public IEventService EventService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUsers([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, UserFilter filter)
        {
            var result = UserService.GetUsers(Mapper.Map<ListCriteria>(requestModel), filter);
            return Json(new DataTablesResponse(requestModel.Draw, result.Data, result.Total, result.Total));
        }

        [HttpPost]
        public ActionResult GetUserEvents([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, UserEventFilter filter)
        {
            var result = UserService.GetUserEvents(Mapper.Map<ListCriteria>(requestModel), filter);
            return Json(new DataTablesResponse(requestModel.Draw, result.Data, result.Total, result.Total));
        }


        [HttpPost]
        public ActionResult GetEvents([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, EventFilter filter)
        {
            var result = EventService.GetList(Mapper.Map<ListCriteria>(requestModel), filter);
            return Json(new DataTablesResponse(requestModel.Draw, result.Data, result.Total, result.Total));
        }


        [HttpPost]
        public ActionResult GetEventUsers([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, EventUserFilter filter)
        {
            var result = EventService.GetUserEvents(Mapper.Map<ListCriteria>(requestModel), filter);
            return Json(new DataTablesResponse(requestModel.Draw, result.Data, result.Total, result.Total));
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Event(long id)
        {
            return View(EventService.Get(id));
        }

        public ActionResult UserInfo(long id)
        {
            return View(UserService.Get(id));
        }

        public ActionResult Account()
        {
            return View(UserService.Get(User.Identity.GetUserId<long>()));
        }

    }
}