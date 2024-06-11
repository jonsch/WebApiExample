using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OData.ModelBuilder;
using WebApiExample.Controllers;
using WebApiExample.Domain.Auth.Handler;
using WebApiExample.Domain.Configuration;
using WebApiExample.Domain.Database.DbContext;
using WebApiExample.Domain.Entities.Customers;
using WebApiExample.Domain.Entities.OrderDetails;
using WebApiExample.Domain.Entities.Orders;
using WebApiExample.Domain.Entities.Products;
using WebApiExample.Domain.Filter;
using WebApiExample.Domain.Repositories;
using WebApiExample.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

/* init auth/auth */
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer();

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ApiKeyPolicy", policy =>
        {
            policy.AddAuthenticationSchemes(new[] { JwtBearerDefaults.AuthenticationScheme });
            policy.Requirements.Add(new ApiKeyRequirement());
        });
    }
);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IAuthorizationHandler, ApiKeyHandler>();

/* auth services */
builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();
builder.Services.AddScoped<ApiKeyAuthFilter>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* add our di services */
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(IOrderDetailRepository<OrderDetail>), typeof(OrderDetailRepository));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

/* add controllers since we're not using endpoints, though we could */
builder.Services.AddControllers();

/* add odata */
builder.Services.AddControllers().AddOData(opt => {
    var modelBuilder = new ODataConventionModelBuilder();

    // setup entity set
    modelBuilder.EntitySet<Order>("Orders");
    modelBuilder.EntitySet<OrderDetail>("OrderDetails");
    modelBuilder.EntitySet<Product>("Products");
    modelBuilder.EntitySet<Customer>("Customers");

    // setup options
    opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100).AddRouteComponents("odata", modelBuilder.GetEdmModel());
});

var app = builder.Build();

/* add swagger for development, dependent on need or I would enable this for customer public product */
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* if we didn't want to use auth policies on specific api controllers and just blanket auth via middleware */
//app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

/* run migrations as part of the startup, if this were a scaling app-service we may want to isolate this process for SOC
    and to ensure data operations do not trip over themselves */
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.Run();