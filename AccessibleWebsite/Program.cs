using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Repositories;
using RepositoryLayer.UnitOfWorks;
using ServiceLayer.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IAccessibleUserRepository, AccessibleUserRepository>();
builder.Services.AddScoped<IAccessibleUserService, AccessibleUserService>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
	{
		option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
	});

});
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
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
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
