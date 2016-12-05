using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;
using GakuenMVC.Models;

namespace GakuenMVC.Controllers
{
    public class SchoolEventsController : Controller
    {
        private readonly IServiceGateway<SchoolEvent> _schoolEventserviceGateway =
            new DllFacade().GetSchoolEventServiceGateway();

        // GET: SchoolEvents
        public ActionResult Index()
        {
            return View(_schoolEventserviceGateway.Read());
        }

        // GET: SchoolEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolEvent schoolEvent = _schoolEventserviceGateway.Read(id.Value);
            if (schoolEvent == null)
            {
                return HttpNotFound();
            }
            return View(schoolEvent);
        }

        // GET: SchoolEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Minuttes,Name")] SchoolEvent schoolEvent)
        {
            if (ModelState.IsValid)
            {
                _schoolEventserviceGateway.Create(schoolEvent);
                return RedirectToAction("Index");
            }

            return View(schoolEvent);
        }

        // GET: SchoolEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolEvent schoolEvent = _schoolEventserviceGateway.Read(id.Value);
            if (schoolEvent == null)
            {
                return HttpNotFound();
            }
            return View(schoolEvent);
        }

        // POST: SchoolEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Minuttes,Name")] SchoolEvent schoolEvent)
        {
            if (ModelState.IsValid)
            {
                _schoolEventserviceGateway.Update(schoolEvent);
                return RedirectToAction("Index");
            }
            return View(schoolEvent);
        }

        // GET: SchoolEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolEvent schoolEvent = _schoolEventserviceGateway.Read(id.Value);
            if (schoolEvent == null)
            {
                return HttpNotFound();
            }
            return View(schoolEvent);
        }

        // POST: SchoolEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _schoolEventserviceGateway.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
