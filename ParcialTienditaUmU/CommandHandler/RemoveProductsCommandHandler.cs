using ParcialTienditaUmU.Commands;
using ParcialTienditaUmU.Configuration;

namespace ParcialTienditaUmU.CommandHandler
{
    public class RemoveProductsCommandHandler : ICommandHandler<RemoveByIdCommands>
    {
        private readonly IUnitOfWork _unitOfWork; public RemoveProductsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CommandResult Execute(RemoveByIdCommands command)
        {
            _unitOfWork.ProductsRepository.Delete(command.Id);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Permission added succesfully" };
        }
    }
}
