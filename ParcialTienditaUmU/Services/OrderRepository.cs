using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Services
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        public OrderRepository(ParcialTienditaUmUContext context) : base(context)
        {
        }
        public override async Task<Orders> GetByIdAsync(int id) {
            return await _dbSet.FirstOrDefaultAsync(m => m.orderId == id);
        }
    }
}