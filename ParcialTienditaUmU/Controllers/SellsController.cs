using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Controllers
{
    public class SellsController : Controller
    {
        private readonly ParcialTienditaUmUContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public SellsController(ParcialTienditaUmUContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Sells
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.SellsRepository.GetAllAsync());
        }

        // GET: Sells/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var sells = await _unitOfWork.SellsRepository.GetByIdAsync(id);
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

            _unitOfWork.SellsRepository.Add(sells);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Sells/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Sells == null)
            {
                return NotFound();
            }

            var sells = await _unitOfWork.SellsRepository.GetByIdAsync(id);
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


            try
            {
                _unitOfWork.SellsRepository.Update(sells);
                _unitOfWork.Commit();
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

        // GET: Sells/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Sells == null)
            {
                return NotFound();
            }

            var sells = await _unitOfWork.SellsRepository.GetByIdAsync(id);
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

            var sells = await _unitOfWork.SellsRepository.GetByIdAsync(id);
            if (sells != null)
            {
                _unitOfWork.SellsRepository.Delete(id);
            }

            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }

        private bool SellsExists(int id)
        {
            return _unitOfWork.SellsRepository.GetByIdAsync(id) != null;
        }
    }
}
