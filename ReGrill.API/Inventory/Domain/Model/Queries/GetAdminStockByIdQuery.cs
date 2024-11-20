namespace ReGrill.API.Inventory.Domain.Model.Queries;

/// <summary>
///     Query to get a AdminStock by StockId
/// </summary>
/// <param name="StockId">The Source StockId to search</param>
public record GetAdminStockByIdQuery(long StockId);