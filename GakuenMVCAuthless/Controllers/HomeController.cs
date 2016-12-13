using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVCAuthless.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly IServiceGateway<NewsMessage> _newsMessageServiceGateway =
            new DllFacade().GetNewsMessageServiceGateway();
        public ActionResult Index()
        {
            return View(_newsMessageServiceGateway.Read());
        }
        [Authorize(Users = "isAdmin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}