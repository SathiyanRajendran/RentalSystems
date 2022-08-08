using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalSystems.DataLayer;
using RentalSystems.Models;
using System.Linq;


namespace RentalSystems.Controllers
{
    public class CustomersController : Controller
    {
        private readonly OwnerDbContext db;
        public CustomersController(OwnerDbContext _db)
        {
            db = _db;
        }
        //private ICustomerRepo interfaceobj;
        //public CustomersController()
        //{
        //    interfaceobj = new CustomerRepo(new OwnerDbContext());

        //}





        public IActionResult VehicleList()  //owner table show to customers then they booked
        {


            ViewBag.UserName = HttpContext.Session.GetString("username");

            if (ViewBag.UserName != null)
            {

                return View(db.owners.ToList());
                //    return View(db.owners.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            //if (option == "VehicleNo")
            //{
            //    //Index action method will return a view with a student records based on what a user specify the value in textbox  
            //    return View(db.owners.Where(x => x.VehicleNo == search || search == null).ToList());
            //}
            //else if (option == "Model")
            //{
            //    return View(db.owners.Where(x => x.Model == search || search == null).ToList());
            //}
            //else
            //{
            //    return View(db.owners.Where(x => x.CompanyName.StartsWith(search) || search == null).ToList());
            //}
        }
        public IActionResult Booking() //List of customers
        {
            var data = from m in db.customers select m;
            return View(data);
        }
       [HttpGet]
       public IActionResult CustomerCreate(int? VehicleId )
        {
            var result = new SelectList(from i in db.owners select i.VehicleId).ToList();
          
     var o=  db.owners.FirstOrDefault(i => i.VehicleId == VehicleId); //Shows the owner table to display
            ViewBag.Vid = o.Model;
           ViewBag.Rpd = o.Rentalperday;
            ViewBag.Vno = o.VehicleNo;
            //25th july by Hariesh changes

           ViewBag.VehicleId = result; //dropdown using viewbag
            ViewBag.Username = HttpContext.Session.GetString("username");
           ViewBag.EmailId = HttpContext.Session.GetString("emailid");
           return View();
       }
        [HttpPost]
        public IActionResult CustomerCreate(Customer s) //Stocks purchasing
        {


            db.customers.Add(s);
            Owner c = db.owners.Find(s.VehicleId);
            var bal = (from i in db.owners where i.VehicleId == s.VehicleId select i).First<Owner>().Stocks;
            bal -= 1;
            c.Stocks = bal;
            db.owners.Update(c);
            db.SaveChanges();
            return RedirectToAction("RentCost");
        }

        //public IActionResult CreateBooking()  //Customer created Booking
        //{
        //    var result = new SelectList(from i in db.owners
        //                                select i.VehicleId).ToList();//drop down
        //    ViewBag.VehicleId = result;
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CreateBooking(Customer C) //Booking reflected
        //{
        //    db.customers.Add(C);
        //    db.SaveChanges();
        //    return RedirectToAction("Booking");
        //}
        public IActionResult CustomerDetails(int id)
        {
            Customer C = db.customers.Find(id);
            return View(C);
        }
        public IActionResult EditDetails(int id)
        {
            var result = new SelectList(from i in db.owners
                                        select i.VehicleId).ToList();//drop down
            ViewBag.VehicleId = result;
            //return View();
            Customer C = db.customers.Find(id);
            return View(C);
        }
        [HttpPost]
        public IActionResult EditDetails(Customer C)
        {
            db.customers.Update(C);
            db.SaveChanges();
            return RedirectToAction("Booking");
        }
        [HttpGet]
        public IActionResult DeleteDetails(int id)
        {
            Customer C = db.customers.Find(id);
            return View(C);
        }
        [HttpPost]
        public IActionResult DeleteDetails(Customer C)
        {
            db.customers.Remove(C);
            db.SaveChanges();
            return RedirectToAction("Booking");
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Feedback(Feedback F)
        {
            db.feedbacks.Add(F);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RentCost()
        {
            return View(new RentalPayment());
        }

        [HttpPost]
        public IActionResult RentCost(RentalPayment R)
        {

            if (R.Charge >= 2000)
            {
                R.GST = R.Charge * 10 / 100;
            }
            else
            {
                R.GST = R.Charge * 5 / 100;
            }

            R.Total = R.Charge + R.GST;

            return View(R);

        }


    }
}
