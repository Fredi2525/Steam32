using Data;
using Microsoft.EntityFrameworkCore;
using Steam.WebApp.Extensions;
using System.Diagnostics;
using Data.Managers;
using Data.Managers.Interfaces;
using Services.Interfaces;
using Entities.Account;
using Services;
using AutoMapper;
using Models.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            builder.Services.AddScoped<IMapper, Mapper>();
            builder.Services.AddScoped<IAccountManager, AccountManager>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddAutomapperConfiguration();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/auth/login");
                    options.LogoutPath = "/auth/logout";
                    options.SlidingExpiration = true;
                    options.Cookie.HttpOnly = false;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
           
            app.EnsureMigrationOfContext<SteamDbContext>(); //Force migration to the db

			app.Run();
        }
    }
}
