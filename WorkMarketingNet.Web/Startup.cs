using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using WorkMarketingNet.Web.Repositories;
using WorkMarketingNet.Web.Services;
using WorkMarketingNet.Web.Data;

namespace WorkMarketingNet.Web
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			// Add MVC services to the services container.
			services.AddMvc();

			//Add all SignalR related services to IoC.
			services.AddSignalR();

			services.AddEntityFramework()
				.AddSqlServer()
				.AddDbContext<DataContext>();

			services.AddSingleton<ICompaniesRepository, CompaniesRepository>();
			services.AddSingleton<ILocalizationService, LocalizationService>();
			services.AddSingleton<IGlobalizationService, GlobalizationService>();
			services.AddSingleton<IDictionaryService, DictionaryHardcoded>();
		}

        public void Configure(IApplicationBuilder app)
        {
			// Add static files to the request pipeline.
			app.UseStaticFiles();

			//Configure SignalR
			app.UseSignalR();

			// Add MVC to the request pipeline.
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index" });
			});
		}
    }
}
