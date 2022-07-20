using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalSystems.Models;

namespace RentalSystems.Controllers
{
    public class OwnersController : Controller
    {
        private readonly OwnerDbContext _context;

        public OwnersController(OwnerDbContext context)
        {
            _context = context;
        }

        // GET: Owners
        public async Task<IActionResult> Index()
        {
            ViewBag.AdminName = HttpContext.Session.GetString("adminname");
            if (ViewBag.AdminName != null)
            {


                return View(await _context.owners.ToListAsync());
            }
            else
            {

                return RedirectToAction("AdminLogin", "Login");
            }
            //if (option == "VehicleNo")
            //{
            //    //Index action method will return a view with a student records based on what a user specify the value in textbox  
            //    return View(_context.owners.Where(x => x.VehicleNo == search || search == null).ToList());
            //}
            //else if (option == "Model")
            //{
            //    return View(_context.owners.Where(x => x.Model == search || search == null).ToList());
            //}
            //else
            //{
            //    return View(_context.owners.Where(x => x.CompanyName.StartsWith(search) || search == null).ToList());
            //}
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.owners
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,VehicleNo,CompanyName,Model,Availability,Photo,Rentalperday,Stocks")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(owner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,VehicleNo,CompanyName,Model,Availability,Photo,Rentalperday,Stocks")] Owner owner)
        {
            if (id != owner.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.VehicleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.owners
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.owners.FindAsync(id);
            _context.owners.Remove(owner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
            return _context.owners.Any(e => e.VehicleId == id);
        }
        //public IActionResult SearchForm()
        //{
        //    return View();
        //}

        //public IActionResult SearchResult(string SearchPhrase)
        //{
        //    return View(_context.owners.Where(i => i.Model.Contains(SearchPhrase)).ToList());
        //}

        public IActionResult SearchForm()
        {
            return View();
        }
        public IActionResult SearchResult(string SearchPhrase)
        {
            return View(_context.owners.Where(i => i.Model.Contains(SearchPhrase)).ToList());
        }



    }
}
