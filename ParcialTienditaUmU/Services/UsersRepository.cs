using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Services
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        
        public UsersRepository(ParcialTienditaUmUContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<User> GetByIdAsync(int id)
        {
            return await  _dbSet.FirstOrDefaultAsync(m => m.idUser == id);
        }

    }
}
