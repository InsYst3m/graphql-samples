using Graphql.Api.Entities;

using Microsoft.EntityFrameworkCore;

namespace Database
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		public virtual DbSet<Portfolio> Portfolios { get; set; }
		public virtual DbSet<Asset> Assets { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }
	}
}