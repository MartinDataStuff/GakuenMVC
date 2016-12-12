﻿using System;
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
        private readonly IServiceGateway<Product> _productServiceGateway = new DllFacade().GetProductServiceGateway();
        private readonly IServiceGateway<OrderList> _orderListServiceGateway = new DllFacade().GetOrderListServiceGateway();
        private static OrderList ORLImpirt = new OrderList();
        // GET: Shop
        public ActionResult Index()
        {
            ViewBag.Products = _productServiceGateway.Read();

            var cart = Session["cart"] as ShoppingCart;
            if (cart == null) cart = new ShoppingCart();
            Session["cart"] = cart;
            ViewBag.Orderlist = cart.Products.Values.ToList();

            return View();
        }

        // GET: Shop/ConfirmBuy/5

        public ActionResult ConfirmBuy(int id)
        {
            var cart = Session["cart"] as ShoppingCart;
            if (cart == null) cart = new ShoppingCart();
            if (cart.Products.ContainsKey(id) == false)
            {
                // it is not in the IDictionary
                cart.Products.Add(id, _productServiceGateway.Read(id));
            }
            else
            {
                //it is in the IDictionary
            }
            
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        // GET: Shop/Remove/5

        public ActionResult Remove(int id)
        {
            var cart = Session["cart"] as ShoppingCart;
            if (cart == null) cart = new ShoppingCart();
            Session["cart"] = cart;
            cart.Products.Remove(id);

            ViewBag.Products = _productServiceGateway.Read();

            ViewBag.Orderlist = cart.Products.Values.ToList();
            Session["cart"] = cart;

            return RedirectToAction("Index");
        }
        
        // POST: Shop/Buylist
        [HttpPost]
        public ActionResult Buylist()
        {
            var cart = Session["cart"] as ShoppingCart;
            if (cart == null) cart = new ShoppingCart();

            ORLImpirt = _orderListServiceGateway.Create(new OrderList() {ItemsList = cart.Products.Values.ToList() });
            new CodeMaker(ORLImpirt);
            cart.Products.Clear();

            Session["cart"] = cart;

            return RedirectToAction($"ListInfo/{ORLImpirt.Id}");
        }
        // GET: Shop/ListInfo
        public ActionResult ListInfo(int id)
        {
            return View(_orderListServiceGateway.Read(id));
        }
        // GET: Shop/OrderListList
        public ActionResult OrderListList()
        {
            return View(_orderListServiceGateway.Read());
        }
    }
}