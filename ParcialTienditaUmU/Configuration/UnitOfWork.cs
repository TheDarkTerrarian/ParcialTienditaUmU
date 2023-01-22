using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.Services;

namespace ParcialTienditaUmU.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ParcialTienditaUmUContext _context;
        public IOrderRepository OrderRepository { get; private set; }

        public IProductsRepository ProductsRepository { get; private set; }

        public ISellsRepository SellsRepository { get; private set; }

        public IUsersRepository UsersRepository { get; private set; }

        public UnitOfWork(ParcialTienditaUmUContext context)
        {
            _context = context;
            OrderRepository = new OrderRepository(context);
            ProductsRepository = new ProductsRepository(context);
            SellsRepository = new SellsRepository(context);
            UsersRepository = new UsersRepository(context);
        }

        public void Commit() { _context.SaveChanges(); }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
