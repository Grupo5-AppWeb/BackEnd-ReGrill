namespace ReGrill.API.IAM.Application.Internal.OutboundContext;

public interface ITokenService
{
    string GenerateToken(dynamic user);
    
    dynamic? ValidateToken(string? token);
}