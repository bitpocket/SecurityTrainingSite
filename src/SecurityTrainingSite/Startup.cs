using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Authentication.Cookies;
using SecurityTrainingSite.Models;

namespace SecurityTrainingSite
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			// Set up configuration sources.
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		private IConfigurationRoot Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			Unsecure.ConnectionString = Configuration["Data:DefaultConnection:ConnectionString"];
			Secure.ConnectionString = Configuration["Data:DefaultConnection:ConnectionString"];
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseCookieAuthentication(options =>
			{
				options.AuthenticationScheme = "CookieAuth";
				options.LoginPath = new PathString("/Account/Login/");
				options.AccessDeniedPath = new PathString("/Account/Login/");
				options.AutomaticAuthenticate = true;
				options.AutomaticChallenge = true;
			});

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "index",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}
