using System.Net;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVC.Controllers
{
    public class NewsMessagesController : Controller
    {
        private readonly IServiceGateway<NewsMessage> _newsMessageServiceGateway =
            new DllFacade().GetNewsMessageServiceGateway();
        private readonly IServiceGateway<ImageToHost> _imageToHostServiceGateway = new DllFacade().GetImageTohostServiceGateway();

        // GET: NewsMessages
        public ActionResult Index()
        {
            return View(_newsMessageServiceGateway.Read());
        }

        // GET: NewsMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage newsMessage = _newsMessageServiceGateway.Read(id.Value);
            if (newsMessage == null)
            {
                return HttpNotFound();
            }
            return View(newsMessage);
        }

        // GET: NewsMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] NewsMessage newsMessage,[Bind(Include = "Id,ImagePath")] ImageToHost imageToHost)
        {
            if (ModelState.IsValid)
            {
               var news =  _newsMessageServiceGateway.Create(newsMessage);
                var image = _imageToHostServiceGateway.Create(imageToHost);
                news.ImageToHost = image;
                _newsMessageServiceGateway.Update(news);
                return RedirectToAction("Index");
            }

            return View(newsMessage);
        }

        // GET: NewsMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage newsMessage = _newsMessageServiceGateway.Read(id.Value);
            if (newsMessage == null)
            {
                return HttpNotFound();
            }
            return View(newsMessage);
        }

        // POST: NewsMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] NewsMessage newsMessage)
        {
            if (ModelState.IsValid)
            {
                _newsMessageServiceGateway.Update(newsMessage);
                return RedirectToAction("Index");
            }
            return View(newsMessage);
        }

        // GET: NewsMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsMessage newsMessage = _newsMessageServiceGateway.Read(id.Value);
            if (newsMessage == null)
            {
                return HttpNotFound();
            }
            return View(newsMessage);
        }

        // POST: NewsMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _newsMessageServiceGateway.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
