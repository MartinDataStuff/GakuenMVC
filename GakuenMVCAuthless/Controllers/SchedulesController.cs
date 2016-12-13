using System.Net;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVCAuthless.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly IServiceGateway<Schedule> _scheduleServiceGateway = new DllFacade().GetScheduleServiceGateway();

        // GET: Schedules
        public ActionResult Index()
        {
            return View(_scheduleServiceGateway.Read());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = _scheduleServiceGateway.Read(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _scheduleServiceGateway.Create(schedule);
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = _scheduleServiceGateway.Read(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _scheduleServiceGateway.Update(schedule);
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = _scheduleServiceGateway.Read(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _scheduleServiceGateway.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult OverView()
        {
            return View(_scheduleServiceGateway.Read());
        }

        public ActionResult SchoolEventsInSchedule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = _scheduleServiceGateway.Read(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }
    }
}
