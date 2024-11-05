using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Inventory.Domain.Model.Commands;

namespace ReGrill.API.Inventory.Domain.Services;

public interface IAdminStockCommandService
{
    Task<AdminStock?> Handle(CreateAdminStockCommand command);
}