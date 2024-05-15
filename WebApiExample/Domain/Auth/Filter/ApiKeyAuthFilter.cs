using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiExample.Domain.Configuration;

namespace WebApiExample.Domain.Filter;

public class ApiKeyAuthFilter(IApiKeyValidation apiKeyValidation, IConfiguration configuration)
    : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var requestApiKey = context.HttpContext.Request.Headers[configuration.GetValue<string>(Constants.ApiConfigKeyHeaderName)];

        if (string.IsNullOrEmpty(requestApiKey))
        {
            context.Result = new BadRequestResult();
            return;
        }

        if (!apiKeyValidation.IsValid(requestApiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}