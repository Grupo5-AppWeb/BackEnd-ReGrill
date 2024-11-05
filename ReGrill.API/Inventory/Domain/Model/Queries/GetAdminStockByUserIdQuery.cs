using ReGrill.API.Inventory.Domain.Model.Queries;
using ReGrill.API.Inventory.Domain.Model.ValueObjects;

namespace ReGrill.API.Inventory.Domain.Model.Queries;

public record GetAdminStockByUserIdQuery(UserId UserId);