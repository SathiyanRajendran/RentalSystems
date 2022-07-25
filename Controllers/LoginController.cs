using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSystems.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

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
                HttpContext.Session.SetString("emailid", result.EmailId);


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
        //    db.registrationtables.Add(obj);
        //    db.SaveChanges();

        //    // Send Mail Confirmation for passsword

        //    var senderEmail = new MailAddress("rentalsystem3@gmail.com", "Sathiyan");
        //    var receiverEmail = new MailAddress(obj.MailId, "Receiver");
        //    var password = "gusmmfohuxvryrfx";
        //    var sub = "Hello " + obj.UserName + "! Welcome to Cape Town Rental System";
        //    var body = "Your User Id: " + obj.UserId + " And your password is :" + obj.Password;
        //    var smtp = new SmtpClient
        //    {

        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(senderEmail.Address, password)
        //    };
        //    using (var mess = new MailMessage(senderEmail, receiverEmail)
        //    {
        //        Subject = sub,
        //        Body = body
        //    })
        //    {
        //        smtp.Send(mess);
        //        ViewBag.Message = String.Format("Registered Successfully!!\\ Please Check Your Mail to login.");
        //    }
        //    return View("Login");
        //}
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
