using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Services
{
    public class SellsRepository : GenericRepository<Sells>, ISellsRepository
    {
        public SellsRepository(ParcialTienditaUmUContext context) : base(context)
        {
        }

        public override async Task<Sells> GetByIdAsync(int id)
        {
            return await  _dbSet.FirstOrDefaultAsync(m => m.sellId == id);
        }
    }
}
