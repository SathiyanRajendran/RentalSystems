using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalSystems.Models;
using System;


using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

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
        
    }
}
