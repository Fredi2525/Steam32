using Data;
using Microsoft.EntityFrameworkCore;
using Steam.Extensions;
using System.Diagnostics;
using Data.Managers;
using Data.Managers.Interfaces;

namespace Steam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            {
	            config.AddJsonFile($"appsettings.json", optional: false);
	            if (!Debugger.IsAttached)
	            {
		            config.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
	            }
	            if (args != null)
	            {
		            config.AddCommandLine(args);
	            }
            });
            builder.Services.AddDbContext<SteamDbContext>(options =>
	            options.UseSqlServer(builder.Configuration.GetConnectionString("SteamDbContext"),
		            sqlServerOptions => sqlServerOptions.CommandTimeout((int?)TimeSpan.FromMinutes(1).TotalSeconds)));


			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddScoped<IAccountManager, AccountManager>();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
           
            app.EnsureMigrationOfContext<SteamDbContext>(); //Force migration to the db

			app.Run();
        }
    }
}
