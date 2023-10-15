using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions
{
	public static class DatabaseExtensions
	{
		public static IServiceCollection AddDatabaseLayer(this IServiceCollection services)
		{
			services.AddPooledDbContextFactory<ApplicationDbContext>(optionsBuilder =>
			{
				optionsBuilder.UseInMemoryDatabase("Graphql.Service.Example");
			});

			return services;
		}
	}
}
