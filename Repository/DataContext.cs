
using AdipemCommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdipemCommerce.Repository
{
	public class DataContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			
		}	

		public void OnConfigurating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>().HasKey(e => e.Id);
			modelBuilder.Entity<Product>().Property(e =>e.Id).UseIdentityColumn();
		}
	}
}

