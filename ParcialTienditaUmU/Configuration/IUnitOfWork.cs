using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Services;

namespace ParcialTienditaUmU.Configuration
{
    public interface IUnitOfWork
    {

        IOrderRepository OrderRepository { get; }
        void Commit();
        void Dispose();

    }
}
