using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLLGakuen.Entity;

namespace GakuenMVC.Controllers
{
    public class EventMessagesController : Controller
    {
     /*   private GakuenContext db = new GakuenContext();

        // GET: EventMessages
        public ActionResult Index()
        {
            return View(db.EventMessages.ToList());
        }

        // GET: EventMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMessage eventMessage = db.EventMessages.Find(id);
            if (eventMessage == null)
            {
                return HttpNotFound();
            }
            return View(eventMessage);
        }

        // GET: EventMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] EventMessage eventMessage)
        {
            if (ModelState.IsValid)
            {
                db.EventMessages.Add(eventMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventMessage);
        }

        // GET: EventMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMessage eventMessage = db.EventMessages.Find(id);
            if (eventMessage == null)
            {
                return HttpNotFound();
            }
            return View(eventMessage);
        }

        // POST: EventMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] EventMessage eventMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventMessage);
        }

        // GET: EventMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMessage eventMessage = db.EventMessages.Find(id);
            if (eventMessage == null)
            {
                return HttpNotFound();
            }
            return View(eventMessage);
        }

        // POST: EventMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventMessage eventMessage = db.EventMessages.Find(id);
            db.EventMessages.Remove(eventMessage);
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
        }*/
    }
}
