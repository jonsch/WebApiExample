namespace WebApiExample.Domain.Configuration;

public class ApiKeyValidation(IConfiguration configuration) : IApiKeyValidation
{
    public bool IsValid(string requestApiKey)
    {
        if (string.IsNullOrEmpty(requestApiKey))
            return false;

        var apiKey = configuration.GetValue<string>(Constants.ApiConfigKeyName);
        return apiKey is not null && apiKey == requestApiKey;
    }
}