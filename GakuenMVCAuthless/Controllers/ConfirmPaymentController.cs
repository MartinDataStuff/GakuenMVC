using System.Web.Mvc;
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
                
                ViewBag.UserName = theUser.UsrName;
                ViewBag.UserFirstName = theUser.FirstName;
                ViewBag.UserLastName = theUser.LastName;
                ViewBag.UserPhoneNr = theUser.PhoneNr;
                ViewBag.UserPosition = theUser.Position;
            }
            else
            {
                ViewBag.Code = "ERROR NO Match";
                ViewBag.Cash = 00000;
                ViewBag.UserName = "ERROR NO Match";
                ViewBag.UserFirstName = "ERROR NO Match";
                ViewBag.UserLastName = "ERROR NO Match";
                ViewBag.UserPhoneNr = "ERROR NO Match";
                ViewBag.UserPosition = "ERROR NO Match";
            }


            return View();

        }

        private User UserCheck(OrderList orderList)
        {
            foreach (User user in _UserServiceGateway.Read())
            {
                foreach (var order in user.OrderLists)
                {
                    if (order == orderList) {
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