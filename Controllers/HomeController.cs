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
        public IActionResult CreateQRCode()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQRCode(QRCode qrCode)
        {
            try 
            { 


            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(qrCode.QRCodeText, 200);
            barcode.AddBarcodeValueTextBelowBarcode();
            // Styling a QR code and adding annotation text
            barcode.SetMargins(10);
            barcode.ChangeBarCodeColor(Color.BlueViolet);
            string path = Path.Combine(db.WebRootPath, "GeneratedQRCode");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(db.WebRootPath, "GeneratedQRCode/qrcode");
            barcode.SaveAsPng(filePath);
            string fileName = Path.GetFileName(filePath);
            string imageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
            ViewBag.QrCodeUri = imageUrl;
        }

            catch (Exception)
            {
                throw;
            }
            return View();
        }
    }
        
    
}
