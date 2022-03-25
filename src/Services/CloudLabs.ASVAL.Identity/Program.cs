using CloudLabs.ASVAL.Identity;
using CloudLabs.ASVAL.Identity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var seed = builder.Configuration.GetValue<bool>("Database:SeedData");

if(seed)
{
    SeedData.InitializeSeed(defaultConnectionString);
}

builder.Services.AddDbContext<UserIdentityDbContext>(optioons =>
{
    optioons.UseSqlServer(defaultConnectionString, b => b.MigrationsAssembly(assembly));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserIdentityDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = ctx =>
            ctx.UseSqlServer(defaultConnectionString, opt => opt.MigrationsAssembly(assembly));
    })
    .AddOperationalStore(options =>
   {
       options.ConfigureDbContext = ctx =>
           ctx.UseSqlServer(defaultConnectionString, opt => opt.MigrationsAssembly(assembly));
   })
    .AddDeveloperSigningCredential();


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
   endpoints.MapDefaultControllerRoute();
});

app.Run();
