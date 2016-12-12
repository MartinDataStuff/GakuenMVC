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
using RestSharp.Extensions;

namespace GakuenMVC.Controllers
{
    public class OrderListsController : Controller
    {
        private readonly IServiceGateway<OrderList> _db = new DllFacade().GetOrderListServiceGateway();

        // GET: OrderLists
        public ActionResult Index()
        {
            return View(_db.Read());
        }

        // GET: OrderLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = _db.Read(id.Value);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // GET: OrderLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PaidStringCode,PriceToPay,DateTime")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                _db.Create(orderList);
                return RedirectToAction("Index");
            }

            return View(orderList);
        }

        // GET: OrderLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = _db.Read(id.Value);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // POST: OrderLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PaidStringCode,PriceToPay,DateTime")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                _db.Update(orderList);
                return RedirectToAction("Index");
            }
            return View(orderList);
        }

        // GET: OrderLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = _db.Read(id.Value);
            
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // POST: OrderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }
        }
}
