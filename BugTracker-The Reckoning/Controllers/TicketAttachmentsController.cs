using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BugTracker_The_Reckoning.Models;
using System.IO;

namespace BugTracker_The_Reckoning.Controllers
{
    public class TicketAttachmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TicketAttachments
        public ActionResult Index()
        {
            var ticketAttachments = db.TicketAttachments.Include(t => t.Ticket);
            return View(ticketAttachments.ToList());
        }

        // GET: TicketAttachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            if (ticketAttachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubmitterName = db.Users.First(u => u.Id == ticketAttachment.UserId).DisplayName;
            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Create
        public ActionResult Create(int TicketId)
        {
            TicketAttachment ticketAttachment = new TicketAttachment();
            ticketAttachment.TicketId = TicketId;
            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,Title,Body,Description,FileUrl")] TicketAttachment theAtt,
            HttpPostedFileBase fileUpload)
        {
            var file = Request.Files;

            if (ModelState.IsValid)
            {
                //restricting to valid image uploads, only
                if (fileUpload != null && fileUpload.ContentLength > 0)
                {
                    if (!fileUpload.ContentType.Contains("image"))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.UnsupportedMediaType);
                    }
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    if (System.IO.File.Exists(fileName))
                    {
                        int count = 1;
                        while (System.IO.File.Exists(count++ + fileName))
                        {
                        }
                        if (count > 1)
                        {
                            fileName = count + fileName;
                        }
                    }
                    var thePath = Path.Combine(Server.MapPath("~/Content/uploads/"), fileName);
                    theAtt.FileUrl = "/Content/uploads/" + fileName;
                    fileUpload.SaveAs(thePath);
                }

                theAtt.Created = new DateTimeOffset(DateTime.Now);
                theAtt.UserId = User.Identity.GetUserId();
                db.TicketAttachments.Add(theAtt);
                db.SaveChanges();
                var th = new TicketHistory()
                {
                    TicketId = theAtt.TicketId,
                    UserId = User.Identity.GetUserId(),
                    Property = "New Ticket Attachment",
                    OldValue = "",
                    NewValue = theAtt.Description,
                    Changed = DateTimeOffset.Now,
                };
                db.TicketHistories.Add(th);
                db.Tickets.Find(theAtt.TicketId).TicketHistories.Add(th);
                db.SaveChanges();
                return RedirectToAction("Details/"+theAtt.TicketId, "Tickets");
            }
            return View(theAtt);
        }

        // GET: TicketAttachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            if (ticketAttachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Title", ticketAttachment.TicketId);
            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TicketId,UserId,FilePath,Description,Created,FileUrl")] TicketAttachment ticketAttachment)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Title", ticketAttachment.TicketId);
            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            if (ticketAttachment == null)
            {
                return HttpNotFound();
            }
            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            db.TicketAttachments.Remove(ticketAttachment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
