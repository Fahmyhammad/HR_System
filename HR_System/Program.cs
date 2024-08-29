using HR_Infarstuructre.Data;
using HR_Infarstuructre.IRepoistory;
using HR_Infarstuructre.Seeds;
using HR_Infarstuructre.ServicesRepository;
using HR_Infarstuructre.ViewModel;
using HR_System.Permission;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Database Context
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnHR")));

// Configure Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Configure Session
builder.Services.AddSession();

// Configure Authentication Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login";
    options.AccessDeniedPath = "/Admin/Home/Denied";
});

// Configure Security Stamp Validator for immediate logouts
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});

// Register Authorization and Unit of Work services
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Seed Default Users and Roles
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await DefultRole.SeedAsync(roleManager);
    await DefultUser.SeedUserAsync(userManager, roleManager);
}
catch (Exception)
{
    throw;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configure Routes
app.MapControllerRoute(
    name: "areas",
    pattern: "{area=Admin}/{controller=Accounts}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
