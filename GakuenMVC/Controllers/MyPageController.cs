using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVC.Controllers
{
    public class MyPageController : Controller
    {
        private readonly IServiceGateway<OrderList> _orderListServiceGateway = new DllFacade().GetOrderListServiceGateway();
        // GET: MyPage
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyPage/Details/5
        public ActionResult ProduktList(int id)
        {
            ViewBag.AllOrders = _orderListServiceGateway.Read();//here shall be only the users orderlists
            return View();
        }

        // GET: MyPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyPage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyPage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyPage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
