using System.Net;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVCAuthless.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IServiceGateway<Address> _addresServiceGateway = new DllFacade().GetAddressServiceGateway();

        // GET: Addresses
       public ActionResult Index()
        {
            return View(_addresServiceGateway.Read());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addresServiceGateway.Read(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Street1,Street2,Town,ZipCode,Country")] Address address)
        {
            if (ModelState.IsValid)
            {
                _addresServiceGateway.Create(address);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addresServiceGateway.Read(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Street1,Street2,Town,ZipCode,Country")] Address address)
        {
            if (ModelState.IsValid)
            {
                _addresServiceGateway.Update(address);
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addresServiceGateway.Read(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
       [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
       {
           _addresServiceGateway.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
