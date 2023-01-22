using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Services;

namespace ParcialTienditaUmU.Configuration
{
    public interface IUnitOfWork
    {

        IOrderRepository OrderRepository { get; }
        IProductsRepository ProductsRepository { get; }
        ISellsRepository SellsRepository { get; }
        IUsersRepository UsersRepository { get; }
        void Commit();
        void Dispose();

    }
}
