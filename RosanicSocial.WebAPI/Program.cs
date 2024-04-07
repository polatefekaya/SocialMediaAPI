using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application;
using RosanicSocial.Infrastructure;
using RosanicSocial.Infrastructure.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
