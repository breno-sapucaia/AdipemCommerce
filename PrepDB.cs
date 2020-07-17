using AdipemCommerce.Domain;
using AdipemCommerce.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AdipemCommerce
{
	public class PrepDB
	{
		public static void PrepPopulation(IApplicationBuilder app)
		{
			using( var serviceScope = app.ApplicationServices.CreateScope())
			{
				SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
			}

		}

		private static void SeedData(DataContext ctx)
		{
			Console.WriteLine("Applying Migrations...");

			ctx.Database.Migrate();

			if (!ctx.Products.AnyAsync().GetAwaiter().GetResult())
			{
				Console.WriteLine("Adding data - seeding...");
				ctx.AddRange(
					new Product { Name="Caneta", Price= 9.54, Description =" Uma ótima caneta azul" },
					new Product { Name = "Computador", Price = 1500.94, Description = "Um computador do escambal" }
					);
                ctx.SaveChanges();
            }
			else
			{
				Console.WriteLine("Already have data - not seeding");
			}
			
		}
	}
}
