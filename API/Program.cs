using ApplicationsLayer; 
using ApplicationsLayer.Interfaces; 
using InfrastructureLayer; 
using InfrastructureLayer.Persistence; 
using InfrastructureLayer.Repositories; 
using InventorySystem.Domain.Entities; 
using Microsoft.AspNetCore.StaticFiles; 
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args); // Creates a new web application builder

// Add services to the container.
builder.Services.AddControllers(); // Registers controllers for MVC/Web API

// Registers the generic repository for InventoryItem with scoped lifetime
builder.Services.AddScoped<IGenericRepository<InventoryItem>, GenericRepository<InventoryItem>>();

// builder.Services.AddSingleton<OrderHistoryRepository>(new OrderHistoryRepository()); // Example for registering another repository (commented out)

builder.Services.AddEndpointsApiExplorer(); // Adds support for minimal API endpoint discovery (for Swagger)
builder.Services.AddSwaggerGen(); // Registers Swagger generator for API documentation

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("YourConnectionStringHere"));


// Configures CORS to allow any origin, method, and header
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

var app = builder.Build(); // Builds the web application

// Middleware to only allow GET and POST HTTP methods; returns 405 for others
app.Use(async (context, next) =>
{
    var allowedMethods = new HashSet<string> { "GET", "POST" };
    if (!allowedMethods.Contains(context.Request.Method))
    {
        context.Response.StatusCode = 405; // Method Not Allowed
        await context.Response.WriteAsync("Method Not Allowed");
        return;
    }
    await next();
});


// Configure MIME type whitelisting for static files
var provider = new FileExtensionContentTypeProvider();
provider.Mappings.Clear(); // Remove all default MIME type mappings

// Add only allowed MIME types for static files
provider.Mappings[".txt"] = "text/plain";
provider.Mappings[".jpg"] = "image/jpeg";
provider.Mappings[".png"] = "image/png";
provider.Mappings[".pdf"] = "application/pdf";

// Serve static files with the custom MIME type provider
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseHsts(); // Enforces HTTP Strict Transport Security (HSTS) for 1 year

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS

app.UseSwagger(); // Enables Swagger middleware for API documentation

app.UseSwaggerUI(); // Enables Swagger UI for interactive API docs

app.UseCors("AllowAll"); // Applies the "AllowAll" CORS policy

// Configure the HTTP request pipeline.
app.UseHttpsRedirection(); // (Redundant, already called above) Ensures HTTPS redirection

app.UseRouting(); // Adds routing middleware

app.UseAuthorization(); // Adds authorization middleware

app.MapControllers(); // Maps controller endpoints (for MVC/Web API)

app.Run(); // Runs the application