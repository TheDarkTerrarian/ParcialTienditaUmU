using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU
{
    public interface IQueryHandler<M, C> where M : class where C : class
    {
        Task<IEnumerable<M>> GetAll();
        Task<Products> GetOne(C query);
    }
}
