using WebApiExample.Domain.Configuration;
using System.Net;

namespace WebApiExample.Domain.Auth.Middleware;

public class ApiKeyMiddleware(RequestDelegate next, IApiKeyValidation apiKeyValidation, IConfiguration configuration)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var requestApiKey = context.Request.Headers[configuration.GetValue<string>(Constants.ApiConfigKeyHeaderName) ?? string.Empty];

        if (string.IsNullOrEmpty(requestApiKey))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }

        if (!apiKeyValidation.IsValid(requestApiKey))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }

        await next(context);
    }
}