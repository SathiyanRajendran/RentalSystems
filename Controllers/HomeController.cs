using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalSystems.Models;
using System;


using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using IronBarCode;
using System.Drawing;
using System.IO;
using QRCoder;
using System.Net.Mail;
using System.Net;

namespace RentalSystems.Controllers
{
    public class HomeController : Controller
    {
        private readonly OwnerDbContext db;
        public HomeController(OwnerDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();           
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Search(string option, string search,int? pageNumber)
        {
           

            if (option == "VehicleNo")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.owners.Where(x => x.VehicleNo == search || search == null).ToList());
            }
            else if (option == "Model")
            {
                return View(db.owners.Where(x => x.Model == search || search == null).ToList());
            }
            else
            {
                return View(db.owners.Where(x => x.CompanyName.StartsWith(search) || search == null).ToList());
            }
            
        }
        
        public IActionResult Offers()
        {
            return View();
        }
        public IActionResult Tariffs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }    
        public IActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("rentalsystem3@gmail.com", "Sathiyan");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "gusmmfohuxvryrfx";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        public ActionResult Email()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Email(EmailModel model)
        {
            MailMessage mm = new MailMessage("rentalsystem3@gmail.com", model.To);

            mm.Subject = model.Subject;
            mm.Body = model.Body;
            //if (model.Attachment.ContentLength>0)
            //{
            //    string fileName = Path.GetFileName(model.Attachment.FileName);
            //    mm.Attachments.Add(new Attachment(model.Attachment.InputStream,fileName));
            //}
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("rentalsystem3@gmail.com", "gusmmfohuxvryrfx");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            ViewBag.Message = "Email sent.";



            return View();
        }
        
    }
        
    
}
