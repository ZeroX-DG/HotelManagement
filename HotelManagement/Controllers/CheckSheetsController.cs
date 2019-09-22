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
    public class CheckSheetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckSheetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckSheets
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckSheets.ToListAsync());
        }

        // GET: CheckSheets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkSheet = await _context.CheckSheets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (checkSheet == null)
            {
                return NotFound();
            }

            return View(checkSheet);
        }

        // GET: CheckSheets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StartTime,EndTime,Notes")] CheckSheet checkSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkSheet);
        }

        // GET: CheckSheets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkSheet = await _context.CheckSheets.FindAsync(id);
            if (checkSheet == null)
            {
                return NotFound();
            }
            return View(checkSheet);
        }

        // POST: CheckSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,StartTime,EndTime,Notes")] CheckSheet checkSheet)
        {
            if (id != checkSheet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckSheetExists(checkSheet.ID))
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
            return View(checkSheet);
        }

        // GET: CheckSheets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkSheet = await _context.CheckSheets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (checkSheet == null)
            {
                return NotFound();
            }

            return View(checkSheet);
        }

        // POST: CheckSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var checkSheet = await _context.CheckSheets.FindAsync(id);
            _context.CheckSheets.Remove(checkSheet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckSheetExists(string id)
        {
            return _context.CheckSheets.Any(e => e.ID == id);
        }
    }
}
