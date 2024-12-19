using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Services;
public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new AggregateException("Default connection not found");

        builder.Services.AddDbContext<MovieDbContext>(options =>options.UseSqlServer(connectionString));
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IMovieService, MovieService>(); // implementation of service
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
        //app.UseSession();
        app.UseCookiePolicy();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}