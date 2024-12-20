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
        app.UseMiddleware<SessionInitializationMiddleware>();        // Initialize Sessions in Middleware folder
        app.UseSession();                                            // Sessions
        app.MapControllers();
        app.UseCookiePolicy();

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}