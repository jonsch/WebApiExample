namespace WebApiExample.Domain.Configuration;

public interface IApiKeyValidation
{
    bool IsValid(string apiKey);
}