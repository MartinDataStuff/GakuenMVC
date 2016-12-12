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
        // GET: ConfirmPayment
        public ActionResult Index()
        {
            return View();
        }

        // POST: ConfirmPayment/Check/5
        [HttpPost]
        public ActionResult Check(string Code, FormCollection collection)
        {
            if (_OrderListServiceGateway.Read().Find(x => x.PaidStringCode == Code) != null)
            {
                ViewBag.Code = Code;
                OrderList OrderList = _OrderListServiceGateway.Read().Find(x => x.PaidStringCode == Code);
                ViewBag.Cash = OrderList.PriceToPay;
                ViewBag.UserName = OrderList.User.UsrName;
            }
            else
            {
                ViewBag.Code = "ERROR NO Match";
                ViewBag.Cash = 00000;
                ViewBag.UserName = new User();
            }


            return View();

        }
        // POST: ConfirmPayment/Validate/5
        [HttpPost]
        public ActionResult Validate(string Code, FormCollection collection)
        {
            OrderList OrderList = _OrderListServiceGateway.Read().Find(x => x.PaidStringCode == Code);
            OrderList.PaymentAccepted = true;
            _OrderListServiceGateway.Update(OrderList);
            return Redirect("/ConfirmPayment");

        }


    }
}