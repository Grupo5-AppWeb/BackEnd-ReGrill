using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Inventory.Domain.Model.Commands;
using ReGrill.API.Inventory.Domain.Repositories;
using ReGrill.API.Inventory.Domain.Services;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.Inventory.Application.Internal.CommandServices;

public class AdminStockCommandService : IAdminStockCommandService
{
    private readonly IAdminStockRepository _adminStockRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public AdminStockCommandService(IAdminStockRepository adminStockRepository, IUnitOfWork unitOfWork)
    {
        _adminStockRepository = adminStockRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<AdminStock?> Handle(CreateAdminStockCommand command)
    {
        var adminStock = new AdminStock(command);

        await _adminStockRepository.AddAsync(adminStock);

        await _unitOfWork.CompleteAsync();

        return adminStock;
    }
}