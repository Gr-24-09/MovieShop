using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Middleware;
using MovieShop.Services;
public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new AggregateException("Default connection not found");

        builder.Services.AddDbContext<MovieDbContext>(opt => opt.UseSqlServer(connectionString));
       
        // ADD SERVICES
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IMovieService, MovieService>(); // implementation of Movie Service
        builder.Services.AddScoped<ICartService, CartService>(); // implementation of Cart Service
        //builder.Services.AddScoped<TMDBService>(); // Service that updates posters path in database
        builder.Services.AddScoped<ICustomerService, CustomerService>(); // implementation of Customer Service


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

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();
        app.UseMiddleware<SessionInitializationMiddleware>();       // Initialize Sessions in Middleware folder
        app.MapControllers();
        app.UseCookiePolicy();

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


        //// Part of TMDBService - when WebShop is loaded, update poster path in database (image for movie)
        //app.Lifetime.ApplicationStarted.Register(async () =>
        //{
        //    using var scope = app.Services.CreateScope();
        //    var tmdbService = scope.ServiceProvider.GetRequiredService<TMDBService>();
        //    await tmdbService.UpdatePosterPathsAsync();
        //    Console.WriteLine("Download success.");
        //});

        app.Run();
    }

}