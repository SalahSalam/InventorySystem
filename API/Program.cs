using ApplicationsLayer.Exeptions;
using ApplicationsLayer.Handlers.InventoryitemHandler;
using ApplicationsLayer.Handlers.InventoryItemHandler;
using ApplicationsLayer.Handlers.LocationHandler;
using ApplicationsLayer.Handlers.OrderHandler;
using ApplicationsLayer.Handlers.ProductHandler;
using ApplicationsLayer.Handlers.ProductMovementHandler;
using InfrastructureLayer;
using InfrastructureLayer.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

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

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("AllowAll");
app.MapControllers();

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

