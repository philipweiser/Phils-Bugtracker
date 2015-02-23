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
        public ActionResult Index(int? typePage, int? statusPage, int? priorityPage, string sortOrder, bool? typeSort, bool? prioritySort, bool? statusSort)
        {
            if (typeSort == null)
                typeSort = true;
            if (prioritySort == null)
                prioritySort = true;
            if (statusSort == null)
                statusSort = true;
            switch (sortOrder)
            {
                case "type":
                    typeSort = !typeSort;
                    break;
                case "priority":
                    prioritySort = !prioritySort;
                    break;
                case "status":
                    statusSort = !statusSort;
                    break;
                default:
                    break;
            }

            var model = new TypePriorityStatus();

            var pageNumber1 = typePage ?? 1;
            var pageNumber2 = statusPage ?? 1;
            var pageNumber3 = priorityPage ?? 1;

            if (typeSort == true)
                model.types = db.TicketTypes.OrderBy(t=>t.Name).ToList().ToPagedList(pageNumber1, 5);
            else
                model.types = db.TicketTypes.OrderByDescending(t => t.Name).ToList().ToPagedList(pageNumber1, 5);
            if (prioritySort == true)
                model.priorities = db.TicketPriorities.OrderBy(t => t.Name).ToList().ToPagedList(pageNumber2, 5);
            else
                model.priorities = db.TicketPriorities.OrderByDescending(t=>t.Name).ToList().ToPagedList(pageNumber2, 5);
            if (statusSort == true)
                model.statuses = db.TicketStatuses.OrderBy(t => t.Name).ToList().ToPagedList(pageNumber3, 5);
            else
                model.statuses = db.TicketStatuses.OrderByDescending(t=>t.Name).ToList().ToPagedList(pageNumber3, 5);

            ViewBag.typePage = pageNumber1;
            ViewBag.statusPage = pageNumber2;
            ViewBag.priorityPage = pageNumber3;

            ViewBag.typeSort = typeSort;
            ViewBag.prioritySort = prioritySort;
            ViewBag.statusSort = statusSort;
            return View(model);
        }
    }
}