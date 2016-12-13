using System.Web.Mvc;
using System;
using System.Collections.Generic;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVCAuthless.Controllers
{
    public class ConfirmPaymentController : Controller
    {
        private readonly IServiceGateway<OrderList> _OrderListServiceGateway = new DllFacade().GetOrderListServiceGateway();
        private readonly IServiceGateway<User> _UserServiceGateway = new DllFacade().GetUserServiceGateway();

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
                User theUser = UserCheck(OrderList);
                if (theUser.UsrName != null) { ViewBag.UserName = theUser.UsrName;} else { ViewBag.UserName = "ERROR NO Match";}
                if (theUser.FirstName != null) { ViewBag.UserFirstName = theUser.FirstName; } else { ViewBag.UserFirstName = "ERROR NO Match"; }
                if (theUser.LastName != null) { ViewBag.UserLastName = theUser.LastName; } else { ViewBag.UserLastName = "ERROR NO Match"; }
                if (theUser.PhoneNr != null) { ViewBag.UserPhoneNr = theUser.PhoneNr; } else { ViewBag.UserPhoneNr = "ERROR NO Match"; }
                if (theUser.Position != null) { ViewBag.UserPosition = theUser.Position; } else { ViewBag.UserPosition = "ERROR NO Match"; }

            }
            else
            {
                ViewBag.Code = "ERROR Code NO Match";
                ViewBag.Cash = 00000;
                ViewBag.UserName = "ERROR Code NO Match";
                ViewBag.UserFirstName = "ERROR Code NO Match";
                ViewBag.UserLastName = "ERROR Code NO Match";
                ViewBag.UserPhoneNr = "ERROR Code NO Match";
                ViewBag.UserPosition = "ERROR Code NO Match";
            }


            return View();

        }

        private User UserCheck(OrderList orderList)
        {
            foreach (User user in _UserServiceGateway.Read())
            {
                foreach (var order in user.OrderLists)
                {
                    if (order.PaidStringCode == orderList.PaidStringCode) {
                         return user;
                    }
                }
            }
            return null;
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