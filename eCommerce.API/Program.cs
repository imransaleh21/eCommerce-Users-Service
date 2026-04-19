using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// Add Infrastructure services to the container.
builder.Services.AddInfrastructure();
// Add Core services to the container.
builder.Services.AddCore();
// Add controllers to the container.
builder.Services.AddControllers();
// Add AutoMapper services to the container, specifying the assembly that contains the mapping profiles.
// Here assembly is determined by the ApplicationUserMappingProfile class, So that further mapping profiles in the same assembly will also be registered automatically.
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile).Assembly);

// Enable FluentValidation auto-validation (temporary approach)
builder.Services.AddFluentValidationAutoValidation();
// Add API explorer services to the container, which will allow the application to discover and describe API endpoints for documentation purposes.
builder.Services.AddEndpointsApiExplorer();
// Add Swagger generation services to the container, which will generate Swagger/OpenAPI documentation for the API endpoints.
builder.Services.AddSwaggerGen();
// Add CORS services to the container, which will allow the application to specify cross-origin resource sharing policies for the API endpoints.
builder.Services.AddCors( options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
var app = builder.Build();

// Use custom exception handling middleware to catch and log exceptions globally.
app.UseExceptionHandlingMiddleware();
// Use HTTPS redirection middleware to redirect HTTP requests to HTTPS.
app.UseHsts();
app.UseHttpsRedirection();
// Use static files middleware to serve static files from the wwwroot folder.
app.UseStaticFiles();
// Use routing middleware to route incoming HTTP requests to the appropriate controllers and actions.
app.UseRouting();
// Use Swagger middleware to serve the generated Swagger/OpenAPI documentation as a JSON endpoint, which can be accessed by tools like Swagger UI or Postman for API testing and exploration.
app.UseSwagger();
// Use Swagger UI middleware to serve the Swagger UI, which provides an interactive interface for exploring and testing the API endpoints.
app.UseSwaggerUI();
// Use CORS middleware to enable Cross-Origin Resource Sharing (CORS) for the API, allowing requests from different origins to access the API resources.
app.UseCors();
// Use authentication and authorization middleware.
app.UseAuthentication();
app.UseAuthorization();
// Map controller routes.
app.MapControllers();
app.Run();
