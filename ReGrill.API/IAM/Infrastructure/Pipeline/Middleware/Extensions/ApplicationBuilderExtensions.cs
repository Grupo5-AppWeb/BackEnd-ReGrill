using ReGrill.API.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace ReGrill.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
        => builder.UseMiddleware<RequestAuthorizationMiddleware>();
    
}