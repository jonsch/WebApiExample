using Microsoft.AspNetCore.Authorization;
using WebApiExample.Domain.Configuration;

namespace WebApiExample.Domain.Auth.Handler;

public class ApiKeyHandler(
    IHttpContextAccessor httpContextAccessor,
    IApiKeyValidation apiKeyValidation,
    IConfiguration configuration)
    : AuthorizationHandler<ApiKeyRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
    {
        var requestApiKey = httpContextAccessor?.HttpContext?.Request.Headers[configuration.GetValue<string>(Constants.ApiConfigKeyHeaderName) ?? string.Empty];

        if (string.IsNullOrEmpty(requestApiKey))
        {
            context.Fail();
            return Task.CompletedTask;
        }

        if (!apiKeyValidation.IsValid(requestApiKey))
        {
            context.Fail();
            return Task.CompletedTask;
        }
        
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}