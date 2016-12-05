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
        private readonly IServiceGateway<OrderList> _OrderListServiceGateway = new DllFacade().GetOrderListServiceGateway();
        private readonly IServiceGateway<Product> _ProductServiceGateway = new DllFacade().GetProductServiceGateway();
        // GET: ConfirmPayment
        public ActionResult Index()
        {
            return View();
        }

        // POST: ConfirmPayment/Validate/5
        [HttpPost]
        public ActionResult Validate(string Code, FormCollection collection)
        {
            OrderList yyyy = _OrderListServiceGateway.Read().Find(x => x.PaidStringCode == Code);
            List<OrderList> uuuuu = _OrderListServiceGateway.Read();
            if (_OrderListServiceGateway.Read().Find(x => x.PaidStringCode == Code) != null)
            {
                ViewBag.Code = Code;

                ViewBag.Cash = _OrderListServiceGateway.Read().Find(x => x.PaidStringCode == Code).PriceToPay;
            }
            else
            {
                ViewBag.Code = "ERROR NO Match";
                ViewBag.Cash = 00000;
            }


            return View();

        }


        
    }
}