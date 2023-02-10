using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.DTOs;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.CommandHandler
{
    public class AddProductsCommandHandler : ICommandHandler<ProductsDTO>
    {
        private readonly IUnitOfWork _unitOfWork; public AddProductsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CommandResult Execute(ProductsDTO product)
        {
            var newProduct = new Products()
            {
                idProduct = product.idProduct,
                productName = product.productName,
                productPrice = product.productPrice,
                stock = product.stock,
                category= product.category,
            };
            _unitOfWork.ProductsRepository.Add(newProduct);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Permission added succesfully" };
        }
    }
}
