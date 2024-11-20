using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ReGrill.API.IAM.Domain.Model.Queries;
using ReGrill.API.IAM.Domain.Services.Roles;
using ReGrill.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using ReGrill.API.IAM.Interfaces.REST.Transform.Anthentication;

namespace ReGrill.API.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RoleController(IRoleQueryService roleQueryService) : ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        try
        {
            var roles = await roleQueryService.Handle(new GetAllRolesQuery());

            var roleResources = roles.Select(RoleResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(roleResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}