using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BougieCandles.Data;
using BougieCandles.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BougieCandles.ViewModels;

namespace BougieCandles.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customer.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _context.Customer
            .Include(c => c.IdentityUser)
            .FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            //ViewData["CandleId"] = new SelectList(_context.Candles, "CandleId", "CandleId");
            ViewData["IdentityUserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Address,Name,ZipCode,IdentityUserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CandleId"] = new SelectList(_context.Candles, "CandleId", "CandleId", customer.CandleId);
            ViewData["IdentityUserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customer/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            //ViewData["CandleId"] = new SelectList(_context.Candles, "CandleId", "CandleId", customer.CandleId);
            //ViewData["IdentityUserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,Name,ZipCode,IdentityUserId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            //ViewData["CandleId"] = new SelectList(_context.Candles, "CandleId", "CandleId", customer.CandleId);
            ViewData["IdentityUserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
