using FluentValidation;
using FluentValidation.AspNetCore;
using Incidents.Application;
using Incidents.Application.Common.Interfaces;
using Incidents.Application.Common.Mappings;
using Incidents.Application.Incidents.Users.Commands.CreateUser;
using Incidents.Application.Incidents.Users.Commands.UpdateUser;
using Incidents.Application.Incidents.Users.Queries.GetAllUsers;
using Incidents.Application.Incidents.Users.Queries.GetUserByUserName;
using Incidents.Infrastructure;
using Incidents.WebUI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplicationt();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.Cookie.Name = "AuthCookieTaskManager";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("administrator", policy => policy.RequireClaim(ClaimTypes.Role, "Administrator"));
    options.AddPolicy("operator", policy => policy.RequireClaim(ClaimTypes.Role, "Operator"));
    options.AddPolicy("user", policy => policy.RequireClaim(ClaimTypes.Role, "User", "Administrator"));
});

builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
builder.Services.AddScoped<IValidator<GetAllUsersDto>, GetAllUsersDtoValidator>();
builder.Services.AddScoped<IValidator<GetUserByUserNameQuery>, GetUserByUserNameQueryValidator>();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(typeof(Program).Assembly));
    config.AddProfile(new AssemblyMappingProfile(typeof(IIncidentsDbContext).Assembly));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
