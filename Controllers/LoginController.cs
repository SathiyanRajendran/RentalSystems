using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSystems.Models;
using System.Linq;

namespace RentalSystems.Controllers
{
    public class LoginController : Controller
    {
        private readonly OwnerDbContext db;
        private readonly ISession session;

        public LoginController(OwnerDbContext _db, IHttpContextAccessor httpContextAccessor) //constructor
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Login(Registrationtable obj)
        {
            var result = (from i in db.registrationtables
                          where i.UserId == obj.UserId && i.Password == obj.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("username", result.UserName);

                return RedirectToAction("VehicleList", "Customers");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Registrationtable obj)
        {
            ViewBag.UserId = obj.UserId;
            if (obj.UserId != null)
            {
                db.registrationtables.Add(obj);
                db.SaveChanges();
                HttpContext.Session.SetInt32("userid", obj.UserId);
                return View();
            }
            else
            {
                return View();
            }

        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(Admintable obj)
        {
            var result = (from i in db.admintables 
                          where i.AdminId == obj.AdminId && i.AdminPassword == obj.AdminPassword
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("adminname", result.AdminName);
                return RedirectToAction("Index", "Owners");

            }
            else
            {
                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction( "Login","Login");
        }
    }
}
