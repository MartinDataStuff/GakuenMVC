using System.Net;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVC.Controllers
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

        // GET: Home/NewsFeed/5
        public ActionResult NewsFeed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage news = _newsMessageServiceGateway.Read(id.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
    }
}