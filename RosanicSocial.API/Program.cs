using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Application;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Infrastructure;
using RosanicSocial.Infrastructure.DatabaseContext;
using RosanicSocial.Infrastructure.Repository;
using Serilog;
using System.Text;

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

builder.Services.AddControllers(options => {
    options.Filters.Add(new ProducesAttribute("application/json"));
    options.Filters.Add(new ConsumesAttribute("application/json"));

    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters() {
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
    //.AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorization(options => {
});

var connection = String.Empty;
if (builder.Environment.IsDevelopment()) {
    //builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("Default");
    //connection = builder.Configuration.GetConnectionString("DefaultConnection");
} else {
    connection = Environment.GetEnvironmentVariable("Default");
}

builder.Services.AddDbContext<InfoDbContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddDbContext<InteractionDbContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddDbContext<SharingsDbContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddDbContext<ReportsDbContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddDbContext<StatisticsDbContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddDbContext<UserCriticalDbContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddDbContext<UserIdentityDbContext>(options => {
    options.UseSqlServer(connection);
    options.EnableSensitiveDataLogging();
});

//Swagger
builder.Services.AddApiVersioning(config => {
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
})
    .AddApiExplorer(options => {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "1.0", Title = "Social Media API"});
    options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "2.0", Title = "Social Media API" });
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 5;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
    .AddEntityFrameworkStores<UserIdentityDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, UserIdentityDbContext, int>>()
    .AddRoleStore<RoleStore<ApplicationRole, UserIdentityDbContext, int>>();

var app = builder.Build();
app.UseHttpLogging();

// Configure the HTTP request pipeline.
app.UseHsts();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
