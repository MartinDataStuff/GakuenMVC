using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVC.Controllers
{
    public class ConfirmPaymentController : Controller
    {
        private readonly IServiceGateway<User> _UserServiceGateway = new DllFacade().GetUserServiceGateway();
        // GET: ConfirmPayment
        public ActionResult Index()
        {
            return View();
        }

        // POST: ConfirmPayment/Validate/5
        [HttpPost]
        public ActionResult Validate(string Code, FormCollection collection)
        {
            User yyyy = _UserServiceGateway.Read().Find(x => x.FirstName == Code);
            List<User> uuuuu = _UserServiceGateway.Read();
            if (_UserServiceGateway.Read().Find(x => x.FirstName == Code) != null)
            {
                ViewBag.Code = Code;

                ViewBag.Cash = _UserServiceGateway.Read().Find(x => x.FirstName == Code).FirstName;
            }
            else
            {
                ViewBag.Code = "ERROR NO Match";
                ViewBag.Cash = 00000;
            }


            return View();

        }
        // this is just for test 
        private OrderList itemss = new OrderList()
        {
            ItemsList = new List<Product>()
            {
                new Product() { Id = 1, Price = 50, Info = "Stay the Week", Name = "Week"},
            }

        };

        // GET: ConfirmPayment/BuyList
        public ActionResult BuyList()
        {
            return View(itemss);
        }

        // POST: ConfirmPayment/Validate/5
        [HttpPost]
        public ActionResult ConfirmBuy(Array checkbox, FormCollection collection)
        {


            return View();

        }
    }
}