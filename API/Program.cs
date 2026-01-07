using ApplicationsLayer.Exeptions;
using ApplicationsLayer.Handlers.InventoryitemHandler;
using ApplicationsLayer.Handlers.InventoryItemHandler;
using ApplicationsLayer.Handlers.LocationHandler;
using ApplicationsLayer.Handlers.OrderHandler;
using ApplicationsLayer.Handlers.ProductHandler;
using ApplicationsLayer.Handlers.ProductMovementHandler;
using ApplicationsLayer.Interfaces;
using InfrastructureLayer.Persistence;
using InfrastructureLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register handlers (Application layer)
builder.Services.AddScoped<GetAllProductsHandler>();
builder.Services.AddScoped<GetProductByIdHandler>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<UpdateProductDetailsHandler>();
builder.Services.AddScoped<UpdateProductMinimumStockHandler>();
builder.Services.AddScoped<GetProductsBelowMinimumStockHandler>();

builder.Services.AddScoped<GetAllInventoryItemsHandler>();
builder.Services.AddScoped<GetInventoryItemByIdHandler>();
builder.Services.AddScoped<GetInventoryByLocationHandler>();
builder.Services.AddScoped<UpdateInventoryQuantityHandler>();

builder.Services.AddScoped<GetAllOrdersHandler>();
builder.Services.AddScoped<GetOrderByIdHandler>();
builder.Services.AddScoped<GetOpenOrdersHandler>();
builder.Services.AddScoped<CreateOrderHandler>();
builder.Services.AddScoped<CloseOrderHandler>();

builder.Services.AddScoped<GetAllProductMovementsHandler>();
builder.Services.AddScoped<GetProductMovementByIdHandler>();
builder.Services.AddScoped<GetProductMovementsByProductHandler>();
builder.Services.AddScoped<GetProductMovementsByLocationHandler>();
builder.Services.AddScoped<GetProductMovementsByDateRangeHandler>();

builder.Services.AddScoped<GetAllLocationsHandler>();
builder.Services.AddScoped<CreateLocationHandler>();



builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Infrastructure registrations (DbContext + IGenericRepository<T>) sker i jeres Infrastructure-projekt,
// fx builder.Services.AddInfrastructure(builder.Configuration);
// (her viser vi bare at API IKKE bruger DbContext direkte)

var app = builder.Build();

// Global exception mapping ? controllers kan være “tynde”
app.UseExceptionHandler(handlerApp =>
{
    handlerApp.Run(async context =>
    {
        var feature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
        var ex = feature?.Error;

        var (status, title) = ex switch
        {
            NotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
            DomainValidationException => (StatusCodes.Status400BadRequest, "Validation error"),
            ArgumentException => (StatusCodes.Status400BadRequest, "Invalid request"),
            _ => (StatusCodes.Status500InternalServerError, "Server error")
        };

        context.Response.StatusCode = status;
        context.Response.ContentType = "application/problem+json";

        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = ex?.Message
        };

        await context.Response.WriteAsJsonAsync(problem);
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

//builder.Services.AddEndpointsApiExplorer(); // Adds support for minimal API endpoint discovery (for Swagger)
//builder.Services.AddSwaggerGen(); // Registers Swagger generator for API documentation

//// Configures CORS to allow any origin, method, and header
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "AllowAll",
//        policy =>
//        {
//            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        });
//});


//// Middleware to only allow GET and POST HTTP methods; returns 405 for others
//app.Use(async (context, next) =>
//{
//    var allowedMethods = new HashSet<string> { "GET", "POST" };
//    if (!allowedMethods.Contains(context.Request.Method))
//    {
//        context.Response.StatusCode = 405; // Method Not Allowed
//        await context.Response.WriteAsync("Method Not Allowed");
//        return;
//    }
//    await next();
//});

//// Configure MIME type whitelisting for static files
//var provider = new FileExtensionContentTypeProvider();
//provider.Mappings.Clear(); // Remove all default MIME type mappings

//// Add only allowed MIME types for static files
//provider.Mappings[".txt"] = "text/plain";
//provider.Mappings[".jpg"] = "image/jpeg";
//provider.Mappings[".png"] = "image/png";
//provider.Mappings[".pdf"] = "application/pdf";

//// Serve static files with the custom MIME type provider
//app.UseStaticFiles(new StaticFileOptions
//{
//    ContentTypeProvider = provider
//});

//app.UseHsts(); // Enforces HTTP Strict Transport Security (HSTS) for 1 year

//app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS

//app.UseSwagger(); // Enables Swagger middleware for API documentation

//app.UseSwaggerUI(); // Enables Swagger UI for interactive API docs

//app.UseCors("AllowAll"); // Applies the "AllowAll" CORS policy

//// Configure the HTTP request pipeline.
//app.UseHttpsRedirection(); // (Redundant, already called above) Ensures HTTPS redirection

//app.UseRouting(); // Adds routing middleware

//app.UseAuthorization(); // Adds authorization middleware

//app.MapControllers(); // Maps controller endpoints (for MVC/Web API)

//app.Run(); // Runs the application
