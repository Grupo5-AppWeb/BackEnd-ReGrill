using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ReGrill.API.SupplierOrders.Domain.Model.Queries;
using ReGrill.API.SupplierOrders.Domain.Services;
using ReGrill.API.SupplierOrders.Interfaces.REST.Resources;
using ReGrill.API.SupplierOrders.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace ReGrill.API.SupplierOrders.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Supplier Orders Endpoints")]
public class SupplierOrderController(ISupplierOrderCommandService supplierOrderCommandService, ISupplierOrderQueryService supplierOrderQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create Supplier Order", "Create new supplier order.", OperationId = "CreateSupplierOrder")]
    [SwaggerResponse(201, "Supplier order created successfully.", typeof(SupplierOrderResource))]
    [SwaggerResponse(400, "The supplier order was not created")]
    public async Task<IActionResult> CreateSupplierOrder([FromBody] CreateSupplierOrderResource resource)
    {
        var createSupplierOrderCommand = CreateSupplierOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await supplierOrderCommandService.Handle(createSupplierOrderCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetSupplierOrderId), new { id = result.Id }, SupplierOrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation("Get Supplier Order", "Get supplier order by id.", OperationId = "GetSupplierOrderId")]
    [SwaggerResponse(200, "Supplier Order found.", typeof(SupplierOrderResource))]
    [SwaggerResponse(404, "Supplier Order not found.")]
    public async Task<IActionResult> GetSupplierOrderId(int id)
    {
        var getSupplierOrderByIdQuery = new GetSupplierOrderByIdQuery(id);
        var result = await supplierOrderQueryService.Handle(getSupplierOrderByIdQuery);
        if (result is null) return NotFound();
        var resource = SupplierOrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    [SwaggerOperation("Get All Supplier Orders", "Get all supplier orders.", OperationId = "GetAllSuplierOrders")]
    [SwaggerResponse(200, "Supplier Orders found.", typeof(IEnumerable<SupplierOrderResource>))]
    [SwaggerResponse(404, "Supplier Orders not found.")]
    public async Task<IActionResult> GetAllSupplierOrders()
    {
        var getAllSupplierOrderQuery = new GetAllSupplierOrderQuery();
        var supplierOrders = await supplierOrderQueryService.Handle(getAllSupplierOrderQuery);
        var supplierOrdersResource = supplierOrders.Select(SupplierOrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(supplierOrdersResource);
    }
}