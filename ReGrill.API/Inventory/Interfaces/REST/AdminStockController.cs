using System.Net.Mime;
using ReGrill.API.Inventory.Domain.Model.Queries;
using ReGrill.API.Inventory.Domain.Services;
using ReGrill.API.Inventory.Interfaces.REST.Resources;
using ReGrill.API.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ReGrill.API.Inventory.Domain.Model.ValueObjects;

namespace ReGrill.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("AdminStock")]
public class AdminStockController(
    IAdminStockCommandService adminStockCommandService,
    IAdminStockQueryService adminStockQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create new AdminStock",
        Description = "Create new AdminStock",
        OperationId = "CreateAdminStock")]
    [SwaggerResponse(StatusCodes.Status201Created, "The AdminStock was created", typeof(AdminStockResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The AdminStock could not be created")]
    public async Task<ActionResult> CreateAdminStock([FromBody] CreateAdminStockResource resource)
    {
        var createAdminStockCommand = CreateAdminStockCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var result = await adminStockCommandService.Handle(createAdminStockCommand);

        if (result is null)
            return BadRequest();
        
        return CreatedAtAction(nameof(GetAdminStockById), new { id = result.Id }, AdminStockResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get AdminStock by ID",
        Description = "Get an AdminStock source by the specified ID",
        OperationId = "GetAdminStockById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The AdminStock was found", typeof(AdminStockResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The AdminStock was not found")]
    public async Task<ActionResult> GetAdminStockById(int id)
    {
        var getAdminStockByIdQuery = new GetAdminStockByIdQuery(id);

        var result = await adminStockQueryService.Handle(getAdminStockByIdQuery);

        if (result is null)
            return NotFound();

        var resource = AdminStockResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(result);
    }

    [HttpGet("userId/{id}")]
    [SwaggerOperation(
        Summary = "Get AdminStock by UserId",
        Description = "Get AdminStock by UserId",
        OperationId = "GetAdminStockByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The AdminStock by UserId was found",
        typeof(IEnumerable<AdminStockResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No AdminStock found by UserId")]
    public async Task<ActionResult<IEnumerable<AdminStockResource>>> GetAdminStockByUserId(long id)
    {
        var userId = new UserId(id);
        var getAdminStockByUserIdQuery = new GetAdminStockByUserIdQuery(userId);
        var result = await adminStockQueryService.Handle(getAdminStockByUserIdQuery);
        if (result is null || !result.Any())
            return NotFound();
        var resources = result.Select(AdminStockResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}