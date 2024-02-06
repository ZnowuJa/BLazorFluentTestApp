using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Application.Interfaces.Identity.Services;
public interface ITokenValidatedHandlerService
{
    Task HandleTokenValidation(TokenValidatedContext context);
}