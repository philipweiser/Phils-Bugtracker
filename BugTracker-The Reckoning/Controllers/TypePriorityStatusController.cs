using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker_The_Reckoning.Models;
using PagedList.Mvc;
using PagedList;

namespace BugTracker_The_Reckoning.Controllers
{
    [Authorize(Roles="Administrator, Project Manager")]
    public class TypePriorityStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: TypePriorityStatus
        public ActionResult Index(int? typePage, int? statusPage, int? priorityPage)
        {
            var model = new TypePriorityStatus();

            var pageNumber1 = typePage ?? 1;
            model.types = db.TicketTypes.ToList().ToPagedList(pageNumber1, 5);

            var pageNumber2 = statusPage ?? 1;
            model.priorities = db.TicketPriorities.ToList().ToPagedList(pageNumber2, 5);

            var pageNumber3 = priorityPage ?? 1;
            model.statuses = db.TicketStatuses.ToList().ToPagedList(pageNumber3, 5);

            ViewBag.typePage = pageNumber1;
            ViewBag.statusPage = pageNumber2;
            ViewBag.priorityPage = pageNumber3;
            return View(model);
        }
    }
}