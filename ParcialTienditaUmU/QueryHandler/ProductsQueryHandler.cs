using ParcialTienditaUmU.Commands;
using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.QueryHandler
{
    public class ProductsQueryHandler : IQueryHandler<Products, QueryByIdCommands>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _unitOfWork.ProductsRepository.GetAllAsync();
        }
        public async Task<Products> GetOne(QueryByIdCommands query)
        {
            return await _unitOfWork.ProductsRepository.GetByIdAsync(query.Id);
        }
    }
}
