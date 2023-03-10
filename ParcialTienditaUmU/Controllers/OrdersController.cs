using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ParcialTienditaUmUContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(ParcialTienditaUmUContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
              return View(await _unitOfWork.OrderRepository.GetAllAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var orders = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orderId,userId,orderDate,totalPrice")] Orders orders)
        {
            
                _unitOfWork.OrderRepository.Add(orders);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var orders = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orderId,userId,orderDate,totalPrice")] Orders orders)
        {
            if (id != orders.orderId)
            {
                return NotFound();
            }

            
                try
                {
                    _unitOfWork.OrderRepository.Update(orders);
                    _unitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.orderId))
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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ParcialTienditaUmUContext.Orders'  is null.");
            }
            var orders = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (orders != null)
            {
                _unitOfWork.OrderRepository.Delete(id);
            }
            
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
          return _unitOfWork.OrderRepository.GetByIdAsync(id) != null;
        }
    }
}
