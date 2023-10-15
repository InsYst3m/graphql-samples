using Graphql.Api.Entities;

namespace Graphql.Api.Models.Subscriptions
{
	public class OnPortfolioCreatedPayload
	{
		public required Portfolio Portfolio { get; set; }
	}
}
