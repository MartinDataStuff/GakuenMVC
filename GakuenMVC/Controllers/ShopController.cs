using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;
using GakuenMVC.Models;

namespace GakuenMVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IServiceGateway<Product> _ProductServiceGateway = new DllFacade().GetProductServiceGateway();
        private readonly IServiceGateway<OrderList> _OrderListServiceGateway = new DllFacade().GetOrderListServiceGateway();
        //seseionstate
        private static List<Product> orderList = new List<Product>();
        // GET: Shop
        public ActionResult Index()
        {
            ViewBag.Products = _ProductServiceGateway.Read();
            ViewBag.Orderlist = orderList;
            return View();
        }

        // GET: Shop/ConfirmBuy/5
        
        public ActionResult ConfirmBuy(int id)
        {
            orderList.Add(_ProductServiceGateway.Read().Find(x => x.Id == id));
            ViewBag.Products = _ProductServiceGateway.Read();
            ViewBag.Orderlist = orderList;
            return RedirectToAction("Index");
        }
        // GET: Shop/Remove/5

        public ActionResult Remove(int id)
        {
            orderList.RemoveAll(x => x.Id == id);
            ViewBag.Products = _ProductServiceGateway.Read();
            ViewBag.Orderlist = orderList;
            return RedirectToAction("Index");
        }
        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(string info,string name,double price, FormCollection collection)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private static OrderList ORLImpirt = new OrderList();
        // POST: Shop/Buylist
        [HttpPost]
        public ActionResult Buylist()
        {
            
            ORLImpirt = _OrderListServiceGateway.Create(new OrderList() { ItemsList = orderList });
            new CodeMaker(ORLImpirt);
            orderList.Clear();
            return RedirectToAction("ListInfo");
        }
        // GET: Shop/ListInfo
        public ActionResult ListInfo()
        {
            ViewBag.Products = ORLImpirt.ItemsList;
            return View(ORLImpirt);
        }
        // GET: Shop/OrderListList
        public ActionResult OrderListList()
        {
            return View(_OrderListServiceGateway.Read());
        }
    }
}