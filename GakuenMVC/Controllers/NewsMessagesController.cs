using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVC.Controllers
{
    [AllowAnonymous]
    public class NewsMessagesController : Controller
    {
        private readonly IServiceGateway<NewsMessage> _newsMessageServiceGateway =
            new DllFacade().GetNewsMessageServiceGateway();

        // GET: NewsMessages
        public ActionResult Index()
        {
            return View(_newsMessageServiceGateway.Read());
        }

        // GET: NewsMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage newsMessage = _newsMessageServiceGateway.Read(id.Value);
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
                _newsMessageServiceGateway.Create(newsMessage);
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
            NewsMessage newsMessage = _newsMessageServiceGateway.Read(id.Value);
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
                _newsMessageServiceGateway.Update(newsMessage);
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
            NewsMessage newsMessage = _newsMessageServiceGateway.Read(id.Value);
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
            _newsMessageServiceGateway.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
