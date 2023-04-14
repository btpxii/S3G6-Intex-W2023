using Intex2.Areas.Identity.Data;
using Intex2.Core;
using Intex2.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Establishes connections to databases
var authConnectionString = builder.Configuration.GetConnectionString("AuthenticationConnection");
var dataConnectionString = builder.Configuration.GetConnectionString("MummiesConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(authConnectionString));
builder.Services.AddDbContext<MummiesDbContext>(options =>
    options.UseNpgsql(dataConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Sets ApplicationUser, extension of IdentityUser, as default identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

// Configures Hsts (didn't really work)
builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
});

// Attempt to fix Hsts above, suspected an issue with header forwarding through ELB
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// Establishes cookie policy
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential 
    // cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.Secure = CookieSecurePolicy.Always;
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
});

// Sets password requirements
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 4;
});


builder.Services.AddControllersWithViews();

#region Authorization
// Adds authorization to app, allowing serverside denial of resources based on RBAC
AddAuthorizationPolicies();

#endregion

// Configures repository pattern
builder.Services.AddScoped<IIntex2Repository, EFIntex2Repository>();

var app = builder.Build();

// Another attempt to forward headers for HSTS
app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // Still didn't work
}

// Sets up app to forward :80 traffic to :443 (not needed I think because I closed port 80 on my server
app.UseHttpsRedirection();
// Allows serving static files
app.UseStaticFiles();
// Enables cookie policy
app.UseCookiePolicy();

// Adds all kinds of headers for security, this is how I got HSTS working
app.Use(async (ctx, next) =>
{
    // I have to enable unsafe-inline for style-src and script-src to allow the change email functionality to work properly. I fully understand the vulnerability that this exposes, and in a real-world situation I would research further to understand how I can have both security and functionality.
    ctx.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; img-src 'self' data:; style-src 'self' 'unsafe-inline' https://stackpath.bootstrapcdn.com; script-src 'self' 'unsafe-inline' https://code.jquery.com https://stackpath.bootstrapcdn.com https://cdnjs.cloudflare.com");

    ctx .Request.Scheme = "https";

    ctx.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
    ctx.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
    ctx.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    ctx.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
    ctx.Response.Headers.Remove("Server");
    await next();
});

// Enables routing
app.UseRouting();

// Sets up app to use authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Maps endpoints for various views
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "BurialsPagination",
        pattern: "Home/BurialList/{pageNum}",
        defaults: new { Controller = "Home", action = "BurialList" });
    endpoints.MapControllerRoute(
        name: "BurialsFilterPagination",
        pattern: "Home/BurialList/{pageNum}/{slug}",
        defaults: new { Controller = "Home", action = "BurialList" });
    endpoints.MapControllerRoute(
        name: "EditBurial",
        pattern: "Home/BurialEdit/{burialId}",
        defaults: new { Controller = "Home", action = "BurialEdit" });

    endpoints.MapDefaultControllerRoute();

    endpoints.MapRazorPages();


});

app.MapRazorPages();

app.Run();

// Creates authorization policies
void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Administrator));
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequireResearcher, policy => policy.RequireRole(Constants.Roles.Researcher));
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequireUser, policy => policy.RequireRole(Constants.Roles.User));
    });

}