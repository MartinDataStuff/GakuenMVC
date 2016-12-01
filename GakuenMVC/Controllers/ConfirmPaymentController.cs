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
        //private readonly IServiceGateway<Product> _ProductServiceGateway = new DllFacade().GetProductServiceGateway();
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
        private OrderList Products = new OrderList()
        {
            ItemsList = new List<Product>()
            {
                new Product() { Id = 1, Price = 510, Info = "Stay the Week", Name = "Week"},
                new Product() { Id = 2, Price = 520, Info = "get a sleep place", Name = "Sleep"},
                new Product() { Id = 3, Price = 530, Info = "Stawdsk", Name = "something"},
                new Product() { Id = 4, Price = 5540, Info = "Stayqwek", Name = "bibo"},
                new Product() { Id = 5, Price = 5650, Info = "Staqweek", Name = "lord of the ring"},
                new Product() { Id = 6, Price = 560, Info = "StaqweWeek", Name = "coldplay show"},
                new Product() { Id = 7, Price = 51231230, Info = "Stayqweek", Name = "Death or manga"}
            }

        };

        // GET: ConfirmPayment/BuyList
        public ActionResult BuyList()
        {
            ViewBag.Products = Products.ItemsList;
            return View();
        }

        // POST: ConfirmPayment/Validate/5
        [HttpPost]
        public ActionResult ConfirmBuy(Array checkbox, FormCollection collection)
        {


            return View();

        }
    }
}