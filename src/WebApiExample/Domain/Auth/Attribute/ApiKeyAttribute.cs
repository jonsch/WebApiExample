using Microsoft.AspNetCore.Mvc;
using WebApiExample.Domain.Filter;

namespace WebApiExample.Domain.Attribute;

public class ApiKeyAttribute() : ServiceFilterAttribute(typeof(ApiKeyAuthFilter));