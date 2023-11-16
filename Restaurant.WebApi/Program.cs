
using Restaurant.Infrastructure.Persistence;
using Restaurant.Infrastructure.Identity;
using Restaurant.Core.Application;
using Microsoft.AspNetCore.Identity;
using Restaurant.Infrastructure.Identity.Seeds;
using Restaurant.Infrastructure.Identity.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddIdentityLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);

        await DefaultSuperUser.SeedAsync(userManager, roleManager);
        await DefaultAdminUser.SeedAsync(userManager, roleManager);
        await DefaultWaiterUser.SeedAsync(userManager, roleManager);

    }
    catch (Exception ex)
    {

    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
