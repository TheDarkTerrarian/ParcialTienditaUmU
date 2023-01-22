using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Controllers
{
    public class UsersController : Controller
    {
        private readonly ParcialTienditaUmUContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(ParcialTienditaUmUContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.UsersRepository.GetAllAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var user = await _unitOfWork.UsersRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUser,username,password,fullName,rol,isAdmin")] User user)
        {

            _unitOfWork.UsersRepository.Add(user);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));


        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.UsersRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUser,username,password,fullName,rol,isAdmin")] User user)
        {
            if (id != user.idUser)
            {
                return NotFound();
            }


            try
            {
               _unitOfWork.UsersRepository.Update(user);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.idUser))
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

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.UsersRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ParcialTienditaUmUContext.User'  is null.");
            }

            var users = await _unitOfWork.UsersRepository.GetByIdAsync(id);
            if (users != null)
            {
                _unitOfWork.UsersRepository.Delete(id);
            }

            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _unitOfWork.UsersRepository.GetByIdAsync(id) != null;
        }
    }
}
