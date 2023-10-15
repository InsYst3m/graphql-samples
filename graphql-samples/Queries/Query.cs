using Database;

using Graphql.Api.Entities;

namespace Graphql.Api.Queries
{
	public class Query
	{
		[UseProjection]
		public IQueryable<Portfolio> GetPortfolios(
			ApplicationDbContext dbContext)
		{
			return dbContext.Portfolios;
		}
	}
}
