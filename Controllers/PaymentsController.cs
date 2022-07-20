using Microsoft.AspNetCore.Mvc;
using RentalSystems.Models;

namespace RentalSystems.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View(new Payment());
        }

        [HttpPost]
        public IActionResult Index(Payment P)
        {
            if (P.Amount > 2000)
            {
                P.Offer = P.Amount * 10 / 100;
            }
            else if (P.Amount > 1200)
            {
                P.Offer = P.Amount * 5 / 100;
            }
            else
            {
                P.Offer = 0;
            }

            P.ToPay = P.Amount - P.Offer;

            return View(P);

        }

    }
}
