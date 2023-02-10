using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.CommandHandler
{
    public class UpdateProductsCommandHandler : ICommandHandler<Products>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CommandResult Execute(Products product)
        {
            _unitOfWork.ProductsRepository.Update(product);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Product updated succesfully" };
        }
    }
}
