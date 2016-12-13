using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVCAuthless.Controllers
{
    public class MyPageController : Controller
    {
        private readonly IServiceGateway<OrderList> _orderListServiceGateway = new DllFacade().GetOrderListServiceGateway();
        // GET: MyPage
        public ActionResult Index()
        {
            ViewBag.AllOrders = _orderListServiceGateway.Read();//here shall be only the users orderlists
            return View();
        }

        // GET: MyPage/Details/5
        public ActionResult ProduktList(int id)
        {
            ViewBag.AllOrders = _orderListServiceGateway.Read();//here shall be only the users orderlists
            return View();
        }


    }
}
