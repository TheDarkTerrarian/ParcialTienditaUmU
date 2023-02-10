using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Commands;
using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.DTOs;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ParcialTienditaUmUContext _context;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICommandHandler<ProductsDTO> _productsCommandHandler;
        private readonly ICommandHandler<RemoveByIdCommands> _removeCommandHandler;
        private readonly IQueryHandler<Products, QueryByIdCommands> _productsQueryHandler;
        private readonly ICommandHandler<Products> _updateCommandHandler;

        public ProductsController(ParcialTienditaUmUContext context, IUnitOfWork unitOfWork, ICommandHandler<Products> updateCommandHandler, IQueryHandler<Products, QueryByIdCommands> productsQueryHandler, ICommandHandler<RemoveByIdCommands> removeCommandHandler, ICommandHandler<ProductsDTO> productsCommandHandler)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _productsQueryHandler = productsQueryHandler;
            _productsCommandHandler= productsCommandHandler;
            _removeCommandHandler= removeCommandHandler;
            _updateCommandHandler = updateCommandHandler;    
        }

        // GET: Products
        public async Task<ActionResult<IEnumerable<Products>>> Index()
        {
            return View(await _productsQueryHandler.GetAll());
        }

        // GET: Products/Details/5
        public async Task<ActionResult<IEnumerable<Products>>> Details(int id)
        {

            var products = await _productsQueryHandler.GetOne(new QueryByIdCommands() { 
                Id = id
            });
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
        public async Task<IActionResult> Create([Bind("idProduct,productName,productPrice,stock,category")] ProductsDTO products)
        {

            _productsCommandHandler.Execute(products);        
            return RedirectToAction(nameof(Index));


        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var products = await _productsQueryHandler.GetOne(new QueryByIdCommands()
            {
                Id = id
            });
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
                _updateCommandHandler.Execute(products);
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

            var products = await _productsQueryHandler.GetOne(new QueryByIdCommands() { Id = id });
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
                _removeCommandHandler.Execute(new RemoveByIdCommands() { Id = id });
            }
         
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _productsQueryHandler.GetOne(new QueryByIdCommands()
            {
                Id = id
            })!= null;
        }
    }
}
