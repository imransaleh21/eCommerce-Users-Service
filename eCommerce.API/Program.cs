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
// Use authentication and authorization middleware.
app.UseAuthentication();
app.UseAuthorization();
// Map controller routes.
app.MapControllers();
app.Run();
