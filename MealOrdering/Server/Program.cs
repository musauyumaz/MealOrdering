using Blazored.Modal;
using MealOrdering.Server.Data.Contexts;
using MealOrdering.Server.Services.Extensions;
using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Server.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddBlazoredModal();

            builder.Services.ConfigureMapping();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDbContext<MealOrderingDbContext>(config => {
                config.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=MealOrdering;");
                config.EnableSensitiveDataLogging();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}