using AdvertisingSystem.Api.PolicyRequirements;
using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Bll.Services;
using AdvertisingSystem.Dal;
using AdvertisingSystem.Dal.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.MapType(typeof(TimeOnly), () => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("12:00")
    });
});

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(WebApiProfile));

builder.Services.AddTransient<ITransportCompanyService, TransportCompanyService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IAdOrganiserService, AdOrganiserService>();
builder.Services.AddTransient<IAdvertiserService, AdvertiserService>();

builder.Services.AddSingleton<IAuthorizationHandler, UserIsResourceOwnerHandler>();

// ASP.net automatically redirects to a login page when 401 or 403 statusCode is the answer.
// This doesn't make sense in a WebAPI, so we disable it here.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = ctx =>
        {
            ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = ctx =>
        {
            ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };

    });

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("RequiredAdvertiserRole", policy => policy.RequireRole("advertiser"));
        options.AddPolicy("RequiredTransportCompanyRole", policy => policy.RequireRole("transportcompany"));
        options.AddPolicy("RequiredAdOrganiserRole", policy => policy.RequireRole("adorganiser"));
        options.AddPolicy("RequiredSameID", policy =>
        {
            policy.Requirements.Add(new UserIsResourceOwnerRequirement());
        });
    });

//https://stackoverflow.com/questions/52697550/
// We can only add multiple user groups with identityCore
builder.Services.AddIdentityCore<AdOrganiser>()
    .AddRoles<IdentityRole<int>>()
    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<AdOrganiser, IdentityRole<int>>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Advertiser>()
    .AddRoles<IdentityRole<int>>()
    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Advertiser, IdentityRole<int>>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<TransportCompany>()
    .AddRoles<IdentityRole<int>>()
    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<TransportCompany, IdentityRole<int>>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
