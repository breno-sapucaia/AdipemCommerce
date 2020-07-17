using AdipemCommerce.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdipemCommerce
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var server = Configuration["DbServer"] ?? "localhost";
			var port = Configuration["DbPort"] ?? "1433";
			var user = Configuration["DbUser"] ?? "sa";
			var password = Configuration["Password"] ?? "reallyStrongPwd123";
			var database = Configuration["Database"] ?? "AdipemCommerce";

			services.AddDbContext<DataContext>(options => {
				options.UseSqlServer($"Server={server},{port};Initial Catalog =${database};User Id={user};Password={password}", b => b.MigrationsAssembly("AdipemCommerce"));
			});



			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			PrepDB.PrepPopulation(app);
		}
	}
}
