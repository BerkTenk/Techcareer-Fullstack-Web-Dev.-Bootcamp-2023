using BitirmeProjesi.Data;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("database");
    options.UseSqlite(connectionString);
});
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
.AddEntityFrameworkStores<DataContext>()
.AddSignInManager<SignInManager<IdentityUser>>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
});
builder.Services.AddAuthentication(options =>{
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    options.DefaultSignOutScheme = IdentityConstants.ExternalScheme;
    options.DefaultChallengeScheme = IdentityConstants.ExternalScheme;
}).AddCookie("Cookies", options =>{
    options.LoginPath = "/Users/Login";
    options.LogoutPath = "/Users/CikisYap";
});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
builder.Services.ConfigureApplicationCookie(options => {
    options.AccessDeniedPath = "/Users/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
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
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "sepet",
        pattern: "sepet/{action=Index}/{id?}",
        defaults: new { controller = "Sepet" });
    endpoints.MapControllerRoute(
        name: "category",
        pattern: "category/{id}",
        defaults: new { controller = "Category", action = "Details" });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

