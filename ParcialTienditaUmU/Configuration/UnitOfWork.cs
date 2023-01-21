using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Services;

namespace ParcialTienditaUmU.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ParcialTienditaUmUContext _context;
        public IOrderRepository OrderRepository { get; private set; }

        public UnitOfWork(ParcialTienditaUmUContext context) {
            _context = context;
            OrderRepository = new OrderRepository(context);
        }

        public void Commit() { _context.SaveChanges(); }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
