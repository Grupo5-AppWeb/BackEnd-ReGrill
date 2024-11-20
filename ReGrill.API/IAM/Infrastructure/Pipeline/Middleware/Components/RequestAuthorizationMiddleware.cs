using Microsoft.AspNetCore.Authorization;
using ReGrill.API.IAM.Application.Internal.OutboundContext;
using ReGrill.API.IAM.Domain.Model.Queries;
using ReGrill.API.IAM.Domain.Services.Users.Administration;
using ReGrill.API.IAM.Domain.Services.Users.Supply;

namespace ReGrill.API.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next, ILogger<RequestAuthorizationMiddleware>logger)
{
    public async Task InvokeAsync(HttpContext context, IAdministratorQueryService administratorQueryService, ISupplierQueryService supplierQueryService, ITokenService tokenService)
    {
        var endpoint = context.Request.HttpContext.GetEndpoint();
        
        var allowAnonymous =
            context.Request.HttpContext.GetEndpoint()!.Metadata.Any(m =>
                m.GetType() == typeof(AllowAnonymousAttribute));
        
        logger.LogInformation($"Endpoint: {endpoint?.DisplayName}, AllowAnonymous: {allowAnonymous}");
        
        if (allowAnonymous)
        {
            await next(context);

            return;
        }
        
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var tokenResult = tokenService.ValidateToken(token) ?? throw new Exception("Invalid Token!");

        dynamic? validation = null;
        
        // Only if I have more than 1 Aggregate 
        if (tokenResult.Role == "ROLE_MANAGER")
            validation = await administratorQueryService.Handle(new GetUserByIdQuery(tokenResult.Id));
        
        else if (tokenResult.Role == "ROLE_SUPPLIER")
            validation = await supplierQueryService.Handle(new GetUserByIdQuery(tokenResult.Id));
        
        if (validation is null)
            throw new Exception("Invalid credentials!");

        context.Items["Credentials"] = tokenResult;
        
        await next(context);
    }
}