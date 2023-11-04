using Makeup_1.CustomPolicies;
using Makeup_1.Database;
using Makeup_1.ModelBinders;
using Makeup_1.Serivces;
using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddDistributedMemoryCache();


// Add services to the container.
builder.Services.AddControllersWithViews(options => {
    options.ModelBinderProviders.Insert(0, new CartModelBinderProvider());
});
builder.Services.AddDbContext<ShopContext>(options => { 

    options.UseSqlServer(
        builder.Configuration
        .GetConnectionString("MakeupDB"));
});
builder.Services.AddTransient<IAuthorizationHandler, AllowUserHandler>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.IsEssential = true;
});
builder.Services
    .AddIdentity<User, IdentityRole>((IdentityOptions options) =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 1;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<ShopContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
        googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddFacebook(fbOptions =>
    {
        IConfigurationSection fbAuthSection = configuration.GetSection("Authentication:Facebook");
        fbOptions.AppId = fbAuthSection.GetSection("AppId").Value;
        fbOptions.AppSecret = fbAuthSection.GetSection("AppSecret").Value;
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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
