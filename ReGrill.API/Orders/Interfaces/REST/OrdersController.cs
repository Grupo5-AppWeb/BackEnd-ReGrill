using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ReGrill.API.Orders.Domain.Model.Commands;
using ReGrill.API.Orders.Domain.Model.Queries;
using ReGrill.API.Orders.Domain.Services;
using ReGrill.API.Orders.Interfaces.REST.Resources;
using ReGrill.API.Orders.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace ReGrill.API.Orders.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Order Endpoints")]
public class OrdersController(IOrderCommandService orderCommandService, IOrderQueryService orderQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create Order", "Create new order.", OperationId = "CreateOrder")]
    [SwaggerResponse(201, "Order created successfully.", typeof(OrderResource))]
    [SwaggerResponse(400, "The order was not created")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var createOrderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await orderCommandService.Handle(createOrderCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, OrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation("Get Order", "Get order by id.", OperationId = "GetOrder")]
    [SwaggerResponse(200, "Order found.", typeof(OrderResource))]
    [SwaggerResponse(404, "Order not found.")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var getOrderByIdQuery = new GetOrdersByIdQuery(id);
        var result = await orderQueryService.Handle(getOrderByIdQuery);
        if (result is null) return NotFound();
        var resource = OrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    [SwaggerOperation("Get All Orders", "Get all orders.", OperationId = "GetAllOrders")]
    [SwaggerResponse(200, "Orders found.", typeof(IEnumerable<OrderResource>))]
    [SwaggerResponse(404, "Orders not found.")]
    public async Task<IActionResult> GetAllOrders()
    {
        var getAllOrdersQuery = new GetAllOrdersQuery();
        var orders = await orderQueryService.Handle(getAllOrdersQuery);
        var orderResources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(orderResources);
    }

    [HttpDelete("{orderId:int}")]
    [SwaggerOperation(
        Summary = "Delete Order",
        Description = "Delete an order",
        OperationId = "DeleteOrder")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The Order was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Order was not found")]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        var resource = new DeleteOrderResource(orderId);
        var deleteOrderCommand = DeleteOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        await orderCommandService.Handle(deleteOrderCommand);
        return NoContent();
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update the order",
        Description = "Update an specified order",
        OperationId = "UpdateOrder")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "The Order was updated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Bad request")]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Order was not found")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderResource resource)
    {
        if (id <= 0 || resource.Id == 0)
            return BadRequest("Invalid resource data");
        var updateOrderCommand = UpdateOrderCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await orderCommandService.Handle(updateOrderCommand);
        if (result == null)
            return NotFound("The order was not found");
        return Ok("The order was updated successfully");
    }
}