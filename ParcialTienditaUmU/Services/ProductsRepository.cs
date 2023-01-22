using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Services
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(ParcialTienditaUmUContext context) : base(context)
        {
        }

        public override async Task<Products> GetByIdAsync(int id)
        {
            return  await _dbSet.FirstOrDefaultAsync(m => m.idProduct == id);

        }
    }
}
