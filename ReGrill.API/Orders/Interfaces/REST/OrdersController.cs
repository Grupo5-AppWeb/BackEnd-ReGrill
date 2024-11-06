using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
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
        var order = await orderCommandService.Handle(createOrderCommand);
        if (order == null) return BadRequest();
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = orderResource.OrderId }, orderResource);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation("Get Order", "Get order by id.", OperationId = "GetOrder")]
    [SwaggerResponse(200, "Order found.", typeof(OrderResource))]
    [SwaggerResponse(404, "Order not found.")]
    public async Task<IActionResult> GetOrderById(Guid orderId)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery(orderId);
        var order = await orderQueryService.Handle(getOrderByIdQuery);
        if (order is null) return NotFound();
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        return Ok(orderResource);
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
}