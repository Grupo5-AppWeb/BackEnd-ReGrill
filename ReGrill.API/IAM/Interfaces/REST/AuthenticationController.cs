using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReGrill.API.IAM.Domain.Model.ValueObjects;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Administration;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Supplier;
using ReGrill.API.IAM.Domain.Services.Users.Administration;
using ReGrill.API.IAM.Domain.Services.Users.Supply;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Administration;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Supply;
using ReGrill.API.IAM.Interfaces.REST.Transform.Administration;
using ReGrill.API.IAM.Interfaces.REST.Transform.Anthentication;
using ReGrill.API.IAM.Interfaces.REST.Transform.Supply;

namespace ReGrill.API.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(
    IAdministratorCommandService administratorCommandService,
    IAdministratorCredentialCommandService administratorCredentialCommandService,
    ISupplierCommandService supplierCommandService,
    ISupplierCredentialCommandService supplierCredentialCommandService) : ControllerBase
{
    
    [HttpPost("sign-up-administrator")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpAdministrator([FromBody] SignUpAdministratorResource resource)
    {
        try
        {
            var signUpCommand = SignUpAdministratorCommandFromResourceAssembler.ToCommandFromResource(resource);

            var result = await administratorCommandService.Handle(signUpCommand);
            
            await administratorCredentialCommandService.Handle(new(result, resource.Password));

            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sign-up-supplier")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpSupplier([FromBody] SignUpSupplierResource resource)
    {
        try
        {
            var signUpCommand = SignUpSupplierCommandFromResourceAssembler.ToCommandFromResource(resource);

            var result = await supplierCommandService.Handle(signUpCommand);

            await supplierCredentialCommandService.Handle(new(result!.Id, resource.Password));

            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        try
        {
            if (!Enum.TryParse(resource.Role, out ERoles roles))
                return BadRequest("Role must exist!");

            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
             
            dynamic? authenticatedUser;

            if (roles == ERoles.ADMINISTRATOR)
                authenticatedUser=  await administratorCommandService.Handle(signInCommand);
            else
                authenticatedUser = await supplierCommandService.Handle(signInCommand);
            
            var authenticatedUserResource =
                AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser!.User,
                    authenticatedUser.Token);
            
            return Ok(authenticatedUserResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}