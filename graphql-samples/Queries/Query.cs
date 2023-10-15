using Graphql.Api.Entities;

namespace Graphql.Api.Queries
{
	public class Query
	{
		public Portfolio GetPortfolio()
		{
			return new Portfolio()
			{
				Id = Guid.NewGuid(),
				Name = "Test Portfolio"
			};
		}
	}
}
