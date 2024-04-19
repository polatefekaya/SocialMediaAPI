using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Infrastructure;
using RosanicSocial.Infrastructure.DatabaseContext;
using RosanicSocial.Infrastructure.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) => {
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});
builder.Services.AddHttpLogging(options => {
    options.LoggingFields = 
    Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders 
    | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
});
//logging
//#pragma warning disable CA1416 // Validate platform compatibility
//builder.Logging.ClearProviders()
//    .AddConsole()
//    .AddDebug()
//    .AddEventLog(); //TODO: Delete that on deploy, causing platform compatibility error
//#pragma warning restore CA1416 // Validate platform compatibility
//builder.Services.AddHttpLogging(logging => {
//});

builder.Services.AddControllers();

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();
app.UseHttpLogging();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
