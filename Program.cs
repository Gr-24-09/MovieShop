using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Middleware;
using MovieShop.Models.DataBase;
using MovieShop.Services;
using System.Threading.Tasks;
public class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new AggregateException("Default connection not found");

        builder.Services.AddDbContext<MovieDbContext>(opt => opt.UseSqlServer(connectionString));

        // Add Identity Services
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false; // Disable email confirmation
        })
            .AddEntityFrameworkStores<MovieDbContext>()
            .AddDefaultTokenProviders();

        //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MovieDbContext>();

        // Add Razor Pages
        builder.Services.AddRazorPages();
        

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        });

        // ADD SERVICES
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IMovieService, MovieService>(); // implementation of Movie Service
        builder.Services.AddScoped<ICartService, CartService>(); // implementation of Cart Service
        builder.Services.AddScoped<TMDBService>(); // Service that updates posters path in database
        builder.Services.AddScoped<ICustomerService, CustomerService>(); // implementation of Customer Service
        //builder.Services.AddScoped<ApplicationInitializer>();
        builder.Services.AddScoped<IEmailSender, MockEmailSender>();


        // SESSIONS SETUP
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        //// Seed roles and admin user
        //using (var scope = app.Services.CreateScope())
        //{
        //    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationInitializer>();
        //    await initializer.SeedRolesAndUsersAsync(); // Correct placement
        //}
        

        app.UseHttpsRedirection();
        // Enable Authentication and Authorization Middleware
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseRouting();
        app.UseSession();
        app.UseStaticFiles();

        app.UseMiddleware<SessionInitializationMiddleware>();       // Initialize Sessions in Middleware folder

        app.UseCookiePolicy();
        app.MapControllers();
        app.MapRazorPages(); // Enables routing for Razor Pages, including Identity
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        //Part of TMDBService - when WebShop is loaded, update poster path in database(image for movie)
            app.Lifetime.ApplicationStarted.Register(async () =>
            {
                using var scope = app.Services.CreateScope();
                var tmdbService = scope.ServiceProvider.GetRequiredService<TMDBService>();
                await tmdbService.UpdatePosterPathsAsync();
                Console.WriteLine("Download success.");
            });


        await app.RunAsync(); // Use RunAsync for the async Main
    }

}

