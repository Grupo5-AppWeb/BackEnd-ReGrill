using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;
using ReGrill.API.Profile.Domain.Model.Queries;
using ReGrill.API.Profile.Domain.Services;
using ReGrill.API.Profile.Interfaces.Resources;
using ReGrill.API.Profile.Interfaces.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace AquaEngine.API.Control.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Users")]
public class UsersController(IUserCommandService userCommandService, 
    IUserQueryService userQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new user",
        Description = "Create a new user",
        OperationId = "CreateUser")]
    [SwaggerResponse(StatusCodes.Status201Created, "The user was created", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The user could not be created")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var result = await userCommandService.Handle(createUserCommand);
        
        if (result is null)
            return BadRequest();
        
        return CreatedAtAction(nameof(GetUserById), new { id = result.Id },
           UserResourceFromEntityAssembler.ToResourceFromEntity(result));
  
        
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a product by ID",
        Description = "Get a product source by the specified ID",
        OperationId = "GetProductById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was found", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        
        var result = await userQueryService.Handle(getUserByIdQuery);
        
        if (result is null)
            return NotFound();

        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(result);
    }
    
    [HttpGet("dni/{dni}")]
    [SwaggerOperation(
        Summary = "Get a user by DNI",
        Description = "Get a user by the specified DNI",
        OperationId = "GetUserByDni")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was found", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The user was not found")]
    public async Task<ActionResult> GetUserByDni(string dni)
    {
        var getUserByDniQuery = new GetUserByDniQuery(dni);

        var result = await userQueryService.Handle(getUserByDniQuery);

        if (result is null)
            return NotFound();

        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);

        return Ok(resource);
    }
}