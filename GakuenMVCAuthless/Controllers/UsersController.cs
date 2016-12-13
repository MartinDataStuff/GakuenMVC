using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;
using GakuenMVCAuthless.Models;

namespace GakuenMVCAuthless.Controllers
{
    public class UsersController : Controller
    {
        private readonly IServiceGateway<User> _userServiceGateway = new DllFacade().GetUserServiceGateway();
        

        // GET: Users
        //[Authorize(Users = "isAdmin")]
        public ActionResult Index()
        {
            var users = _userServiceGateway.Read();
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userServiceGateway.Read(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email,UsrName,PhoneNr,Address,Birthday, ContactPersonPhoneNumber, " +
        //                                           "Password, ConfirmPassword, isAdmin")] RegisterViewModel user)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        AccountController acc = new AccountController();
        //        await acc.Register(user);

        //        //var appUser = new ApplicationUser
        //        //{
        //        //    UserName = user.UsrName,
        //        //    Email = user.Email,
        //        //    UsrName = user.UsrName,
        //        //    Password = user.Password,
        //        //    FirstName = user.FirstName,
        //        //    LastName = user.LastName,
        //        //    Address = user.Address,
        //        //    PhoneNr = user.PhoneNr,
        //        //    ContactPersonPhoneNumber = user.ContactPersonPhoneNumber,
        //        //    Birthday = user.Birthday,
        //        //    IsAdmin = true



        //        //};

        //        //var usr = new User
        //        //{
        //        //    Address = appUser.Address,
        //        //    FirstName = appUser.FirstName,
        //        //    LastName = appUser.LastName,
        //        //    Birthday = appUser.Birthday,
        //        //    ContactPersonPhoneNumber = appUser.ContactPersonPhoneNumber,
        //        //    Email = appUser.Email,
        //        //    Password = appUser.Password,
        //        //    PhoneNr = appUser.PhoneNr,
        //        //    UsrName = appUser.UsrName,
        //        //    isAdmin = appUser.IsAdmin
        //        //};


        //        //_userServiceGateway.Create(usr);
        //        return RedirectToAction("Index");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(user);
        //}

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userServiceGateway.Read(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
          
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,UsrName,PhoneNr,Address,Birthday,ContactPersonPhoneNumber,Password,ConfirmUser,isAdmin,Position")] User user)
        {
            if (ModelState.IsValid)
            {
                _userServiceGateway.Update(user);
                return RedirectToAction("Index");
            }
           
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userServiceGateway.Read(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userServiceGateway.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult SendMessage()
        {
            EmailService.SendSimpleMessage();
            return RedirectToAction("Index");
        }

    }
}
