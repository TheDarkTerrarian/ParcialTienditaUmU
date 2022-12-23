using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Controllers
{
    public class SellsController : Controller
    {
        private readonly ParcialTienditaUmUContext _context;

        public SellsController(ParcialTienditaUmUContext context)
        {
            _context = context;
        }

        // GET: Sells
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sells.ToListAsync());
        }

        // GET: Sells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sells == null)
            {
                return NotFound();
            }

            var sells = await _context.Sells
                .FirstOrDefaultAsync(m => m.sellId == id);
            if (sells == null)
            {
                return NotFound();
            }

            return View(sells);
        }

        // GET: Sells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sellId,userId,sellDate,totalToPay")] Sells sells)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sells);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sells);
        }

        // GET: Sells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sells == null)
            {
                return NotFound();
            }

            var sells = await _context.Sells.FindAsync(id);
            if (sells == null)
            {
                return NotFound();
            }
            return View(sells);
        }

        // POST: Sells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sellId,userId,sellDate,totalToPay")] Sells sells)
        {
            if (id != sells.sellId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sells);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellsExists(sells.sellId))
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
            return View(sells);
        }

        // GET: Sells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sells == null)
            {
                return NotFound();
            }

            var sells = await _context.Sells
                .FirstOrDefaultAsync(m => m.sellId == id);
            if (sells == null)
            {
                return NotFound();
            }

            return View(sells);
        }

        // POST: Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sells == null)
            {
                return Problem("Entity set 'ParcialTienditaUmUContext.Sells'  is null.");
            }
            var sells = await _context.Sells.FindAsync(id);
            if (sells != null)
            {
                _context.Sells.Remove(sells);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellsExists(int id)
        {
          return _context.Sells.Any(e => e.sellId == id);
        }
    }
}
