using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ParcialTienditaUmUContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(ParcialTienditaUmUContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.ProductsRepository.GetAllAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var products = await _unitOfWork.ProductsRepository.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProduct,productName,productPrice,stock,category")] Products products)
        {

            _unitOfWork.ProductsRepository.Add(products);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));


        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var products = await _unitOfWork.ProductsRepository.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProduct,productName,productPrice,stock,category")] Products products)
        {
            if (id != products.idProduct)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.ProductsRepository.Update(products);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(products.idProduct))
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

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _unitOfWork.ProductsRepository.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ParcialTienditaUmUContext.Products'  is null.");
            }

            var products = await _unitOfWork.ProductsRepository.GetByIdAsync(id);
            if (products != null)
            {
                _unitOfWork.ProductsRepository.Delete(id);
            }

            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _unitOfWork.ProductsRepository.GetByIdAsync(id) != null;
        }
    }
}
