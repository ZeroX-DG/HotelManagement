using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class HouseKeepersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseKeepersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HouseKeepers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HouseKeepers.ToListAsync());
        }

        // GET: HouseKeepers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseKeeper = await _context.HouseKeepers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (houseKeeper == null)
            {
                return NotFound();
            }

            return View(houseKeeper);
        }

        // GET: HouseKeepers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseKeepers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Grade")] HouseKeeper houseKeeper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(houseKeeper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(houseKeeper);
        }

        // GET: HouseKeepers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseKeeper = await _context.HouseKeepers.FindAsync(id);
            if (houseKeeper == null)
            {
                return NotFound();
            }
            return View(houseKeeper);
        }

        // POST: HouseKeepers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,Grade")] HouseKeeper houseKeeper)
        {
            if (id != houseKeeper.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(houseKeeper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseKeeperExists(houseKeeper.ID))
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
            return View(houseKeeper);
        }

        // GET: HouseKeepers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseKeeper = await _context.HouseKeepers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (houseKeeper == null)
            {
                return NotFound();
            }

            return View(houseKeeper);
        }

        // POST: HouseKeepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var houseKeeper = await _context.HouseKeepers.FindAsync(id);
            _context.HouseKeepers.Remove(houseKeeper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseKeeperExists(string id)
        {
            return _context.HouseKeepers.Any(e => e.ID == id);
        }
    }
}
