using Infrastructure.Identity;
using Infrastructure.Identity.Entities;
using Infrastructure.Identity.Seeds;
using Inventory.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddPersistenceInfrastructure(builder.Configuration)
    .AddIdentityInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Seeding database...");

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Seed roles 
        await DefaultRoles.SeedAsync(roleManager);
        logger.LogInformation("Roles seeded successfully");

        // Seed users
        await DefaultAdministrator.SeedAsync(userManager);
        logger.LogInformation("Administrator user seeded successfully");

        await DefaultInventoryUser.SeedAsync(userManager);
        logger.LogInformation("Basic user seeded successfully");

        logger.LogInformation("Database seeding completed");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database");
        throw;  
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
