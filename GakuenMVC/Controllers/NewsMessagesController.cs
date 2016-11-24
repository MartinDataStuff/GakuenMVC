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
    public class NewsMessagesController : Controller
    {
      /*  private GakuenContext db = new GakuenContext();

        // GET: NewsMessages
        public ActionResult Index()
        {
            return View(db.NewsMessages.ToList());
        }

        // GET: NewsMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage newsMessage = db.NewsMessages.Find(id);
            if (newsMessage == null)
            {
                return HttpNotFound();
            }
            return View(newsMessage);
        }

        // GET: NewsMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] NewsMessage newsMessage)
        {
            if (ModelState.IsValid)
            {
                db.NewsMessages.Add(newsMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsMessage);
        }

        // GET: NewsMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage newsMessage = db.NewsMessages.Find(id);
            if (newsMessage == null)
            {
                return HttpNotFound();
            }
            return View(newsMessage);
        }

        // POST: NewsMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] NewsMessage newsMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsMessage);
        }

        // GET: NewsMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage newsMessage = db.NewsMessages.Find(id);
            if (newsMessage == null)
            {
                return HttpNotFound();
            }
            return View(newsMessage);
        }

        // POST: NewsMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsMessage newsMessage = db.NewsMessages.Find(id);
            db.NewsMessages.Remove(newsMessage);
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
