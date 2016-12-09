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
        private readonly IServiceGateway<VideoToHost> _videoToHostServiceGateway = new DllFacade().GetVideoToHostServiceGateway();

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
        public ActionResult Create([Bind(Include = "Id,Title,Body")] NewsMessage newsMessage,[Bind(Include = "Id,ImagePath")] ImageToHost imageToHost, [Bind(Include = "Id,VideoPath")] VideoToHost videoToHost)
        {
            if (ModelState.IsValid)
            {
               var news =  newsMessage;
                if (imageToHost.ImagePath != null)
                {
                    var image = _imageToHostServiceGateway.Create(imageToHost);
                    news.ImageToHost = image;
                }

                if (videoToHost.VideoPath != null)
                {
                    var video = _videoToHostServiceGateway.Create(videoToHost);
                    news.VideoToHost = video;
                }
                _newsMessageServiceGateway.Create(news);
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


        // GET: NewsMessages/NewsFeed/5
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
