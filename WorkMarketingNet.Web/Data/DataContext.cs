using Microsoft.Data.Entity;
using System;
using WorkMarketingNet.Web.Models;

namespace WorkMarketingNet.Web.Data
{
    public class DataContext : DbContext
    {
		public DbSet<Company> Companies { get; set; }

		protected override void OnConfiguring(DbContextOptions builder)
		{
			builder.UseSqlServer(@"Server=(localdb)\ProjectsV12;Database=WorkMarketingNet;Trusted_Connection=True;");
		}
	}
}